using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
        public static ClassDeclarationSyntax CreateClassNode(string className)
        {
            // Create the class declaration
            var classDeclaration = SyntaxFactory.ClassDeclaration(className)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword));

            return classDeclaration.NormalizeWhitespace();
        }

        public static UsingDirectiveSyntax CreateUsingDirectiveNode(string namespaceName)
        {
            return SyntaxFactory.UsingDirective(
                SyntaxFactory.ParseName(namespaceName)).NormalizeWhitespace();
        }

        public static ConstructorDeclarationSyntax CreateConstructor(ClassDeclarationSyntax classNode)
        {
            return SyntaxFactory.ConstructorDeclaration(classNode.Identifier.Text)
                .WithModifiers(SyntaxFactory.TokenList(SyntaxFactory.Token(SyntaxKind.PublicKeyword))).NormalizeWhitespace();

        }
    }
}
