using System;
using System.IO;

namespace AIChatApp.Infrastructure
{
    public static class Logger
    {
        private static readonly string _logFile = "app_log.txt";

        public static void Log(string message)
        {
            File.AppendAllText(_logFile, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} — {message}\n");
        }
        public static void LogError(Exception ex)
        {
            Log($"[ERROR] {ex.Message}\n{ex.StackTrace}");
        }
    }
}
