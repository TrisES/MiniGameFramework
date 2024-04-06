using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniGameFramework.Logging;
using System.Diagnostics;
using System.IO;

namespace MiniGameFrameworkTests.Logging.Tests
{
    [TestClass]
    public class GameLoggerTests
    {
        [TestMethod]
        public void Log_Information_Message()
        {
            // Arrange
            string expectedMessage = "Test message";
            TraceEventType expectedEventType = TraceEventType.Information;

            // Act
            GameLogger.Log(expectedMessage, expectedEventType);

            // Close the GameLogger
            GameLogger.Close();

            // Assert
            // Check the log file to see if the message was written
            // This assumes that the log file is written to the application's directory
            string logContents = File.ReadAllText(@"C:\Temp\Logs\GameLog.txt");
            Assert.IsTrue(logContents.Contains(expectedMessage));
        }

        [TestMethod]
        public void Log_Error_Message()
        {
            // Arrange
            string expectedMessage = "Test error message";
            TraceEventType expectedEventType = TraceEventType.Error;

            // Act
            GameLogger.Log(expectedMessage, expectedEventType);

            // Close the GameLogger
            GameLogger.Close();

            // Assert
            // Check the error log file to see if the message was written
            // This assumes that the error log file is written to the application's directory
            string logContents = File.ReadAllText(@"C:\Temp\Logs\ErrorLog.txt");
            Assert.IsTrue(logContents.Contains(expectedMessage));
        }
    }
}
