using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WindowManagement;
using Xunit;

namespace Tests
{
    public class WindowControllerTests
    {

        [Fact]
        public void TestWindowIdValidate_ValidWindowId()
        {
            // Arrange
            var controller = new WindowController();
            controller.ShowWindowsDetails(); // Call ShowWindowsDetails to populate the windows dictionary
            int validWindowId = 1; // Check if the first window ID is valid
            // Act
            bool isValid = controller.WindowIdValidate(validWindowId);
            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void TestWindowIdValidate_InvalidWindowId()
        {
            // Arrange
            var controller = new WindowController();
            controller.ShowWindowsDetails(); // Call ShowWindowsDetails to populate the windows dictionary
            int validWindowId = -1;
            // Act
            bool isValid = controller.WindowIdValidate(validWindowId);
            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void TestSetTitle_UpdatesWindowTitle()
        {
            // Arrange
            var controller = new WindowController();
            controller.ShowWindowsDetails(); // Call ShowWindowsDetails to populate the windows dictionary
            int windowId = 1;
            var window = controller.GetWindow(windowId);
            string newTitle = "New Title";

            // Act
            window.SetTitle(newTitle);

            // Assert
            Assert.Equal(newTitle, window.Title);
        }

        [Fact]
        public async void TestAbortMinimize_AbortsMinimizeProcess()
        {
            // Arrange
            var controller = new WindowController();
            controller.ShowWindowsDetails(); // Call ShowWindowsDetails to populate the windows dictionary
            int windowId = 3;
            var window = controller.GetWindow(windowId);
            string originalTitle = window.Title;

            // Act
            controller.SetWindowToMinimize(windowId, 5); // Set window to minimize in 5 seconds
            await Task.Delay(2000); // Wait for 2 seconds before aborting the minimize process
            controller.AbortMinimize(windowId);

            // Assert
            Assert.Equal(originalTitle, window.Title);
        }
    }
}
