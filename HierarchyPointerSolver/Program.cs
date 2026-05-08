using HierarchyPointerSolver.Infrastructure;
using HierarchyPointerSolver.Models;
using HierarchyPointerSolver.Services;

InputRoot input = JsonFileReader.Read("input.json");

var hierarchyService = new HierarchyService();
var resolver = new ResolverService();

List<HierarchyNode> flatHierarchy = hierarchyService.Flatten(input.Hierarchy.RootNodes);
Dictionary<string, string> parentMap = hierarchyService.BuildParentMap(input.Hierarchy.RootNodes);
var ruleMap = StructureService.BuildRuleMap(input.Structure.RootNodes);

List<OutputNode> result = resolver.Resolve(flatHierarchy, ruleMap, parentMap);

var json =
	System.Text.Json.JsonSerializer.Serialize(
		new { Nodes = result },
		new System.Text.Json.JsonSerializerOptions
		{
			WriteIndented = true
		});

string basePath = AppDomain.CurrentDomain.BaseDirectory;
string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
string outputPath = Path.Combine(projectPath, "output.json");

File.WriteAllText(outputPath, json);
Console.WriteLine($"Done 🚀 Output generated at: {outputPath}");
