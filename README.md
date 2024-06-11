# binary-tree-api_dotnet


 ## Technologies
  <ul>
    <li>C# 12; ASP.NET Core 8</li>
    <li>.NET SDK Version: 8.0.101</li>
  </ul>

 ## 01. Setup
### 01.01. Init setutp

### 02. Zrozumienie i implementacja drzew

  02. [x] Podstawowa implementacja drzewa

  Zadanie:

  - Utworzyć węzeł dla hierarchicznej struktury,
    dla organizacji istnieje jeden korzeń.
    Węzeł nie jest ograniczony stopniem, może posiadać wiele dzieci.
  
  - Zbudować strukturę drzewiastą z definicją korzenia oraz 
    z metodą umożliwiającą przechodzenie przez całe drzewo.

  - Serwis powinien być w stanie przetworzyć dane wejściowe 
    w formacie JSON reprezentujące drzewo binarne
    i zwrócić przetworzone drzewo w formacie JSON.


  - [x] Implementacja rozwiązania

Request POST:
    http://{{localhost}}:{{port}}/api/binarynodestr/negate

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
    http://{{localhost}}:{{port}}/api/binarynodeint/negate

  {
    "value": 42, "left": { "value": 40, "left": null, "right": null},
     "right": { "value": 47, "left": { "value": 45, "left": null, "right": null}, "right": null}
  }

  - [x] Implementacja przy pomocy kolejki Queue

