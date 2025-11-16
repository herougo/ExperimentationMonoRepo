using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CodeParsingNet9.CodeManipulator2.StaticUtils
{
    public static partial class CodeUtils
    {
        public static MethodDeclarationSyntax RemoveStaticKeyword(MethodDeclarationSyntax methodNode)
        {
            // Remove any 'static' modifier
            var newModifiers = new SyntaxTokenList(
                methodNode.Modifiers.Where(m => !m.IsKind(SyntaxKind.StaticKeyword))
            );

            // Return a new node with updated modifiers
            return methodNode.WithModifiers(newModifiers);
        }

        public static MethodDeclarationSyntax AddArgument(MethodDeclarationSyntax methodNode, string argType, string argName)
        {
            var newParameter = SyntaxFactory.Parameter(
                SyntaxFactory.Identifier(argName))
                .WithType(SyntaxFactory.ParseTypeName(argType))
                .NormalizeWhitespace();

            // Add the new parameter to the constructor
            var updatedMethodNode = methodNode.AddParameterListParameters(newParameter);
            return updatedMethodNode;
        }

        public static ConstructorDeclarationSyntax AddArgument(
            ConstructorDeclarationSyntax methodNode, string argType, string argName
        )
        {
            var newParameter = SyntaxFactory.Parameter(
                SyntaxFactory.Identifier(argName))
                .WithType(SyntaxFactory.ParseTypeName(argType))
                .NormalizeWhitespace();

            // Add the new parameter to the constructor
            var updatedMethodNode = methodNode.AddParameterListParameters(newParameter);
            return updatedMethodNode;
        }

        public static ConstructorDeclarationSyntax AddAssignmentToTop(ConstructorDeclarationSyntax methodNode, string lhsVarName, string rhsVarName)
        {
            var assignment = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(lhsVarName),
                    SyntaxFactory.IdentifierName(rhsVarName)
                )
            ).NormalizeWhitespace();
            return methodNode.AddBodyStatements(assignment);
        }

        public static MethodDeclarationSyntax AddAssignmentToTop(MethodDeclarationSyntax methodNode, string lhsVarName, string rhsVarName)
        {
            var assignment = SyntaxFactory.ExpressionStatement(
                SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(lhsVarName),
                    SyntaxFactory.IdentifierName(rhsVarName)
                )
            ).NormalizeWhitespace();
            return methodNode.AddBodyStatements(assignment);
        }

        public static ClassDeclarationSyntax AddField(ClassDeclarationSyntax classNode, string fieldType, string fieldName)
        {
            var newField = SyntaxFactory.FieldDeclaration(
                SyntaxFactory.VariableDeclaration(SyntaxFactory.ParseTypeName(fieldType))
                    .WithVariables(
                        SyntaxFactory.SingletonSeparatedList(SyntaxFactory.VariableDeclarator(fieldName))
                        )
                    )
                    .WithModifiers(SyntaxFactory.TokenList(
                        SyntaxFactory.Token(SyntaxKind.PrivateKeyword),
                        SyntaxFactory.Token(SyntaxKind.ReadOnlyKeyword)
                    )
            );
            newField = newField.NormalizeWhitespace();
            return AddMemberToFront(classNode, newField);
        }

        public static ClassDeclarationSyntax AddMemberToFront(ClassDeclarationSyntax classNode, MemberDeclarationSyntax node)
        {
            var newMembers = classNode.Members.Insert(0, AddTrailingNewLine(node));
            return classNode.WithMembers(newMembers);
        }

        public static ClassDeclarationSyntax AddMemberToBack(ClassDeclarationSyntax classNode, MemberDeclarationSyntax node)
        {
            return classNode.AddMembers(AddLeadingNewLine(node));
        }

        public static T AddTrailingNewLine<T>(T node) where T : SyntaxNode
        {
            var result = node.WithTrailingTrivia(SyntaxFactory.CarriageReturnLineFeed);
            if (result == null) throw new Exception("AddTrailingNewLine: null result");
            return result;
        }

        public static T AddLeadingNewLine<T>(T node) where T : SyntaxNode
        {
            var result = node.WithLeadingTrivia(SyntaxFactory.CarriageReturnLineFeed);
            if (result == null) throw new Exception("AddLeadingNewLine: null result");
            return result;
        }
    }
}
