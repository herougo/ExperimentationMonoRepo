using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.FindSymbols;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Text;
using CodeParsingNet9.Utility;

namespace CodeParsingNet9.CodeManipulator
{
    public partial class CodeManipulator
    {
        /* Notes
          - CAUTION: Do not use an old Document instance after the _project has been updated!
                     Project updates make the document references stale.
        */

        private void UpdateProject(Solution newSolution, string source)
        {
            bool changesApplied = _workspace.TryApplyChanges(newSolution);
            if (!changesApplied) throw new Exception($"{source}: failed to apply changes to workspace");
            var newProject = _workspace.CurrentSolution.GetProject(_project.Id)!;
            _project = newProject;
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
            var projectFolder = GetProjectFolder();
            if (string.IsNullOrWhiteSpace(projectFolder)) throw new Exception("CreateDocument: null project file path");
            string relativePath = Path.GetRelativePath(projectFolder, filePath);
            var segments = Utils.SplitPathSegments(relativePath);
            var folders = Utils.PopLast(segments);
            var namespaceParts = Utils.Clone(folders);
            namespaceParts.Insert(0, _project.Name);

            var namespacePath = Utils.Join(".", namespaceParts);

            var sourceText = SourceText.From("namespace " + namespacePath + "\n{\n    \n}\n");

            string parentDir = Path.GetDirectoryName(filePath)!;
            if (!Directory.Exists(parentDir))
            {
                Directory.CreateDirectory(parentDir);
            }

            var documentInfo = DocumentInfo.Create(
                DocumentId.CreateNewId(_project.Id),
                name: Path.GetFileName(filePath),
                filePath: filePath,
                folders: folders,
                loader: TextLoader.From(TextAndVersion.Create(sourceText, VersionStamp.Create(), filePath)));

            var newSolution = _project.Solution.AddDocument(documentInfo);

            UpdateProject(newSolution, "CreateDocument");
        }

        public void RemoveClass(string filePath, string className)
        {
            var document = GetDocument(filePath);

            var rootNode = GetRootNode(document);

            var classNode = GetClassNode(rootNode, className);

            var newRootNode = rootNode.RemoveNode(classNode, SyntaxRemoveOptions.KeepNoTrivia);
            if (newRootNode == null) throw new Exception("RemoveClass: no new root node");

            var newDocument = document.WithSyntaxRoot(newRootNode);
            var newSolution = newDocument.Project.Solution;

            UpdateProject(newSolution, "RemoveClass");
        }

        public void CopyClass(string srcFilePath, string className, string dstFilePath)
        {
            // Get class
            var srcDocument = GetDocument(srcFilePath);
            var srcRootNode = GetRootNode(srcDocument);

            var srcClassNode = GetClassNode(srcRootNode, className);

            // Copy to destination
            var dstDocument = GetDocument(dstFilePath);

            var dstRootNode = GetRootNode(dstDocument);
            if (dstRootNode == null) throw new Exception("CopyClass: no destination root node");

            var dstNamespace = TryGetNamespaceNode(dstRootNode);
            CompilationUnitSyntax newDstRoot;
            if (dstNamespace != null)
            {
                var newDstNamespaceNode = dstNamespace.AddMembers(srcClassNode);
                newDstRoot = dstRootNode.ReplaceNode(dstNamespace, newDstNamespaceNode);
            }
            else
            {
                string namespaceName = GetNamespaceName(dstNamespace);
                newDstRoot = dstRootNode.AddMembers(srcClassNode);
            }

            var newDstDocument = dstDocument.WithSyntaxRoot(newDstRoot);
            var newSolution = newDstDocument.Project.Solution;

            UpdateProject(newSolution, "CopyClass");
        }

        public void MoveClass(string srcFilePath, string className, string dstFilePath)
        {
            CopyClass(srcFilePath, className, dstFilePath);
            RemoveClass(srcFilePath, className);
        }

        public void FormatDocument(string filePath)
        {
            var document = GetDocument(filePath);

            // Use the workspace options to control formatting
            var options = document.Project.Solution.Workspace.Options;

            // Format the document
            var formattedDoc = Formatter.FormatAsync(document, options).Result;

            var newSolution = formattedDoc.Project.Solution;

            UpdateProject(newSolution, "RemoveClass");
        }
    }


}
