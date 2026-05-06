using HierarchyPointerSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyPointerSolver.Services
{

	public class StructureService
	{
		public Dictionary<string, string> BuildRuleMap(List<StructureNode> nodes)
		{
			var map = new Dictionary<string, string>();

			void Traverse(List<StructureNode> list)
			{
				foreach (var node in list)
				{
					if (!string.IsNullOrEmpty(node.AncestorPointerNodeId))
					{
						var childType = node.EntityType;
						var parentNode = FindNode(nodes, node.AncestorPointerNodeId);

						map[childType] = parentNode.EntityType;
					}

					if (node.Children != null && node.Children.Any())
						Traverse(node.Children);
				}
			}

			Traverse(nodes);
			return map;
		}

		private StructureNode FindNode(List<StructureNode> nodes, string id)
		{
			foreach (var node in nodes)
			{
				if (node.StructureNodeId == id)
					return node;

				if (node.Children != null)
				{
					var found = FindNode(node.Children, id);
					if (found != null) return found;
				}
			}

			return null;
		}
	}
}
