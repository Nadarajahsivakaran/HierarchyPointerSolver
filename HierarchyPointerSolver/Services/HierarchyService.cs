using HierarchyPointerSolver.Interfaces;
using HierarchyPointerSolver.Models;

namespace HierarchyPointerSolver.Services
{
	public class HierarchyService : IHierarchyService
	{
		public List<HierarchyNode> Flatten(List<HierarchyNode> nodes)
		{
			List<HierarchyNode> result = [];

			foreach (HierarchyNode node in nodes)
			{
				result.Add(node);

				if (node.Children != null && node.Children.Count != 0)
					result.AddRange(Flatten(node.Children));
			}

			return result;
		}

		public Dictionary<string, string> BuildParentMap(List<HierarchyNode> nodes)
		{
			Dictionary<string, string> map = [];

			void Traverse(List<HierarchyNode> list, string? parentId)
			{
				foreach (HierarchyNode node in list)
				{
					if (parentId != null)
						map[node.HierarchyNodeId] = parentId;

					if (node.Children != null && node.Children.Count != 0)
						Traverse(node.Children, node.HierarchyNodeId);
				}
			}

			Traverse(nodes, null);
			return map;
		}
	}
}
