using CodeParsingNet9.Graphs.FullDependency;
using CodeParsingNet9.Utility;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator2.StaticUtils
{
    public static partial class CodeUtils
    {
        public static string GetSolutionFolder(Solution solution)
        {
            if (solution.FilePath == null) throw new Exception("null solution file path?");
            string? result = Utils.ParentFolder(solution.FilePath);
            if (result == null) throw new Exception("null solution folder?");
            return result;
        }

        public static Project GetProject(Solution solution, string filePath)
        {
            string solutionFolderPath = GetSolutionFolder(solution);

            if (!Utils.IsDescendant(solutionFolderPath, filePath))
            {
                throw new Exception("GetProjectFolder: file path not descentdant");
            }

            return solution.Projects.First(
                p => p.FilePath != null && Utils.IsDescendant(Utils.ParentFolder(p.FilePath), filePath)
            );
        }

        public static Project GetProjectByName(Solution solution, string name)
        {
            return solution.Projects.First(
                p => p.Name == name
            );
        }

        public static Document GetDocument(Solution solution, string filePath)
        {
            var project = GetProject(solution, filePath);
            var result = project.Documents.FirstOrDefault(d =>
                string.Equals(d.FilePath, filePath, StringComparison.OrdinalIgnoreCase));
            if (result == null) throw new Exception("missing document");
            return result;
        }

        public static CompilationUnitSyntax GetRootNode(Document document)
        {
            var task = document.GetSyntaxRootAsync();
            var result = task.Result as CompilationUnitSyntax; // TODO: why convert?
            if (result == null) throw new Exception("null root node");
            return result;
        }

        public static ClassDeclarationSyntax GetClassNode(CompilationUnitSyntax rootNode, string className)
        {
            var result = rootNode.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.Text == className);
            if (result == null) throw new Exception("null class node");
            return result;
        }

        public static NamespaceDeclarationSyntax? TryGetNamespaceNode(CompilationUnitSyntax rootNode)
        {
            var result = rootNode.DescendantNodes().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
            return result;
        }

        public static NamespaceDeclarationSyntax GetNamespaceNode(CompilationUnitSyntax rootNode)
        {
            var result = TryGetNamespaceNode(rootNode);
            if (result == null) throw new Exception("no namespace node");
            return result;
        }

        public static string GetNamespaceName(CompilationUnitSyntax rootNode)
        {
            // TODO: handle "using namespace ___"
            var namespaceNode = GetNamespaceNode(rootNode);
            return namespaceNode.Name.ToString();
        }

        public static string GetProjectFolder(Project project)
        {
            if (project.FilePath == null) throw new Exception("GetProjectFolder: _project.FilePath is null");
            string? folder = Utils.ParentFolder(project.FilePath);
            if (folder == null) throw new Exception("GetProjectFolder: project folder is missing?");

            return folder;
        }

        public static MethodDeclarationSyntax GetMethodNode(ClassDeclarationSyntax classDeclaration, string methodName)
        {
            var methodNodes = new List<MethodDeclarationSyntax>();
            foreach (MethodDeclarationSyntax node in classDeclaration.Members.OfType<MethodDeclarationSyntax>())
            {
                if (node.Identifier.Text == methodName)
                {
                    methodNodes.Add(node);
                }
            }
            if (methodNodes.Count == 0) throw new Exception($"GetMethodNode: no method with name {methodName}");
            if (methodNodes.Count > 1) throw new Exception($"GetMethodNode: >1 method with name {methodName}");

            return methodNodes[0];
        }

        public static List<string> GetMissingDependencySymbolNames(CompilationUnitSyntax rootNode, SemanticModel semanticModel)
        {
            Console.WriteLine("Warning: GetMissingDependencySymbolNames needs improvement *************");
            var missingDependencies = new HashSet<string>();
            var diagnostics = semanticModel.GetDiagnostics()
                .Where(d => d.Severity == DiagnosticSeverity.Error)
                .Where(d =>
                    d.Id is "CS0103" // The name 'X' does not exist in the current context
                                     // or "CS0246"    // The type or namespace name could not be found
                                     // or "CS0234"    // The type or namespace name 'X' does not exist in the namespace 'Y'
                    );
            foreach (var diagnostic in diagnostics)
            {
                string message = diagnostic.ToString();
                string trimMiddle = "error CS0103: The name '";
                string trimEnd = "' does not exist in the current context";

                if (!message.Contains(trimMiddle) || !message.EndsWith(trimEnd))
                    throw new Exception($"Can't parse {message}");

                message = message.Substring(message.IndexOf(trimMiddle) + trimMiddle.Length);
                message = message.Substring(0, message.Length - trimEnd.Length);
                missingDependencies.Add(message);
            }
            return missingDependencies.ToList();
        }

        public static List<ConstructorDeclarationSyntax> GetConstructors(ClassDeclarationSyntax classNode)
        {
            return classNode.DescendantNodes().OfType<ConstructorDeclarationSyntax>().ToList(); // TODO
        }

        public static SemanticModel GetSemanticModel(Document document)
        {
            var result = document.GetSemanticModelAsync().Result;
            if (result == null) throw new Exception("missing semantic model");
            return result;
        }

        public static string GetSolutionFilePathFromDirectory(string directory)
        {
            if (!Directory.Exists(directory))
            {
                throw new ArgumentException($"GetSolutionFilePathFromDirectory: {directory} is not a directory");
            }

            int numSolutionFiles = 0;
            string result = "";

            foreach (string filePath in Directory.GetFiles(directory))
            {
                if (filePath.EndsWith(".sln"))
                {
                    numSolutionFiles++;
                    result = filePath;
                }
            }

            if (numSolutionFiles != 1)
            {
                throw new Exception($"GetSolutionFilePathFromDirectory: the number of .sln files is not 1 ({numSolutionFiles})");
            }

            return result;
        }

        public static string GetSymbolId(ISymbol symbol)
        {
            return symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
        }

        public static CodeBlockNodeType GetSymbolType(ISymbol symbol)
        {
            if (symbol == null)
                return CodeBlockNodeType.Other;

            switch (symbol)
            {
                case INamedTypeSymbol namedType:
                    switch (namedType.TypeKind)
                    {
                        case TypeKind.Class:
                            return CodeBlockNodeType.Class;

                        case TypeKind.Interface:
                            return CodeBlockNodeType.Interface;

                        case TypeKind.Enum:
                            return CodeBlockNodeType.Enum;

                        default:
                            return CodeBlockNodeType.Other;
                    }

                case IMethodSymbol _:
                    return CodeBlockNodeType.Method;

                case IFieldSymbol _:
                    return CodeBlockNodeType.FieldDeclaration;

                case IPropertySymbol _:
                    return CodeBlockNodeType.PropertyDeclaration;

                default:
                    return CodeBlockNodeType.Other;
            }
        }
    }
}
