# Welcome to AJ Gebara's Spreetail Take Home Project

## What is the App?

This a Command-Line Interface (CLI) app, where you can work with a Dictionary data structure stored in memory. 
This dictionary is a key/value store that takes a string for the key and a string for the member (value). The member is stored in a HashSet data structure.

## List of Commands

| Command       | Parameters          | Example                    | Description                                            |
|---------------|---------------------|----------------------------|--------------------------------------------------------|
| ADD           | `<key> <member>`    | `ADD Batman Joker`         | Adds a key and member pair to dictionary               |
| KEYS          | *No parameters*     | `KEYS`                     | Returns list of keys                                   |
| MEMBERS       | `<key>`             | `MEMBERS Batman`           | Returns members of a specific key                      |
| REMOVE        | `<key> <member>`    | `REMOVE Batman Joker`      | Removes a specific member from a key                   |
| REMOVEALL     | `<key>`             | `REMOVEALL Batman`         | Removes all members in a key, including the key itself |
| CLEAR         | *No parameters*     | `CLEAR`                    | Removes all key and member pairs in dictionary         |
| KEYEXISTS     | `<key>`             | `KEYEXISTS Batman`         | Returns true if key exists in dictionary               |
| MEMBEREXISTS  | `<key> <member>`    | `MEMBEREXISTS Batman Joker`| Returns true if member exists in a key                 |
| ALLMEMBERS    | *No parameters*     | `ALLMEMBERS`               | Returns all members in the dictionary                  |
| ITEMS         | *No parameters*     | `ITEMS`                    | Returns all key and member pairs in dictionary         |
| EXIT          | *No parameters*     | `EXIT`                     | Closes application                                     |


## Constraints

* Traditionally, the elements of a dictionary are called keys and values. In this app, the term "members" is used to refer to what are typically known as values
* Commands are case-sensitive. They must be uppercase
* Keys and Members must be one word. Ex: `ADD Batman Mr.Freeze` not `ADD Batman Mr. Freeze`

## How do you get the app & unit tests running?

1. Ensure you have Visual Studio 2022 installed with the .NET SDK.
2. Clone the repository.
3. Open Visual Studio.
4. Open the Project/Solution.
5. In the "Developer Command Prompt", run `dotnet restore` to restore all NuGet packages.
6. To open Developer Command Prompt go to "Tools" > "Command Line" > "Developer Command Prompt"
7. Build the project by right-clicking on `Spreetail_Take_Home_Proj.sln` and selecting `Build`, or use `dotnet build` in the Developer Command Prompt.
8. To run unit tests, enter `dotnet test` in the Developer Command Prompt.
9. To run the app, click on the Start button with the green arrow. Ensure the startup project is set to either `CLI_App.csproj` or `CLI_App` (if in the solution file).

## Future Iterations & Areas of Improvement