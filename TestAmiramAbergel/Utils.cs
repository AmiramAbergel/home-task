using System;

namespace TestAmiramAbergel
{
    public static class Utils
    {
        public static int GetUserInput(string promptMessage, Func<int, bool> validate)
        {
            int userInput;
            while (true)
            {
                Console.Write(promptMessage);
                if (int.TryParse(Console.ReadLine(), out userInput) && validate(userInput))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            return userInput;
        }

        // ShowMenu method is responsible for showing the user menu 
        public static void ShowMenu()
        {
            Console.WriteLine("------------------------\n");
            Console.WriteLine("- Select one of the following options:");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("- 1. Show a list of windows details");
            Console.WriteLine("- 2. Set a window to be minimized.");
            Console.WriteLine("- 3. Abort the minimize of a window");
            Console.WriteLine("- 4. Close the app and exit");
            Console.WriteLine("------------------------\n");
        }

    }
}