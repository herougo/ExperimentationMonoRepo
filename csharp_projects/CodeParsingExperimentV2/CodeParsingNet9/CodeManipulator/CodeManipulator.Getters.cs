using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.FindSymbols;
using CodeParsingNet9.Utility;

namespace CodeParsingNet9.CodeManipulator
{
    public partial class CodeManipulator
    {
        public Document GetDocument(string filePath)
        {
            var result = _project.Documents.FirstOrDefault(d =>
                string.Equals(d.FilePath, filePath, StringComparison.OrdinalIgnoreCase));
            if (result == null) throw new Exception("missing document");
            return result;
        }

        public CompilationUnitSyntax GetRootNode(Document document)
        {
            var task = document.GetSyntaxRootAsync();
            var result = task.Result as CompilationUnitSyntax; // TODO: why convert?
            if (result == null) throw new Exception("null root node");
            return result;
        }

        public ClassDeclarationSyntax GetClassNode(CompilationUnitSyntax rootNode, string className)
        {
            var result = rootNode.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.Text == className);
            if (result == null) throw new Exception("null class node");
            return result;
        }

        public NamespaceDeclarationSyntax? TryGetNamespaceNode(CompilationUnitSyntax rootNode)
        {
            var result = rootNode.DescendantNodes().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
            return result;
        }

        public NamespaceDeclarationSyntax GetNamespaceNode(CompilationUnitSyntax rootNode)
        {
            var result = TryGetNamespaceNode(rootNode);
            if (result == null) throw new Exception("null namespace node");
            return result;
        }

        public string GetNamespaceName(NamespaceDeclarationSyntax? namespaceNode)
        {
            if (namespaceNode == null)
            {
                return "";
            }
            else
            {
                return namespaceNode.Name.ToString();
            }
        }

        public string GetProjectFolder()
        {
            if (_project.FilePath == null) throw new Exception("GetProjectFolder: _project.FilePath is null");
            string? folder = Utils.ParentFolder(_project.FilePath);
            if (folder == null) throw new Exception("GetProjectFolder: project folder is missing?");

            return folder;
        }
    }
}
