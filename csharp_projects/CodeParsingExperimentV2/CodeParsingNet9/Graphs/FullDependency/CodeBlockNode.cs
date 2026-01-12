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
    public enum CodeBlockNodeType : int
    {
        Other = 0,
        Class = 1,
        Method = 2,
        Enum = 3,
        Interface = 4,
        FieldDeclaration = 5,
        PropertyDeclaration = 6
        // TODO: add record and struct?
    }

    public class CodeBlockNode
    {
        public string Id { get; }
        public CodeBlockNodeType SymbolType { get; }
        public ISymbol Symbol { get; }

        public CodeBlockNode(ISymbol symbol)
        {
            Symbol = symbol;
            Id = CodeUtils.GetSymbolId(symbol);
            SymbolType = CodeUtils.GetSymbolType(symbol);
        }

        public override string ToString() => Id;
    }

    public class CodeBlockNodeComparer : IEqualityComparer<CodeBlockNode>
    {
        public bool Equals(CodeBlockNode? x, CodeBlockNode? y)
        {
            if (x is null || y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            return SymbolEqualityComparer.Default.Equals(x.Symbol, y.Symbol);
        }

        public int GetHashCode(CodeBlockNode obj)
        {
            if (obj is null) return 0;
            return SymbolEqualityComparer.Default.GetHashCode(obj.Symbol);
        }
    }
}
