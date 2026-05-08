namespace HierarchyPointerSolver.Models
{
	public class PointerRule
	{
		public string? EntityType { get; set; }        
		public string? TargetType { get; set; }          
		public List<string>? PathTypes { get; set; }     
	}
}
