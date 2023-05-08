using System;
using TestAmiramAbergel;
using WindowManagement;

/*
This program is a Windows Controller that allows the user to:
1. Show a list of windows details
2. Set a window to be minimized.
3. Abort the minimize of a window
4. Close the app and exit
*/

namespace TestAmiramAbergel
{
    // This class is responsible for the user interface
    class Program
    {
        static void Main(string[] args)
        {
            WindowController windowController = new WindowController();
            bool endApp = false; // A flag to indicate if the application should end
            Console.WriteLine("Windows Controller in C#\r");
            Console.WriteLine("------------------------\n");
            while (!endApp)
            {
                Utils.ShowMenu();
                if (!int.TryParse(Console.ReadLine(), out int option))
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                    continue;
                }
                // Switch between the user options
                try
                {
                    switch (option)
                    {
                        case 1:
                            windowController.ShowWindowsDetails();
                            break;
                        case 2:
                            string windowIdPromptMessage = "Enter the window ID you want to minimize: ";
                            int selectedWindowID = Utils.GetUserInput(windowIdPromptMessage, id => windowController.WindowIdValidate(id));
                            string secondsPromptMessage = "Enter the amount of time you would like to wait before minimizing the window (in seconds greater than 0): ";
                            int seconds = Utils.GetUserInput(secondsPromptMessage, sec => sec > 0);
                            windowController.SetWindowToMinimize(selectedWindowID, seconds);
                            break;
                        case 3:
                            string abortWindowIdPromptMessage = "Enter the window ID you want to abort the minimize for: ";
                            int abortWindowId = Utils.GetUserInput(abortWindowIdPromptMessage, id => windowController.WindowIdValidate(id));
                            windowController.AbortMinimize(abortWindowId);
                            break;
                        case 4:
                            Console.WriteLine("Exiting...");
                            endApp = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please choose a number between 1 and 4.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }


    }
}