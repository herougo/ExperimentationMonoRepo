using CodeParsingNet9.CodeManipulator2.StaticUtils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Graphs.FullDependency
{
    public partial class FullDependencyGraph
    {
        public readonly Dictionary<CodeBlockNode, HashSet<CodeBlockArc>> DirectedEdges = new Dictionary<CodeBlockNode, HashSet<CodeBlockArc>>(new CodeBlockNodeComparer());

        public readonly Dictionary<ISymbol, CodeBlockNode> AllNodes = new Dictionary<ISymbol, CodeBlockNode>(SymbolEqualityComparer.Default);

        private CodeBlockNode GetOrAddNode(ISymbol symbol)
        {
            if (!AllNodes.TryGetValue(symbol, out var node))
            {
                node = new CodeBlockNode(symbol);
                AllNodes[symbol] = node;
                DirectedEdges[node] = new HashSet<CodeBlockArc>(new CodeBlockArcComparer());
            }
            return node;
        }

        private CodeBlockNode GetNode(ISymbol symbol)
        {
            AllNodes.TryGetValue(symbol, out var node);
            if (node == null)
            {
                throw new Exception("Missing node");
            }
            return node;
        }

        private CodeBlockArc AddDirectedEdge(CodeBlockNode codeBlockIn, CodeBlockNode codeBlockOut, CodeBlockArcType codeBlockArcType)
        {
            var arc = new CodeBlockArc(codeBlockIn, codeBlockOut, codeBlockArcType);

            DirectedEdges[codeBlockIn].Add(arc);

            return arc;
        }

        private CodeBlockArc? AddDirectedEdgeIfMissing(CodeBlockNode codeBlockIn, CodeBlockNode codeBlockOut, CodeBlockArcType codeBlockArcType)
        {
            if (!HasDirectedEdge(codeBlockIn, codeBlockOut, codeBlockArcType))
            {
                AddDirectedEdge(codeBlockIn, codeBlockOut, codeBlockArcType);
            }

            return null;
        }

        private bool HasDirectedEdge(CodeBlockNode codeBlockIn, CodeBlockNode codeBlockOut, CodeBlockArcType codeBlockArcType)
        {
            return DirectedEdges[codeBlockIn].Contains(new CodeBlockArc(codeBlockIn, codeBlockOut, codeBlockArcType));
        }

        public async Task BuildAsync(List<Project> projects)
        {
            await BuildAllNodesAndMemberArcs(projects);

            await BuildMethodArcs(projects);

            await BuildTypeArcs(projects);
        }
    }
}
