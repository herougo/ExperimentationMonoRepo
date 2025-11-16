using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using Microsoft.CodeAnalysis.FindSymbols;

namespace CodeParsingNet9.Unused
{
    public class ClassMover
    {
        /*
        public async Task MoveClassAndUpdateAllImports(string srcFilePath, string className, string dstFilePath)
        {
            var projectPath = @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\CodeParsingExperiment\Utility\Utility.csproj";

            if (!MSBuildLocator.IsRegistered) MSBuildLocator.RegisterDefaults();

            using var workspace = MSBuildWorkspace.Create();
            Console.WriteLine("Loading project...");
            var project = await workspace.OpenProjectAsync(projectPath);
            Console.WriteLine($"Loaded project: {project.Name}");

            // find source document
            var srcDoc = project.Documents.FirstOrDefault(d =>
                string.Equals(d.FilePath, srcFilePath, StringComparison.OrdinalIgnoreCase));

            if (srcDoc == null)
            {
                Console.WriteLine($"Source file not found: {srcFilePath}");
                return;
            }

            var srcRoot = await srcDoc.GetSyntaxRootAsync() as CompilationUnitSyntax;
            if (srcRoot == null)
            {
                Console.WriteLine("Could not get syntax root for source.");
                return;
            }

            // find the class declaration
            var classNode = srcRoot.DescendantNodes()
                .OfType<ClassDeclarationSyntax>()
                .FirstOrDefault(c => c.Identifier.Text == className);

            if (classNode == null)
            {
                Console.WriteLine($"Class '{className}' not found in {srcFilePath}");
                return;
            }

            // find its containing namespace (if any)
            var namespaceDecl = classNode.Ancestors().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
            var namespaceName = namespaceDecl?.Name.ToString() ?? "";

            Console.WriteLine($"Found class '{className}' in namespace '{namespaceName}'.");

            // Remove the class node from source root.
            // If it's inside a namespace, replace that namespace with a version that has the class removed.
            CompilationUnitSyntax newSrcRoot;
            if (namespaceDecl != null)
            {
                var newNamespace = namespaceDecl.RemoveNode(classNode, SyntaxRemoveOptions.KeepNoTrivia);
                newSrcRoot = srcRoot.ReplaceNode(namespaceDecl, newNamespace);
            }
            else
            {
                // top-level class
                newSrcRoot = srcRoot.RemoveNode(classNode, SyntaxRemoveOptions.KeepNoTrivia);
            }

            // update source document in solution
            var solution = srcDoc.Project.Solution;
            var newSrcDoc = srcDoc.WithSyntaxRoot(newSrcRoot);
            solution = newSrcDoc.Project.Solution;

            // handle destination document (create if needed)
            var dstDoc = solution.Projects
                .SelectMany(p => p.Documents)
                .FirstOrDefault(d => string.Equals(d.FilePath, dstFilePath, StringComparison.OrdinalIgnoreCase));

            if (dstDoc != null)
            {
                var dstRoot = await dstDoc.GetSyntaxRootAsync() as CompilationUnitSyntax;
                if (dstRoot == null)
                {
                    Console.WriteLine("Could not get syntax root for destination.");
                    return;
                }

                // If destination has a namespace matching namespaceName, add the class there.
                // Otherwise add a new namespace + class to the compilation unit.
                if (!string.IsNullOrWhiteSpace(namespaceName))
                {
                    var dstNamespace = dstRoot.DescendantNodes().OfType<NamespaceDeclarationSyntax>()
                                              .FirstOrDefault(n => n.Name.ToString() == namespaceName);

                    if (dstNamespace != null)
                    {
                        var newDstNamespace = dstNamespace.AddMembers(classNode);
                        var newDstRoot = dstRoot.ReplaceNode(dstNamespace, newDstNamespace);
                        dstDoc = dstDoc.WithSyntaxRoot(newDstRoot);
                    }
                    else
                    {
                        // create namespace and add it to compilation unit
                        var newNamespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(namespaceName))
                                                        .WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(classNode))
                                                        .NormalizeWhitespace();

                        var newDstRoot = dstRoot.AddMembers(newNamespace);
                        dstDoc = dstDoc.WithSyntaxRoot(newDstRoot);
                    }
                }
                else
                {
                    // top-level class, add directly to compilation unit
                    var newDstRoot = dstRoot.AddMembers(classNode);
                    dstDoc = dstDoc.WithSyntaxRoot(newDstRoot);
                }

                solution = dstDoc.Project.Solution;
            }
            else
            {
                // destination file does not exist in solution -> create a new document (in same project as source)
                var containingProject = newSrcDoc.Project; // choose same project as source
                CompilationUnitSyntax dstCompilation;

                if (!string.IsNullOrWhiteSpace(namespaceName))
                {
                    var newNamespace = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(namespaceName))
                                                    .WithMembers(SyntaxFactory.SingletonList<MemberDeclarationSyntax>(classNode))
                                                    .NormalizeWhitespace();

                    dstCompilation = SyntaxFactory.CompilationUnit().AddMembers(newNamespace).NormalizeWhitespace();
                }
                else
                {
                    dstCompilation = SyntaxFactory.CompilationUnit().AddMembers(classNode).NormalizeWhitespace();
                }

                var docName = Path.GetFileName(dstFilePath);
                var addedDoc = containingProject.AddDocument(docName, dstCompilation, folders: null, filePath: dstFilePath);
                solution = addedDoc.Project.Solution;
            }

            // refresh project/compilation after above changes
            project = solution.GetProject(newSrcDoc.Project.Id) ?? solution.Projects.First(); // best-effort
            var compilation = await project.GetCompilationAsync();

            // get the moved class symbol by namespace+name (if namespace empty try by name)
            INamedTypeSymbol classSymbol = null;
            if (!string.IsNullOrWhiteSpace(namespaceName))
            {
                classSymbol = compilation.GetTypeByMetadataName($"{namespaceName}.{className}");
            }
            if (classSymbol == null)
            {
                // fallback: search by name in compilation
                classSymbol = compilation.GlobalNamespace.GetNamespaceMembers()
                    .SelectMany(n => n.GetTypeMembers(className))
                    .FirstOrDefault() ?? compilation.GetTypeByMetadataName(className);
            }

            if (classSymbol == null)
            {
                Console.WriteLine("Warning: moved class symbol could not be resolved in compilation. Usings will still be added heuristically.");
            }
            else
            {
                // find references across the solution
                var refs = await SymbolFinder.FindReferencesAsync(classSymbol, solution);

                foreach (var r in refs)
                {
                    foreach (var loc in r.Locations)
                    {
                        var refDoc = solution.GetDocument(loc.Document.Id);
                        if (refDoc == null) continue;

                        var refRoot = await refDoc.GetSyntaxRootAsync() as CompilationUnitSyntax;
                        if (refRoot == null) continue;

                        // if the referencing document already has 'using namespaceName' skip
                        if (!string.IsNullOrWhiteSpace(namespaceName) &&
                            !refRoot.Usings.Any(u => u.Name.ToString() == namespaceName))
                        {
                            var usingDirective = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(namespaceName));
                            var newRefRoot = refRoot.AddUsings(usingDirective);
                            refDoc = refDoc.WithSyntaxRoot(newRefRoot);
                            solution = refDoc.Project.Solution;
                        }
                    }
                }
            }

            // As a fallback, also add using to any docs in solution that reference the type name as an identifier (best-effort).
            // (This helps if symbol lookup failed due to partial compilation state.)
            foreach (var proj in solution.Projects)
            {
                foreach (var doc in proj.Documents)
                {
                    var rRoot = await doc.GetSyntaxRootAsync() as CompilationUnitSyntax;
                    if (rRoot == null) continue;

                    // if doc already has using, skip
                    if (!string.IsNullOrWhiteSpace(namespaceName) &&
                        rRoot.Usings.Any(u => u.Name.ToString() == namespaceName)) continue;

                    // cheap heuristic: look for identifier with the same name
                    if (rRoot.DescendantTokens().Any(t => t.IsKind(SyntaxKind.IdentifierToken) && t.ValueText == className))
                    {
                        var usingDirective = SyntaxFactory.UsingDirective(SyntaxFactory.ParseName(namespaceName));
                        var newRoot = rRoot.AddUsings(usingDirective);
                        var newDoc = doc.WithSyntaxRoot(newRoot);
                        solution = newDoc.Project.Solution;
                    }
                }
            }

            // apply changes to workspace (synchronous)
            var applied = workspace.TryApplyChanges(solution);
            if (!applied)
            {
                Console.WriteLine("Failed to apply changes to workspace.");
                return;
            }

            // Persist changed documents to disk
            foreach (var proj in solution.Projects)
            {
                foreach (var doc in proj.Documents)
                {
                    if (string.IsNullOrWhiteSpace(doc.FilePath)) continue;
                    var text = await doc.GetTextAsync();
                    // save file only if changed or exists; simple approach: overwrite
                    await File.WriteAllTextAsync(doc.FilePath, text.ToString());
                }
            }

            Console.WriteLine("Class moved and imports updated successfully.");
        }
        */
    }
}

