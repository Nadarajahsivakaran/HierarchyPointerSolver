using HierarchyPointerSolver.Models;

namespace HierarchyPointerSolver.Services
{
	public class StructureService
	{

		public static Dictionary<string, (string TargetType, List<string> PathTypes)> BuildRuleMap(List<StructureNode> roots)
		{
			var map = new Dictionary<string, (string, List<string>)>();

			List<StructureNode> path = [];

			void Traverse(List<StructureNode> nodes)
			{
				foreach (var node in nodes)
				{
					path.Add(node);

					if (!string.IsNullOrEmpty(node.AncestorPointerNodeId))
					{
						int ancestorIndex = path.FindIndex(p => p.StructureNodeId == node.AncestorPointerNodeId);
						if (ancestorIndex >= 0)
						{
							StructureNode ancestorNode = path[ancestorIndex];
							string targetType = ancestorNode.EntityType;

							List<string> pathTypes = [.. path.Skip(ancestorIndex + 1).Select(p => p.EntityType)];
							map[node.EntityType] = (targetType, pathTypes);
						}
					}

					if (node.Children != null && node.Children.Count != 0)
						Traverse(node.Children);

					path.RemoveAt(path.Count - 1);
				}
			}

			Traverse(roots);
			return map;
		}
	}
}
