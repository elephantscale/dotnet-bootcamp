// using Lab3._2_Object_Initializers_Factory_Patterns.Interfaces;

// namespace Lab3._2_Object_Initializers_Factory_Patterns.Factories;

// // Factory Method Pattern
// public abstract class LoggerFactory
// {
//     public abstract ILogger CreateLogger(string name);

//     // Template method that uses the factory method
//     public ILogger GetConfiguredLogger(string name, LogLevel minimumLevel)
//     {
//         var logger = CreateLogger(name);
//         logger.MinimumLevel = minimumLevel;
//         return logger;
//     }
// }

// public class FileLoggerFactory : LoggerFactory
// {
//     private readonly string _logDirectory;

//     public FileLoggerFactory(string logDirectory = "logs")
//     {
//         _logDirectory = logDirectory;
//     }

//     public override ILogger CreateLogger(string name)
//     {
//         return new FileLogger(name, _logDirectory);
//     }
// }

// public class ConsoleLoggerFactory : LoggerFactory
// {
//     public override ILogger CreateLogger(string name)
//     {
//         return new ConsoleLogger(name);
//     }
// }

// public class DatabaseLoggerFactory : LoggerFactory
// {
//     private readonly string _connectionString;

//     public DatabaseLoggerFactory(string connectionString)
//     {
//         _connectionString = connectionString;
//     }

//     public override ILogger CreateLogger(string name)
//     {
//         return new DatabaseLogger(name, _connectionString);
//     }
// }

// // Static Factory for Logger Creation
// public static class LoggerFactoryProvider
// {
//     private static readonly Dictionary<string, Func<string, ILogger>> _loggerFactories = new()
//     {
//         ["file"] = name => new FileLogger(name, "logs"),
//         ["console"] = name => new ConsoleLogger(name),
//         ["database"] = name => new DatabaseLogger(name, "Server=localhost;Database=LoggingDB"),
//         ["composite"] = name => new CompositeLogger(name)
//     };

//     public static ILogger CreateLogger(string type, string name)
//     {
//         if (!_loggerFactories.ContainsKey(type.ToLower()))
//             throw new ArgumentException($"Unknown logger type: {type}");

//         return _loggerFactories[type.ToLower()](name);
//     }

//     public static void RegisterLoggerFactory(string type, Func<string, ILogger> factory)
//     {
//         _loggerFactories[type.ToLower()] = factory;
//     }
// }

// // Logger Implementations
// public class FileLogger : ILogger
// {
//     public string Name { get; }
//     public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

//     private readonly string _logFilePath;

//     public FileLogger(string name, string logDirectory = "logs")
//     {
//         Name = name;
//         Directory.CreateDirectory(logDirectory);
//         _logFilePath = Path.Combine(logDirectory, $"{name}.log");
//     }

//     public void Log(LogLevel level, string message)
//     {
//         if (level < MinimumLevel) return;

//         var logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
//         File.AppendAllText(_logFilePath, logEntry + Environment.NewLine);
//     }

//     public void LogInfo(string message) => Log(LogLevel.Info, message);
//     public void LogWarning(string message) => Log(LogLevel.Warning, message);
//     public void LogError(string message) => Log(LogLevel.Error, message);
//     public void LogDebug(string message) => Log(LogLevel.Debug, message);

//     public override string ToString() => $"FileLogger: Logging to {_logFilePath}";
// }

// public class ConsoleLogger : ILogger
// {
//     public string Name { get; }
//     public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

//     public ConsoleLogger(string name)
//     {
//         Name = name;
//     }

//     public void Log(LogLevel level, string message)
//     {
//         if (level < MinimumLevel) return;

//         var color = level switch
//         {
//             LogLevel.Debug => ConsoleColor.Gray,
//             LogLevel.Info => ConsoleColor.White,
//             LogLevel.Warning => ConsoleColor.Yellow,
//             LogLevel.Error => ConsoleColor.Red,
//             LogLevel.Critical => ConsoleColor.Magenta,
//             _ => ConsoleColor.White
//         };

//         var originalColor = Console.ForegroundColor;
//         Console.ForegroundColor = color;
//         Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] [{level}] {message}");
//         Console.ForegroundColor = originalColor;
//     }

//     public void LogInfo(string message) => Log(LogLevel.Info, message);
//     public void LogWarning(string message) => Log(LogLevel.Warning, message);
//     public void LogError(string message) => Log(LogLevel.Error, message);
//     public void LogDebug(string message) => Log(LogLevel.Debug, message);

//     public override string ToString() => "ConsoleLogger: Logging to console output";
// }

// public class DatabaseLogger : ILogger
// {
//     public string Name { get; }
//     public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

//     private readonly string _connectionString;

//     public DatabaseLogger(string name, string connectionString)
//     {
//         Name = name;
//         _connectionString = connectionString;
//     }

//     public void Log(LogLevel level, string message)
//     {
//         if (level < MinimumLevel) return;

//         // Simulate database logging
//         Console.WriteLine($"[DB LOG] [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {Name}: {message}");
//     }

//     public void LogInfo(string message) => Log(LogLevel.Info, message);
//     public void LogWarning(string message) => Log(LogLevel.Warning, message);
//     public void LogError(string message) => Log(LogLevel.Error, message);
//     public void LogDebug(string message) => Log(LogLevel.Debug, message);

//     public override string ToString() => $"DatabaseLogger: Logging to {_connectionString.Split(';')[1]}.Logs table";
// }

// public class CompositeLogger : ILogger
// {
//     public string Name { get; }
//     public LogLevel MinimumLevel { get; set; } = LogLevel.Info;

//     private readonly List<ILogger> _loggers = new();

//     public CompositeLogger(string name)
//     {
//         Name = name;
//         // Initialize with multiple loggers
//         _loggers.Add(new ConsoleLogger(name));
//         _loggers.Add(new FileLogger(name));
//     }

//     public void AddLogger(ILogger logger)
//     {
//         _loggers.Add(logger);
//     }

//     public void Log(LogLevel level, string message)
//     {
//         foreach (var logger in _loggers)
//         {
//             logger.Log(level, message);
//         }
//     }

//     public void LogInfo(string message) => Log(LogLevel.Info, message);
//     public void LogWarning(string message) => Log(LogLevel.Warning, message);
//     public void LogError(string message) => Log(LogLevel.Error, message);
//     public void LogDebug(string message) => Log(LogLevel.Debug, message);

//     public override string ToString() => $"CompositeLogger: {_loggers.Count} loggers";
// }

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