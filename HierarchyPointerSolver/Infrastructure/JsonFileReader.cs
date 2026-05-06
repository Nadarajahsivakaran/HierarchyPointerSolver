using System.Text.Json;
using HierarchyPointerSolver.Models;

namespace HierarchyPointerSolver.Infrastructure;

public class JsonFileReader
{
	public static InputRoot Read(string fileName)
	{
		var path = Path.Combine(AppContext.BaseDirectory, fileName);

		if (!File.Exists(path))
			throw new FileNotFoundException($"Missing file: {path}");

		var json = File.ReadAllText(path);

		var result = JsonSerializer.Deserialize<InputRoot>(json);

		if (result == null)
			throw new Exception("Invalid JSON format");

		return result;
	}
}