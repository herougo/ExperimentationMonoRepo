using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeParsingNet9.CodeManipulator2.SyntaxWalkers
{
    // Created with ChatGPT

    internal sealed class TypeUsageWalker : CSharpSyntaxWalker
    {
        private readonly SemanticModel _semanticModel;
        private readonly CancellationToken _cancellationToken;

        private readonly HashSet<INamedTypeSymbol> _results =
            new(SymbolEqualityComparer.Default);

        public IReadOnlyCollection<INamedTypeSymbol> Results => _results;

        public TypeUsageWalker(
            SemanticModel semanticModel,
            CancellationToken cancellationToken)
            : base(SyntaxWalkerDepth.Node)
        {
            _semanticModel = semanticModel;
            _cancellationToken = cancellationToken;
        }

        public override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            TryAddType(node);
            base.VisitIdentifierName(node);
        }

        public override void VisitGenericName(GenericNameSyntax node)
        {
            TryAddType(node);
            base.VisitGenericName(node);
        }

        public override void VisitQualifiedName(QualifiedNameSyntax node)
        {
            TryAddType(node);
            base.VisitQualifiedName(node);
        }

        public override void VisitObjectCreationExpression(ObjectCreationExpressionSyntax node)
        {
            TryAddType(node.Type);
            base.VisitObjectCreationExpression(node);
        }

        public override void VisitVariableDeclaration(VariableDeclarationSyntax node)
        {
            TryAddType(node.Type);
            base.VisitVariableDeclaration(node);
        }

        public override void VisitParameter(ParameterSyntax node)
        {
            TryAddType(node.Type);
            base.VisitParameter(node);
        }

        public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            TryAddType(node.ReturnType);
            base.VisitMethodDeclaration(node);
        }

        private void TryAddType(SyntaxNode? node)
        {
            if (node == null)
                return;

            var symbol = _semanticModel.GetSymbolInfo(node, _cancellationToken).Symbol
                      ?? _semanticModel.GetTypeInfo(node, _cancellationToken).Type;

            if (symbol is INamedTypeSymbol namedType &&
                (namedType.TypeKind == TypeKind.Class ||
                 namedType.TypeKind == TypeKind.Enum ||
                 namedType.TypeKind == TypeKind.Interface))
            {
                _results.Add(namedType);
            }
        }
    }
}
