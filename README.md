# binary-tree-api_dotnet


 ## Technologies
  <ul>
    <li>C# 12; ASP.NET Core 8</li>
    <li>.NET SDK Version: 8.0.101</li>
  </ul>

 ## 01. Setup
### 01.01. Init setutp

### 02. Understanding and implementing trees

  02. [x] Basic tree implementation

Task:

 - Create a node for a hierarchical structure,
 there is one root for the organization.
 A node is not limited by degree and can have many children.

 - Build a tree structure with the definition of the root and
 with a method that allows traversal of the entire tree.

 - The website should be able to process the input data
 in JSON format representing a binary tree
 and return the processed tree in JSON format.


 - [x] Implementation of the solution

Request POST:
    http://13.95.214.25:8080/api/binarynodestr/negate

{
  "value": "A",
  "left": 
    { "value": "B", "left": null, "right": 
        { "value": "D", "left": null, "right": null, "parent": null }, "parent": null },
  "right": 
    { "value": "C", "left": 
        { "value": "D", "left": null, "right": null, "parent": null },
      "right": 
        { "value": "E", "left": null, "right": null, "parent": null },
      "parent": null },
  "parent": null
}

Response:

{ "Value": "E" }, { "Value": "C", "Left": { "Value": "E" }, "Right": { "Value": "D" } }, { "Value": "D" },
{ "Value": "A", "Left": { "Value": "C", "Left": { "Value": "E" }, "Right": { "Value": "D" }},
    "Right": { "Value": "B", "Left": { "Value": "D" }}},
{ "Value": "D" }, { "Value": "B", "Left": { "Value": "D" } }


  Request POST:
    http://13.95.214.25:8080/api/binarynodeint/negate

  {
    "value": 42, "left": { "value": 40, "left": null, "right": null},
     "right": { "value": 47, "left": { "value": 45, "left": null, "right": null}, "right": null}
  }

- [x] Implementation using Queue
