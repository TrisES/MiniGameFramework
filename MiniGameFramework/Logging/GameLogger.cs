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

            // Delete the log files if they exist (to start fresh)
            //File.Delete(@"C:\Temp\Logs\GameLog.txt");
            //File.Delete(@"C:\Temp\Logs\ErrorLog.txt");

            traceSource.Switch.Level = SourceLevels.All; // Set the level of logging detail

            // Setup: Console trace listener. 
            ConsoleTraceListener consoleListener = new ConsoleTraceListener();
            traceSource.Listeners.Add(consoleListener);

            // Setup: Text file trace listener.
            TraceListener gameLog = new TextWriterTraceListener(@"C:\Temp\Logs\GameLog.txt");
            traceSource.Listeners.Add(gameLog);

            // Setup: Error log trace listener.
            TraceListener errorLog = new TextWriterTraceListener(@"C:\Temp\Logs\ErrorLog.txt");
            errorLog.Filter = new EventTypeFilter(SourceLevels.Error); // Only log errors or worse
            traceSource.Listeners.Add(errorLog);

            // Flush the buffer after each write
            traceSource.Flush();
        }

        /// <summary>
        /// Closes the trace source.
        /// </summary>
        public static void Close()
        {
            traceSource.Close();
        }

        /// <summary>
        /// Logs a message with the specified event type.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <param name="eventType">The type of event. If none specified, defaults to "TraceEventType.Information"</param>
        public static void Log(string message, TraceEventType eventType = TraceEventType.Information)
        {
            traceSource.TraceEvent(eventType, 0, message);
            traceSource.Flush();
        }
    }
}   

