using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.FindSymbols;

namespace CodeParsingNet9.CodeManipulator
{
    public class BuildSimpleClassInputDto {
        public readonly string ClassName;
        public List<string> PropertyNames = new List<string>();
        public List<string> PropertyTypes = new List<string>();
        public List<string> FieldNames = new List<string>();
        public List<string> FieldTypes = new List<string>();
        public List<string> FieldDefaults = new List<string>();

        public BuildSimpleClassInputDto(string className)
        {
            ClassName = className;
        }

        public void Validate()
        {
            if (PropertyNames.Count != PropertyTypes.Count) throw new Exception("BuildSimpleClassInputDto: PropertyNames.Count != PropertyTypes.Count");
            if (FieldNames.Count != FieldTypes.Count) throw new Exception("BuildSimpleClassInputDto: FieldNames.Count != FieldTypes.Count");
            if (FieldNames.Count != FieldDefaults.Count) throw new Exception("BuildSimpleClassInputDto: FieldNames.Count != FieldDefaults.Count");
        }
    }

    public partial class CodeManipulator
    {
        public ClassDeclarationSyntax BuildSimpleClass0(BuildSimpleClassInputDto inputDto)
        {
            /*
            // Example
            public class ClassName {
                public AddressModel AddressModel { get; set; }
                public Temperature Temperature = new Temperature(25);
            }
            */

            // Create the class declaration
            var classDeclaration = ClassDeclaration(inputDto.ClassName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword));

            // Create each property
            for (int i = 0; i < inputDto.PropertyNames.Count; i++)
            {
                var propertyType = inputDto.PropertyTypes[i];
                var propertyName = inputDto.PropertyNames[i];

                // Use IdentifierName for non-predefined types
                TypeSyntax typeSyntax = propertyType switch
                {
                    "string" => PredefinedType(Token(SyntaxKind.StringKeyword)),
                    "int" => PredefinedType(Token(SyntaxKind.IntKeyword)),
                    "bool" => PredefinedType(Token(SyntaxKind.BoolKeyword)),
                    "double" => PredefinedType(Token(SyntaxKind.DoubleKeyword)),
                    "float" => PredefinedType(Token(SyntaxKind.FloatKeyword)),
                    "decimal" => PredefinedType(Token(SyntaxKind.DecimalKeyword)),
                    "object" => PredefinedType(Token(SyntaxKind.ObjectKeyword)),
                    _ => IdentifierName(propertyType)
                };

                var propertyDeclaration =
                    PropertyDeclaration(typeSyntax, Identifier(propertyName))
                        .AddModifiers(Token(SyntaxKind.PublicKeyword))
                        .AddAccessorListAccessors(
                            AccessorDeclaration(SyntaxKind.GetAccessorDeclaration)
                                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken)),
                            AccessorDeclaration(SyntaxKind.SetAccessorDeclaration)
                                .WithSemicolonToken(Token(SyntaxKind.SemicolonToken))
                        );

                classDeclaration = classDeclaration.AddMembers(propertyDeclaration);
            }

            return classDeclaration.NormalizeWhitespace();
        }

        public ClassDeclarationSyntax BuildSimpleClass1(BuildSimpleClassInputDto inputDto)
        {
            /*
            // Example
            public class ClassName {
                public AddressModel AddressModel { get; set; }
                public Temperature Temperature = new Temperature(25);
            }
            */

            // Create the class declaration
            var classDeclaration = ClassDeclaration(inputDto.ClassName)
                .AddModifiers(Token(SyntaxKind.PublicKeyword));

            // Create each property
            for (int i = 0; i < inputDto.PropertyNames.Count; i++)
            {
                string propertyType = inputDto.PropertyTypes[i];
                string propertyName = inputDto.PropertyNames[i];

                string propertyLine = "public " + propertyType + " " + propertyName + " { get; set; }";
                var rawMember = ParseMemberDeclaration(propertyLine);
                if (rawMember == null) throw new Exception("invalid parse: " + propertyLine);

                classDeclaration = classDeclaration.AddMembers(rawMember);
            }

            // create each public field
            for (int i = 0; i < inputDto.FieldNames.Count; i++)
            {
                string fieldType = inputDto.FieldTypes[i];
                string fieldName = inputDto.FieldNames[i];
                string fieldDefault = inputDto.FieldDefaults[i];

                string fieldAssignment = "";
                if (string.IsNullOrEmpty(fieldDefault))
                {
                    fieldAssignment = " = " + fieldDefault;
                }

                string fieldLine = "public " + fieldType + " " + fieldName + fieldAssignment + ";";
                var rawMember = ParseMemberDeclaration(fieldLine);
                if (rawMember == null) throw new Exception("invalid parse: " + fieldLine);

                classDeclaration = classDeclaration.AddMembers(rawMember);
            }

            return classDeclaration.NormalizeWhitespace();
        }
    }
}
