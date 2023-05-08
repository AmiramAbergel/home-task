using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace WindowManagement
{
    // Window class is responsible for managing a single window details and actions
    public class Window
    {
        public int ID { get; set; }
        public IntPtr Handle { get; set; }
        public uint ProcessId { get; set; }
        public string Title { get; set; }
        public Process Process { get; set; }
        public CancellationTokenSource? CancellationTokenSource { get; set; }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool SetWindowText(IntPtr hWnd, string lpString);
        private const int SW_MINIMIZE = 6; // Minimizes the specified window and activates the next top-level window in the Z order.

        public Window(Process process, CancellationTokenSource? cancellationTokenSource)
        {
            Process = process;
            CancellationTokenSource = cancellationTokenSource ?? null;
            Handle = process.MainWindowHandle; // Get the handle of the window 
            ProcessId = (uint)process.Id; // Get the process ID of the window 
            Title = GetWindowTitle(Handle);
        }

        // This method is responsible for getting the window title
        private static string GetWindowTitle(IntPtr hWnd)
        {
            StringBuilder title = new StringBuilder(256);
            GetWindowText(hWnd, title, title.Capacity);
            return title.ToString();
        }

        // This method is responsible for minimizing the window 
        public void Minimize()
        {
            ShowWindow(Handle, SW_MINIMIZE);
        }

        // This method is responsible for setting the window title
        public void SetTitle(string title)
        {
            SetWindowText(Handle, title);
        }
    }
}