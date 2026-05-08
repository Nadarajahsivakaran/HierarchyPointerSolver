namespace HierarchyPointerSolver.Models
{
	public class HierarchyNode
	{
		public string HierarchyNodeId { get; set; }
		public string EntityType { get; set; }
		public string Name { get; set; }
		public string ParentId { get; set; }
		public List<HierarchyNode> Children { get; set; } = [];
	}
}
