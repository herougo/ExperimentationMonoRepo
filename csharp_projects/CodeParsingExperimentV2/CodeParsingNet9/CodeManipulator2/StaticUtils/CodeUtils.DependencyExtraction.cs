using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeParsingNet9.CodeManipulator2.StaticUtils
{
    public static partial class CodeUtils
    {
        public static Dictionary<string, string> BuildTypeNameToNamespaceDict(Project project)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var document in project.Documents)
            {
                var rootNode = GetRootNode(document);
                foreach (var node in rootNode.DescendantNodes().OfType<ClassDeclarationSyntax>())
                {
                    string className = node.Identifier.Text;
                    if (result.ContainsKey(className))
                    {
                        throw new Exception($"duplicate {className}");
                    }
                    result[className] = GetNamespaceName(rootNode);
                }
            }

            return result;
        }
    }
}
