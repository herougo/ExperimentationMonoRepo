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
    public enum CodeBlockArcType : int
    {
        MethodInvocation = 0,
        TypeUsage = 1,
        ContainedMember = 2
    }

    public class CodeBlockArc
    {
        public readonly CodeBlockNode InNode;
        public readonly CodeBlockNode OutNode;
        public readonly CodeBlockArcType Type;

        public CodeBlockArc(CodeBlockNode inNode, CodeBlockNode outNode, CodeBlockArcType type)
        {
            InNode = inNode;
            OutNode = outNode;
            Type = type;
        }
    }

    public class CodeBlockArcComparer : IEqualityComparer<CodeBlockArc>
    {
        private CodeBlockNodeComparer _comparer = new CodeBlockNodeComparer();

        public bool Equals(CodeBlockArc? x, CodeBlockArc? y)
        {
            if (x is null || y is null) return false;
            if (ReferenceEquals(x, y)) return true;
            if (x.Type != y.Type) return false;
            if (!_comparer.Equals(x.InNode, y.InNode)) return false;
            if (!_comparer.Equals(x.OutNode, y.OutNode)) return false;
            return true;
        }

        public int GetHashCode(CodeBlockArc obj)
        {
            if (obj is null) return 0;
            string id = obj.InNode.Id + "-" + obj.Type + "-" + obj.OutNode.Id;
            return string.GetHashCode(id);
        }
    }
}
