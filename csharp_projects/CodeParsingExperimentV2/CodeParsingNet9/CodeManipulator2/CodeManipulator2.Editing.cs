using CodeParsingNet9.CodeManipulator2.StaticUtils;
using CodeParsingNet9.Utility;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Text;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator2
{
    public partial class CodeManipulator2
    {
        private void UpdateProject(Solution newSolution, string source)
        {
            bool changesApplied = _workspace.TryApplyChanges(newSolution);
            if (!changesApplied) throw new Exception($"{source}: failed to apply changes to workspace");
            _solution = _workspace.CurrentSolution;
        }

        public void CreateDocumentIfNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                CreateDocument(filePath);
            }
        }

        public void CreateDocument(string filePath)
        {
            var project = GetProject(filePath);

            var projectFolder = CodeUtils.GetProjectFolder(project);
            if (string.IsNullOrWhiteSpace(projectFolder)) throw new Exception("CreateDocument: null project file path");
            string relativePath = Path.GetRelativePath(projectFolder, filePath);
            var segments = Utils.SplitPathSegments(relativePath);
            var folders = Utils.PopLast(segments);
            var namespaceParts = Utils.Clone(folders);
            namespaceParts.Insert(0, project.Name);

            var namespacePath = Utils.Join(".", namespaceParts);

            var sourceText = SourceText.From("namespace " + namespacePath + "\n{\n    \n}\n");

            string parentDir = Path.GetDirectoryName(filePath)!;
            if (!Directory.Exists(parentDir))
            {
                Directory.CreateDirectory(parentDir);
            }

            var documentInfo = DocumentInfo.Create(
                DocumentId.CreateNewId(project.Id),
                name: Path.GetFileName(filePath),
                filePath: filePath,
                folders: folders,
                loader: TextLoader.From(TextAndVersion.Create(sourceText, VersionStamp.Create(), filePath)));

            var newSolution = project.Solution.AddDocument(documentInfo);

            UpdateProject(newSolution, "CreateDocument");
        }

        public void CreateClass(string dstFilePath, string className)
        {
            // Copy to destination
            var dstDocument = GetDocument(dstFilePath);

            var classNode = CodeUtils.CreateClassNode(className);

            var dstRootNode = CodeUtils.GetRootNode(dstDocument);
            if (dstRootNode == null) throw new Exception("CopyClass: no destination root node");

            var dstNamespace = CodeUtils.TryGetNamespaceNode(dstRootNode);
            CompilationUnitSyntax newDstRoot;
            if (dstNamespace != null)
            {
                var newDstNamespaceNode = dstNamespace.AddMembers(classNode);
                newDstRoot = dstRootNode.ReplaceNode(dstNamespace, newDstNamespaceNode);
            }
            else
            {
                throw new NotImplementedException();
            }

            var newDstDocument = dstDocument.WithSyntaxRoot(newDstRoot);
            var newSolution = newDstDocument.Project.Solution;

            UpdateProject(newSolution, "CreateClass");
        }

        public void FormatDocument(string filePath)
        {
            var document = GetDocument(filePath);

            var options = document.Project.Solution.Workspace.Options;

            // Format the document
            var formattedDoc = Formatter.FormatAsync(document, options).Result;

            var newSolution = formattedDoc.Project.Solution;

            UpdateProject(newSolution, "Format Document");
        }

        public void CopyMethod(string srcDocPath, string srcClassName, string methodName, string dstDocPath, string dstClassName)
        {
            var srcProject = GetProject(srcDocPath);
            var srcDocument = GetDocument(srcDocPath);
            var srcRootNode = CodeUtils.GetRootNode(srcDocument);
            var srcClassNode = CodeUtils.GetClassNode(srcRootNode, srcClassName);
            var methodNode = CodeUtils.GetMethodNode(srcClassNode, methodName);

            var dstProject = GetProject(dstDocPath);
            var dstDocument = GetDocument(dstDocPath);
            var dstRootNode = CodeUtils.GetRootNode(dstDocument);
            var dstClassNode = CodeUtils.GetClassNode(dstRootNode, dstClassName);

            var newDstClassNode = CodeUtils.AddMemberToBack(dstClassNode, methodNode);
            var newDstRootNode = dstRootNode.ReplaceNode(dstClassNode, newDstClassNode);

            var newDstDocument = dstDocument.WithSyntaxRoot(newDstRootNode);
            var newSolution = newDstDocument.Project.Solution;

            UpdateProject(newSolution, "CopyMethod");
        }

        public void RemoveStaticKeywordFromMethod(string docPath, string className, string methodName)
        {
            var project = GetProject(docPath);
            var document = GetDocument(docPath);
            var rootNode = CodeUtils.GetRootNode(document);
            var classNode = CodeUtils.GetClassNode(rootNode, className);
            var methodNode = CodeUtils.GetMethodNode(classNode, methodName);

            var newMethodNode = CodeUtils.RemoveStaticKeyword(methodNode);

            var newRootNode = rootNode.ReplaceNode(methodNode, newMethodNode);

            var newDstDocument = document.WithSyntaxRoot(newRootNode);
            var newSolution = newDstDocument.Project.Solution;

            UpdateProject(newSolution, "RemoveStaticKeywordFromMethod");
        }

        public void AddMissingProjectDependencies(string docPath)
        {
            var project = GetProject(docPath);
            var document = GetDocument(docPath);
            var rootNode = CodeUtils.GetRootNode(document);
            var semanticModel = document.GetSemanticModelAsync().Result;
            if (semanticModel == null) throw new Exception("missing semantic model");

            var missingDependencies = CodeUtils.GetMissingDependencySymbolNames(rootNode, semanticModel);

            Dictionary<string, string> typeNameToNamespace = CodeUtils.BuildTypeNameToNamespaceDict(project);

            HashSet<string> namespacesToAdd = new HashSet<string>();
            foreach (string dependency in missingDependencies)
            {
                if (!typeNameToNamespace.ContainsKey(dependency))
                {
                    continue;
                }
                var dependencyNamespace = typeNameToNamespace[dependency];
                if (!namespacesToAdd.Contains(dependencyNamespace))
                {
                    namespacesToAdd.Add(dependencyNamespace);
                }
            }

            var newRootNode = rootNode;
            foreach (var namespaceToAdd in namespacesToAdd)
            {
                var usingNode = CodeUtils.CreateUsingDirectiveNode(namespaceToAdd);
                newRootNode = newRootNode.AddUsings(usingNode);
            }
            var newDocument = document.WithSyntaxRoot(newRootNode);
            var newSolution = newDocument.Project.Solution;

            UpdateProject(newSolution, "AddMissingProjectDependencies");
        }

        private void AddDependencyFieldToConstructor(string docPath, string className, string dependencyFieldType, int constructorIndex)
        {
            string constructorArgName = Utils.PascalCaseToCamelCase(dependencyFieldType);
            string constructorFieldName = "_" + constructorArgName;

            var project = GetProject(docPath);
            var document = GetDocument(docPath);
            var rootNode = CodeUtils.GetRootNode(document);
            var classNode = CodeUtils.GetClassNode(rootNode, className);
            var constructors = CodeUtils.GetConstructors(classNode);

            var constructor = constructors[constructorIndex];
            var newConstructorNode = CodeUtils.AddArgument(constructor, dependencyFieldType, constructorArgName);
            newConstructorNode = CodeUtils.AddAssignmentToTop(newConstructorNode, constructorFieldName, constructorArgName);
            rootNode = rootNode.ReplaceNode(newConstructorNode, constructor);

            var newDocument = document.WithSyntaxRoot(rootNode);
            var newSolution = newDocument.Project.Solution;

            UpdateProject(newSolution, "AddMissingProjectDependencies");
        }

        public void AddDependencyField(string docPath, string className, string dependencyFieldType)
        {
            string constructorArgName = Utils.PascalCaseToCamelCase(dependencyFieldType);
            string constructorFieldName = "_" + constructorArgName;

            var project = GetProject(docPath);
            var document = GetDocument(docPath);
            var rootNode = CodeUtils.GetRootNode(document);
            var classNode = CodeUtils.GetClassNode(rootNode, className);
            var constructors = CodeUtils.GetConstructors(classNode);



            if (constructors.Count == 0)
            {
                var newConstructor = CodeUtils.CreateConstructor(classNode);
                newConstructor = CodeUtils.AddArgument(newConstructor, dependencyFieldType, constructorArgName);
                newConstructor = CodeUtils.AddAssignmentToTop(newConstructor, constructorFieldName, constructorArgName);
                var newClassNode = CodeUtils.AddMemberToBack(classNode, newConstructor);
                newClassNode = CodeUtils.AddField(newClassNode, dependencyFieldType, constructorFieldName);
                rootNode = rootNode.ReplaceNode(classNode, newClassNode);

                var newDocument = document.WithSyntaxRoot(rootNode);
                var newSolution = newDocument.Project.Solution;

                UpdateProject(newSolution, "AddMissingProjectDependencies");
                return;
            }

            { // add field
                var newClassNode = CodeUtils.AddField(classNode, dependencyFieldType, constructorFieldName);
                var newRootNode = rootNode.ReplaceNode(classNode, newClassNode);

                var newDocument = document.WithSyntaxRoot(newRootNode);
                var newSolution = newDocument.Project.Solution;

                UpdateProject(newSolution, "AddMissingProjectDependencies");
            }
            

            for (int i = 0; i < constructors.Count; i++)
            {
                AddDependencyFieldToConstructor(docPath, className, dependencyFieldType, i);
            }
        }
    }
}
