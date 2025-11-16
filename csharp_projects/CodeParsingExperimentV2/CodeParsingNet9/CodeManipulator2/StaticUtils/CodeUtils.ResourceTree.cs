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
    public class ResourceTreeBfsManager : IBfsManager<SyntaxNode>
    {
        private List<Tuple<string, string>> _result = new List<Tuple<string, string>>();

        public void ProcessNode(SyntaxNode node, List<SyntaxNode> pathFromRoot)
        {
            // TODO: handle "using namespace ___"

            if (!IsResourceNode(node)) return;

            var root = pathFromRoot[0];
            var rootTyped = root as CompilationUnitSyntax;
            if (rootTyped == null) throw new Exception("null root");

            string path = CodeUtils.GetNamespaceName(rootTyped);

            foreach (var currentNode in pathFromRoot)
            {
                switch (currentNode)
                {
                    case ClassDeclarationSyntax cls:
                        path += "." + cls.Identifier;
                        break;
                    case EnumDeclarationSyntax e:
                        path += "." + e.Identifier;
                        break;
                    case InterfaceDeclarationSyntax i:
                        path += "." + i.Identifier;
                        break;
                    default:
                        break;
                }
            }

            string identifier = "";
            switch (node)
            {
                case ClassDeclarationSyntax cls:
                    identifier = cls.Identifier.Text;
                    break;
                case EnumDeclarationSyntax e:
                    identifier = e.Identifier.Text;
                    break;
                case InterfaceDeclarationSyntax i:
                    identifier = i.Identifier.Text;
                    break;
                default:
                    throw new Exception("Unhandled type in ResourceTreeBfsManager");
            }

            _result.Add(new Tuple<string, string>(identifier, path));
        }

        public List<SyntaxNode> GetChildren(SyntaxNode node)
        {
            return node.ChildNodes().ToList();
        }

        private bool IsResourceNode(SyntaxNode node)
        {
            return (
                node.GetType() == typeof(ClassDeclarationSyntax)
                || node.GetType() == typeof(EnumDeclarationSyntax)
                || node.GetType() == typeof(InterfaceDeclarationSyntax)
            );
        }

        public List<Tuple<string, string>> ExtractValues()
        {
            return _result;
        }
    }

    public static partial class CodeUtils
    {
        public static string GetResourceTreeInfo(Solution solution, string projectName)
        {
            Dictionary<string, List<string>> identifierToPaths = new Dictionary<string, List<string>>();
            List<string> paths = new List<string>();

            StringBuilder sb = new StringBuilder();
            var project = GetProjectByName(solution, projectName);

            foreach (var document in project.Documents)
            {
                var root = GetRootNode(document);

                var manager = new ResourceTreeBfsManager();

                BreadthFirstSearch.Execute(root, manager);

                var managerValues = manager.ExtractValues();
                foreach (var value in managerValues)
                {
                    string identifier = value.Item1;
                    string path = value.Item2;

                    if (identifierToPaths.ContainsKey(identifier))
                    {
                        identifierToPaths[identifier].Add(path);
                    }
                    else
                    {
                        identifierToPaths[identifier] = new List<string>() { path };
                    }
                    paths.Add(path);
                }
            }
            sb.AppendLine("-----------------------");
            sb.AppendLine("All Paths");
            sb.AppendLine("-----------------------");
            foreach (string path in paths)
            {
                sb.AppendLine(path);
            }
            sb.AppendLine("-----------------------");
            sb.AppendLine("Duplicates");
            sb.AppendLine("-----------------------");
            foreach (var item in identifierToPaths)
            {
                List<string> itemPaths = item.Value;
                if (itemPaths.Count > 1)
                {
                    sb.AppendLine(item.Key);
                    foreach (var path in itemPaths)
                    {
                        sb.AppendLine("\t" + path);
                    }

                }
            }

            return sb.ToString();
        }
    }
}
