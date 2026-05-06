using HierarchyPointerSolver.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HierarchyPointerSolver.Interfaces
{
	public interface IHierarchyService
	{
		List<HierarchyNode> Flatten(List<HierarchyNode> nodes);
		Dictionary<string, string> BuildParentMap(List<HierarchyNode> nodes);
	}
}
