using HierarchyPointerSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyPointerSolver.Services
{
	public class ResolverService
	{
		private Dictionary<string, string> parentMap;
		private Dictionary<string, HierarchyNode> nodeMap;

		public List<OutputNode> Resolve(
			List<HierarchyNode> flatNodes,
			Dictionary<string, string> ruleMap,
			Dictionary<string, string> parentMapInput)
		{
			parentMap = parentMapInput;
			nodeMap = flatNodes.ToDictionary(x => x.HierarchyNodeId);

			var result = new List<OutputNode>();

			foreach (var node in flatNodes)
			{
				if (!ruleMap.ContainsKey(node.EntityType))
					continue;

				var targetType = ruleMap[node.EntityType];
				var ancestor = FindAncestor(node.HierarchyNodeId, targetType);

				if (ancestor != null)
				{
					result.Add(new OutputNode
					{
						HierarchyNodeId = node.HierarchyNodeId,
						PointerHierarchyPointerNodeId = ancestor
					});
				}
			}

			return result;
		}

		private string FindAncestor(string nodeId, string targetType)
		{
			var current = nodeId;

			while (parentMap.ContainsKey(current))
			{
				var parentId = parentMap[current];
				var parent = nodeMap[parentId];

				if (parent.EntityType == targetType)
					return parent.HierarchyNodeId;

				current = parentId;
			}

			return null;
		}
	}
}
