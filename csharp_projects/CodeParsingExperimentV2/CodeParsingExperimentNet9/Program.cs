// See https://aka.ms/new-console-template for more information

using CodeParsingNet9.CodeManipulator;
using CodeParsingNet9.CodeManipulator2;
using CodeParsingNet9.CodeManipulator2.StaticUtils;
using CodeParsingNet9.Utility;


Console.WriteLine("Hello, World!");
{


    var parser = new CodeManipulator(@"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\DummyNetFrameworkForAutoEdit\Utility\Utility.csproj");
    var src = @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\DummyNetFrameworkForAutoEdit\Utility\Dependencies\ClassDependency.cs";
    var dst = @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\DummyNetFrameworkForAutoEdit\Utility\Dependencies2\ClassDependency.cs";

    string className = "ClassDependency";

    if (false)
    {

        Console.WriteLine("Create document is not exists");
        parser.CreateDocumentIfNotExists(dst);
        Console.WriteLine("Moving source class to destination");
        parser.MoveClass(src, className, dst);
        Console.WriteLine("Formatting destination");
        parser.FormatDocument(dst);
        Console.WriteLine("Moving destination class back to source");
        parser.MoveClass(dst, className, src);
        Console.WriteLine("Formatting source");
        parser.FormatDocument(src);
        Console.WriteLine("Formatting destination");
        parser.FormatDocument(dst);
    }
    else if (false)
    {
        BuildSimpleClassInputDto dto = new BuildSimpleClassInputDto("MyClass");
        dto.PropertyNames = new List<string>() { "Address" };
        dto.PropertyTypes = new List<string>() { "AddressModel" };
        dto.FieldNames = new List<string>() { "Temperature" };
        dto.FieldTypes = new List<string>() { "Temperature" };
        dto.FieldDefaults = new List<string>() { "new Temperature(100)" };
        dto.Validate();
        var classDecl = parser.BuildSimpleClass1(dto);
        Console.WriteLine(classDecl.ToFullString());
    }

    if (false)
    {
        var graph = await parser.BuildMethodDependencyGraphAsync();
        var topogicalSort = parser.TopologicalSort(graph);
        var topologicalSortReversed = Utils.Clone(topogicalSort);
        topologicalSortReversed.Reverse();

        foreach (var node in topologicalSortReversed)
        {
            Console.WriteLine(node.MethodId);
            foreach (var neighbour in graph[node])
            {
                Console.WriteLine("\t" + neighbour.MethodId);
            }
        }
    }
}

var parser2 = new CodeManipulator2(@"C:\Users\henri\Documents\01 - Backup 1 - MSI\01 - Documents\00 - Main\Softlinx\DummyProject\src\DummyProject\DummyProject.sln");

if (false)
{
    var graph = await CodeUtils.BuildMethodDependencyGraphAsync(parser2.GetSolution(), parser2.GetCompilations());
    foreach (var node in graph.Keys)
    {
        Console.WriteLine(node.MethodId);
        foreach (var neighbour in graph[node])
        {
            Console.WriteLine("\t" + neighbour.MethodId);
        }
    }
}

if (true)
{
    var graph = await CodeUtils.BuildMethodDependencyGraphAsync(parser2.GetSolution(), parser2.GetCompilations());
    var project = parser2.GetProjectByName("Utility.Standard");
    var projectFramework = parser2.GetProjectByName("Utility");
    string srcClass1Path = Path.Combine(parser2.GetProjectFolder(projectFramework), "Class1.cs");
    string srcClass2Path = Path.Combine(parser2.GetProjectFolder(projectFramework), "Class2.cs");
    string dstClass1Path = Path.Combine(parser2.GetProjectFolder(project), "Util1\\Class1.cs");
    string dstClass2Path = Path.Combine(parser2.GetProjectFolder(project), "Util2\\Class2.cs");

    Console.WriteLine("Create " + dstClass1Path);
    parser2.CreateDocumentIfNotExists(dstClass1Path);
    Console.WriteLine("Creating Class1 class");
    parser2.CreateClass(dstClass1Path, "Class1");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass1Path);

    Console.WriteLine("Create " + dstClass2Path);
    parser2.CreateDocumentIfNotExists(dstClass2Path);
    Console.WriteLine("Creating Class2 class");
    parser2.CreateClass(dstClass2Path, "Class2");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass2Path);

    Console.WriteLine("Adding Method Method2");
    parser2.CopyMethod(srcClass2Path, "Class2", "Method2", dstClass2Path, "Class2");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass2Path);

    Console.WriteLine("Adding Method Method1");
    parser2.CopyMethod(srcClass1Path, "Class1", "Method1", dstClass1Path, "Class1");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass1Path);

    Console.WriteLine("Add Dependency Field");
    parser2.AddDependencyField(dstClass1Path, "Class1", "Class2");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass1Path);

    Console.WriteLine("Adding Dependencies " + dstClass1Path);
    parser2.AddMissingProjectDependencies(dstClass1Path);
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass1Path);

    // compilation should work

    Console.WriteLine("Remove static from Method1");
    parser2.RemoveStaticKeywordFromMethod(dstClass1Path, "Class1", "Method1");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass1Path);

    Console.WriteLine("Remove static from Method2");
    parser2.RemoveStaticKeywordFromMethod(dstClass2Path, "Class2", "Method2");
    Console.WriteLine("Formatting Document");
    parser2.FormatDocument(dstClass2Path);


}





/*
await parser.MoveClassAndUpdateAllImports(
    @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\CodeParsingExperiment\Utility\Dependencies\ClassDependency.cs",
    "ClassDependency",
    @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\CodeParsingExperiment\Utility\Dependencies2\ClassDependency.cs"
);
*/

Console.WriteLine("Done");

Console.ReadLine();
