using System.Text.Json;
using HierarchyPointerSolver.Models;

namespace HierarchyPointerSolver.Infrastructure
{
	public class JsonFileReader
	{
		public static InputRoot Read(string fileName)
		{
			string basePath = AppDomain.CurrentDomain.BaseDirectory;
			string projectPath = Path.GetFullPath(Path.Combine(basePath, @"..\..\..\"));
			string path = Path.Combine(projectPath, fileName);

			if (!File.Exists(path))
				throw new FileNotFoundException($"Missing file: {path}");

			string json = File.ReadAllText(path);
			InputRoot? result = JsonSerializer.Deserialize<InputRoot>(json);
			return result ?? throw new Exception("Invalid JSON format");
		}
	}
}
