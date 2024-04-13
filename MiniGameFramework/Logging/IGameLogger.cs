using System.Diagnostics;

namespace MiniGameFramework.Logging
{
    public interface IGameLogger
    {
        void AddListener(TraceListener listener);
        void Log(string message, TraceEventType eventType = TraceEventType.Information);
        void RemoveListener(TraceListener listener);
    }
}