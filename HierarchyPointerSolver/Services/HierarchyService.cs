using HierarchyPointerSolver.Interfaces;
using HierarchyPointerSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyPointerSolver.Services
{
	public class HierarchyService : IHierarchyService
	{
		public List<HierarchyNode> Flatten(List<HierarchyNode> nodes)
		{
			var result = new List<HierarchyNode>();

			foreach (var node in nodes)
			{
				result.Add(node);

				if (node.Children != null && node.Children.Any())
					result.AddRange(Flatten(node.Children));
			}

			return result;
		}

		public Dictionary<string, string> BuildParentMap(List<HierarchyNode> nodes)
		{
			var map = new Dictionary<string, string>();

			void Traverse(List<HierarchyNode> list, string parentId)
			{
				foreach (var node in list)
				{
					if (parentId != null)
						map[node.HierarchyNodeId] = parentId;

					if (node.Children != null && node.Children.Any())
						Traverse(node.Children, node.HierarchyNodeId);
				}
			}

			Traverse(nodes, null);
			return map;
		}
	}
}
