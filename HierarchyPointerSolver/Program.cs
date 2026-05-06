using HierarchyPointerSolver.Infrastructure;
using HierarchyPointerSolver.Services;


class Program
{
	static void Main()
	{
		var input = JsonFileReader.Read("input.json");

		var hierarchyService = new HierarchyService();
		var structureService = new StructureService();
		var resolver = new ResolverService();

		// Flatten hierarchy
		var flatHierarchy = hierarchyService.Flatten(input.Hierarchy.RootNodes);

		// Build parent map
		var parentMap = hierarchyService.BuildParentMap(input.Hierarchy.RootNodes);

		// Build rules
		var ruleMap = structureService.BuildRuleMap(input.Structure.RootNodes);

		// Resolve
		var result = resolver.Resolve(flatHierarchy, ruleMap, parentMap);

		// Output
		var json = System.Text.Json.JsonSerializer.Serialize(new { Nodes = result },
			new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

		File.WriteAllText("output.json", json);

		Console.WriteLine("Done 🚀 Output generated!");
	}
}