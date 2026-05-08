Hierarchy Pointer Solver – Developer Challenge (Tensor PLC)

	Overview

This project is my solution to the Tensor PLC Backend Developer Challenge. The task involves analysing a
Structure definition and a Hierarchy definition, then determining which nodes in the hierarchy require an
Ancestor Pointer, based on rules defined in the structure. The output is a JSON file listing all hierarchy
nodes that must point to an ancestor node.


	Problem Summary

Tensor provides two JSON inputs:

	1. Structure JSON
Defines:
	Valid entity types
	Allowed parent/child relationships
	Which entity types require an ancestor pointer
	The shape of the hierarchy (important)

Example:
	Team under Department has an AncestorPointerNodeId = 2 (Site)
	Team directly under Site does not have a pointer rule

	2. Hierarchy JSON
Represents the actual organisation tree:

Company → Sites → Departments → Sections/Teams

	The goal is to:

Walk the hierarchy
Apply the pointer rules from the structure
Output only the nodes that match the rule and match the structure’s shape


	How to Run
Clone the repository
Open in Visual Studio 
Ensure input.json is in the project root
Run the console application
output.json will be generated in the same directory


	Technologies Used
C# (.NET 8)
JSON serialization (System.Text.Json)
Recursive tree traversal
Clean architecture (Services + Models + Infrastructure)