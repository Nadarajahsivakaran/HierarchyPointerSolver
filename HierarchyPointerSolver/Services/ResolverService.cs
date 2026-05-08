using HierarchyPointerSolver.Models;

namespace HierarchyPointerSolver.Services
{
	public class ResolverService
	{
		private Dictionary<string, string>? parentMap;
		private Dictionary<string, HierarchyNode>? nodeMap;

		public List<OutputNode> Resolve(
			List<HierarchyNode> flatNodes,
			Dictionary<string, (string TargetType, List<string> PathTypes)> ruleMap,
			Dictionary<string, string> parentMapInput)
		{
			parentMap = parentMapInput;
			nodeMap = flatNodes.ToDictionary(x => x.HierarchyNodeId);

			List<OutputNode> result = [];

			foreach (var node in flatNodes)
			{
				if (!ruleMap.ContainsKey(node.EntityType))
					continue;

				var (targetType, expectedPathTypes) = ruleMap[node.EntityType];

				string? ancestorId = FindAncestorOfType(node.HierarchyNodeId, targetType);
				if (ancestorId == null)
					continue;

				List<string> actualPathTypes = GetPathTypesBetween(ancestorId, node.HierarchyNodeId);

	
				if (!PathMatches(expectedPathTypes, actualPathTypes))
					continue;

				result.Add(new OutputNode
				{
					HierarchyNodeId = node.HierarchyNodeId,
					PointerHierarchyPointerNodeId = ancestorId
				});
			}

			return result;
		}

		private string? FindAncestorOfType(string nodeId, string targetType)
		{
			string current = nodeId;

			while (parentMap!.ContainsKey(current))
			{
				string parentId = parentMap[current];
				HierarchyNode parent = nodeMap![parentId];

				if (parent.EntityType == targetType)
					return parent.HierarchyNodeId;

				current = parentId;
			}

			return null;
		}

		private List<string> GetPathTypesBetween(string ancestorId, string nodeId)
		{
			List<string> types = [];
			string current = nodeId;

			while (parentMap!.ContainsKey(current))
			{
				string parentId = parentMap[current];
				if (parentId == ancestorId)
					break;

				HierarchyNode parent = nodeMap![parentId];
				types.Add(parent.EntityType);
				current = parentId;
			}

			types.Reverse(); 
			types.Add(nodeMap![nodeId].EntityType);
			return types;
		}

		private static bool PathMatches(List<string> expected, List<string> actual)
		{
			if (expected.Count != actual.Count)
				return false;

			for (int i = 0; i < expected.Count; i++)
			{
				if (!string.Equals(expected[i], actual[i], StringComparison.Ordinal))
					return false;
			}

			return true;
		}
	}
}
