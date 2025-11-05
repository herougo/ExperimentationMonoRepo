// See https://aka.ms/new-console-template for more information

using CodeParsingNet9.CodeManipulator;
using CodeParsingNet9.Utility;
;

Console.WriteLine("Hello, World!");

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



/*
await parser.MoveClassAndUpdateAllImports(
    @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\CodeParsingExperiment\Utility\Dependencies\ClassDependency.cs",
    "ClassDependency",
    @"C:\Users\henri\Documents\01 - Backup 1 - MSI\03 - Active Program Data\IDE\Visual Studio 2022\CodeParsingExperiment\Utility\Dependencies2\ClassDependency.cs"
);
*/

Console.WriteLine("Done");

Console.ReadLine();
