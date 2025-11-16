using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.Unused
{
    /*
    public partial class CodeManipulator2
    {


        public ClassDeclarationSyntax EnforceMemberSpacing(ClassDeclarationSyntax classNode)
        {
            var members = classNode.Members;

            var newMembers = new SyntaxList<MemberDeclarationSyntax>();

            for (int i = 0; i < members.Count; i++)
            {
                var current = members[i];
                var next = i < members.Count - 1 ? members[i + 1] : null;

                // Remove all trailing blank lines
                current = current.WithTrailingTrivia(SyntaxFactory.ElasticCarriageReturnLineFeed);

                if (next != null)
                {
                    var separator = GetSeparatorTrivia(current, next);
                    current = current.WithTrailingTrivia(separator);
                }

                newMembers = newMembers.Add(current);
            }

            var newClass = classNode.WithMembers(newMembers);

            return newClass;
        }

        private SyntaxTriviaList GetSeparatorTrivia(MemberDeclarationSyntax current, MemberDeclarationSyntax next)
        {
            bool currentIsField = current is FieldDeclarationSyntax;
            bool nextIsField = next is FieldDeclarationSyntax;
            bool currentIsMethod = current is MethodDeclarationSyntax;
            bool nextIsMethod = next is MethodDeclarationSyntax;

            int newlines = 0;

            if (currentIsField && nextIsField)
                newlines = 0;
            else if ((currentIsField && nextIsMethod) || (currentIsMethod && nextIsMethod))
                newlines = 1;

            // Always add a single newline at least
            return SyntaxFactory.TriviaList(Enumerable.Repeat(SyntaxFactory.CarriageReturnLineFeed, newlines));
        }
    }
    */
}
