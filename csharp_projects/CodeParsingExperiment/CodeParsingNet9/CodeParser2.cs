using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.CodeAnalysis.FindSymbols;

namespace CodeParsingNet9
{
    public class CodeParser2
    {
        /*
        public async Task TestParse()
        {
            var projectPath = @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\CodeParsingExperiment\Utility\Utility.csproj";

            // Ensure MSBuild can find the right tools
            Microsoft.Build.Locator.MSBuildLocator.RegisterDefaults();

            using var workspace = MSBuildWorkspace.Create();

            Console.WriteLine("Loading project...");
            var project = await workspace.OpenProjectAsync(projectPath);

            Console.WriteLine($"Loaded project: {project.Name}");
            Console.WriteLine($"Documents: {project.Documents.Count()}");

            foreach (var doc in project.Documents)
            {
                Console.WriteLine($"\n--- Document: {doc.Name} ---");
                Console.WriteLine($"{doc.FilePath}");

                var tree = await doc.GetSyntaxTreeAsync();
                if (tree == null)
                {
                    continue;
                }
                var root = await tree.GetRootAsync();

                Console.WriteLine($"Root kind: {root.Kind()}");

                var model = await doc.GetSemanticModelAsync();

                // Example: print all class declarations and their symbols
                var classNodes = root.DescendantNodes().OfType<Microsoft.CodeAnalysis.CSharp.Syntax.ClassDeclarationSyntax>();

                foreach (var cls in classNodes)
                {
                    var symbol = model.GetDeclaredSymbol(cls);
                    Console.WriteLine($"Class: {symbol?.Name}, Namespace: {symbol?.ContainingNamespace}");
                }
            }

            Console.WriteLine("Done!");
        }

        public async Task MoveClassAndUpdateAllImports(string srcFilePath, string className, string dstFilePath)
        {
            
        }

        private static async Task SaveDocumentAsync(Document document)
        {
            var newText = await document.GetTextAsync();
            await File.WriteAllTextAsync(document.FilePath, newText.ToString());
        }



        public async Task RenameClassAndReferences()
        {

        }
        */
    }
}
