TestAmiramAbergel - Windows Controller Application
===================================================

This is a simple Windows Controller application written in C#. It allows users to:

1. Show a list of windows details
2. Set a window to be minimized.
3. Abort the minimize of a window
4. Close the app and exit

Getting Started
---------------
1. Install .NET SDK: https://dotnet.microsoft.com/download/dotnet

2. Navigate to the project Main directory:
   cd TestAmiramAbergel
      

Project Structure
-----------------
The project is divided into the following directories:

1. TestAmiramAbergel - The main project directory:
 - Program.cs: The main entry point of the application.
 - Utils.cs: A utility class that contains helper methods.

2. WindowsMamagement - The Windows Management project directory:
 - Window.cs: Contains the Window class responsible for managing a single window's details and actions.
 - WindowController.cs - Contains the WindowController class responsible for managing windows and their actions.
 - Utils.cs: A utility class that contains helper methods.

3. Tests - The Tests project directory:
 - WindowControllerTests.cs: Contains the WindowControllerTests class responsible for testing the WindowController class.

4. interview-task.sln - The solution file.


How to Run
----------
1. Navigate to the main project directory (if not already there):
   cd TestAmiramAbergel

2. Build the project:
   dotnet build

3. Run the application:
   dotnet run Or dotnet run --project TestAmiramAbergel.csproj


