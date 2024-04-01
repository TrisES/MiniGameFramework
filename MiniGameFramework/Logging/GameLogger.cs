using System.Diagnostics;

namespace MiniGameFramework.Logging
{
    public static class GameLogger
    {
        private static readonly TraceSource traceSource = new TraceSource("GameTraceSource");

        static GameLogger()
        {
            // Example setup: Console trace listener
            var consoleListener = new ConsoleTraceListener();
            traceSource.Listeners.Add(consoleListener);
            traceSource.Switch.Level = SourceLevels.All; // Set the level of logging detail

            // Additional listeners can be added here (e.g., for logging to a file)
        }

        public static void Log(string message, TraceEventType eventType = TraceEventType.Information)
        {
            traceSource.TraceEvent(eventType, 0, message);
        }
    }
}
