using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WindowManagement
{
    // WindowController class is responsible for managing the windows
    public class WindowController
    {
        private Dictionary<int, Window> windows = new Dictionary<int, Window>();
        private int windowID = 1;

        // ShowWindowsDetails method is responsible for showing the windows details
        public void ShowWindowsDetails()
        {
            windows.Clear();
            windowID = 1;
            Process[] processList = Process.GetProcesses(); // Get the list of processes

            foreach (Process process in processList)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle)) // Check if the process has a title
                {
                    Window window = new Window(process, null);
                    windows[windowID] = window;
                    Console.WriteLine($"ID: {windowID}, PID: {window.ProcessId}, Title: {window.Title}");
                    windowID++;
                }
            }
        }

        // SetWindowToMinimize method is responsible for setting a window to be minimized
        public async void SetWindowToMinimize(int selectedWindowID, int seconds)
        {
            var window = windows[selectedWindowID];
            var cancellationTokenSource = new CancellationTokenSource();
            window.CancellationTokenSource = cancellationTokenSource;
            await MinimizeWindowWithDelay(window, seconds, cancellationTokenSource.Token);
        }

        // MinimizeWindowWithDelay method is responsible for minimizing a window with a delay
        public async Task MinimizeWindowWithDelay(Window window, int seconds, CancellationToken cancellationToken)
        {
            for (int i = seconds; i > 0; i--)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                window.SetTitle($"{window.Title} Minimizing in: {i}");
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
            window.Minimize();
            window.SetTitle(window.Title);
        }

        // AbortMinimize method is responsible for aborting the minimize of a window
        public void AbortMinimize(int selectedWindowID)
        {
            var window = windows[selectedWindowID];
            if (window.CancellationTokenSource != null)
            {
                window.CancellationTokenSource.Cancel();
                window.SetTitle(window.Title); // Set the window title back to the original title
            }
            else
            {
                Console.WriteLine("No minimize action to abort for this window.");
            }
        }

        // WindowIdValidate method is responsible for validating the window ID 
        public bool WindowIdValidate(int selectedWindowID)
        {
            return Utils.IsPositive(selectedWindowID) && windows.ContainsKey(selectedWindowID);
        }

        public Window GetWindow(int windowId)
        {
            if (windows.ContainsKey(windowId))
            {
                return windows[windowId];
            }
            return null;
        }

    }
}