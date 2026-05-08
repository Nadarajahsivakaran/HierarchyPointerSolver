using HierarchyPointerSolver.Models;

namespace HierarchyPointerSolver.Interfaces
{
	public interface IHierarchyService
	{
		List<HierarchyNode> Flatten(List<HierarchyNode> nodes);
		Dictionary<string, string> BuildParentMap(List<HierarchyNode> nodes);
	}
}
