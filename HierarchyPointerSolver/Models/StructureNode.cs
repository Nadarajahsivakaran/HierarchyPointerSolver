namespace HierarchyPointerSolver.Models
{
	public class StructureNode
	{
		public string StructureNodeId { get; set; }
		public string EntityType { get; set; }
		public string AncestorPointerNodeId { get; set; }
		public List<StructureNode> Children { get; set; } = new();
	}
}
