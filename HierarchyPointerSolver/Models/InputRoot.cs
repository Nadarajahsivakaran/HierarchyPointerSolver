using System.Text.Json.Serialization;

namespace HierarchyPointerSolver.Models
{
	public class InputRoot
	{
		public StructureWrapper? Structure { get; set; }
		public HierarchyWrapper? Hierarchy { get; set; }
	}

	public class StructureWrapper
	{
		[JsonPropertyName("Root Nodes")]
		public List<StructureNode>? RootNodes { get; set; }
	}

	public class HierarchyWrapper
	{
		[JsonPropertyName("Root Nodes")]
		public List<HierarchyNode>? RootNodes { get; set; }
	}
}
