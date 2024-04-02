using System.Diagnostics;

namespace MiniGameFramework.Logging
{
    /// <summary>
    /// Provides logging functionality for the game.
    /// </summary>
    public static class GameLogger
    {
        // Using built-in class, TraceSource, for logging
        private static readonly TraceSource traceSource = new TraceSource("GameTraceSource");

        /// <summary>
        /// Static constructor for the GameLogger class.
        /// </summary>
        static GameLogger()
        {
            // Setup: Console trace listener. 
            ConsoleTraceListener consoleListener = new ConsoleTraceListener();
            traceSource.Listeners.Add(consoleListener);
            traceSource.Switch.Level = SourceLevels.All; // Set the level of logging detail

            // Additional listeners can be added here (e.g., for logging to a file)
        }

        /// <summary>
        /// Logs a message with the specified event type.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <param name="eventType">The type of event. If none specified, defaults to "TraceEventType.Information"</param>
        public static void Log(string message, TraceEventType eventType = TraceEventType.Information)
        {
            traceSource.TraceEvent(eventType, 0, message);
        }
    }
}   

