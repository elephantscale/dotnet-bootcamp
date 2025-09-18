
using Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

public abstract class LoggerFactoryBase
{
    public abstract ILogger CreateLogger();
}

// Concrete factories
public sealed class FileLoggerFactory(string filePath) : LoggerFactoryBase
{
    public override ILogger CreateLogger() => new FileLogger(filePath);
}
public sealed class ConsoleLoggerFactory : LoggerFactoryBase
{
    public override ILogger CreateLogger() => new ConsoleLogger();
}
public sealed class DatabaseLoggerFactory(string database, string table) : LoggerFactoryBase
{
    public override ILogger CreateLogger() => new DatabaseLogger(database, table);
}

// Implementations matching your ILogger
file abstract class LoggerBase : ILogger
{
    public abstract string Name { get; }
    public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

    public void Log(LogLevel level, string message)
    {
        if (level < MinimumLevel) return;
        Write($"[{level}] {message}");
    }

    public void LogInfo(string message) => Log(LogLevel.Info, message);
    public void LogWarning(string message) => Log(LogLevel.Warning, message);
    public void LogError(string message) => Log(LogLevel.Error, message);
    public void LogDebug(string message) => Log(LogLevel.Debug, message);

    protected abstract void Write(string formattedMessage);
    public override string ToString() => Name;
}

file sealed class FileLogger(string path) : LoggerBase
{
    public override string Name => $"FileLogger: Logging to {path}";
    protected override void Write(string msg) => Console.WriteLine($"[FILE:{path}] {msg}");
}

file sealed class ConsoleLogger : LoggerBase
{
    public override string Name => "ConsoleLogger: Logging to console output";
    protected override void Write(string msg) => Console.WriteLine(msg);
}

file sealed class DatabaseLogger(string database, string table) : LoggerBase
{
    public override string Name => $"DatabaseLogger: Logging to {database}.{table} table";
    protected override void Write(string msg) => Console.WriteLine($"[DB:{database}.{table}] {msg}");
}
