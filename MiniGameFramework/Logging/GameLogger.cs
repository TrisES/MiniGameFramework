using System.Diagnostics;

namespace MiniGameFramework.Logging
{
    /// <summary>
    /// Provides logging functionality for the game.
    /// </summary>
    public class GameLogger : IGameLogger
    {
        // TODO: kunne laves thread safe i fremtiden. (F.eks. kunne man forestille sig at flere kampe foregik samtidigt)
        // Singleton instance
        private static GameLogger instance = null;

        // Using built-in class, TraceSource, for logging
        private static readonly TraceSource traceSource = new TraceSource("GameTraceSource");

        /// <summary>
        /// Private constructor for the GameLogger class.
        /// </summary>
        private GameLogger()
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
        /// Gets the singleton instance of the GameLogger class.
        /// If the instance does not exist, it creates a new one.
        /// Otherwise, it returns the existing instance.
        /// </summary>
        public static GameLogger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameLogger();
                }
                return instance;
            }
        }

        /// <summary>
        /// Logs a message with the specified event type.
        /// </summary>
        /// <param name="message">The message to be logged</param>
        /// <param name="eventType">The type of event. If none specified, defaults to "TraceEventType.Information"</param>
        public void Log(string message, TraceEventType eventType = TraceEventType.Information)
        {
            int processId = Process.GetCurrentProcess().Id; // Get the process ID
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Get the current timestamp
            string logMessage = $"[{timestamp}] {message}"; // Add timestamp to the log message
            traceSource.TraceEvent(eventType, processId, logMessage); // Log the message
            traceSource.Flush(); // Flush the buffer after each write to ensure the message is written to the log file
        }

        /// <summary>
        /// Closes the trace source.
        /// </summary>
        public void Close()
        {
            traceSource.Close();
        }

        /// <summary>
        /// Adds a TraceListener to the TraceSource.
        /// </summary>
        /// <param name="listener">The TraceListener to be added.</param>
        public void AddListener(TraceListener listener)
        {
            traceSource.Listeners.Add(listener);
        }

        /// <summary>
        /// Removes a TraceListener from the TraceSource.
        /// </summary>
        /// <param name="listener">The TraceListener to be removed.</param>
        public void RemoveListener(TraceListener listener)
        {
            traceSource.Listeners.Remove(listener);
        }

    }
}   

