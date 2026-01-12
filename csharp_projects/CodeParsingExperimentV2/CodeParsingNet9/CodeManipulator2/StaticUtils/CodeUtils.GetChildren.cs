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
        public static List<MemberDeclarationSyntax> GetChildren(CompilationUnitSyntax rootNode)
        {
            // TODO: fix??

            // Handle file-scoped or block-scoped namespaces
            var namespaceDecl =
                rootNode.Members.OfType<BaseNamespaceDeclarationSyntax>()
                    .FirstOrDefault();

            if (namespaceDecl != null)
            {
                // Immediate children of the namespace
                return namespaceDecl.Members.ToList();
            }

            // No namespace → immediate children are top-level members
            return rootNode.Members.ToList();
        }

        public static List<MemberDeclarationSyntax> GetChildren(ClassDeclarationSyntax classNode)
        {
            // TODO: fix??

            return classNode.Members.ToList();
        }
    }
}
