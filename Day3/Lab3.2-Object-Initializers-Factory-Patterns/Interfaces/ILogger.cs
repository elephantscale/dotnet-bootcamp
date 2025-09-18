namespace Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

public interface ILogger
{
    string Name { get; }
    LogLevel MinimumLevel { get; set; }
    
    void Log(LogLevel level, string message);
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
    void LogDebug(string message);
}

public enum LogLevel
{
    Debug = 0,
    Info = 1,
    Warning = 2,
    Error = 3,
    Critical = 4
}
