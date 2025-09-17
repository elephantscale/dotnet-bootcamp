namespace Lab2_3.Interfaces;

public interface IDrawable
{
    void Draw();
    void Move(int x, int y);
    string GetDescription();
}

public interface IResizable
{
    void Resize(double factor);
}

public interface IColorable
{
    string Color { get; set; }
    void SetColor(string color) => Color = color;
}

public interface IGeometric
{
    double Area { get; }
    double Perimeter { get; }
}

// simple deep-clone contract (avoids non-generic ICloneable)
public interface IDeepCloneable<T>
{
    T DeepClone();
}

// Media-related small contracts
public interface INotifiable
{
    event Action<string>? OnNotify;
    void Notify(string message);
}

public interface ISaveable
{
    string Save();
    void Load(string data);
}

// Control & Audio with a naming conflict to show explicit impl
public interface IControllable
{
    void Power(bool on);
    void SetVolume(int level);
}

public interface IAudioDevice
{
    void SetVolume(int level);
}

// Default interface methods (C# 8+)
public enum LogLevel { Info, Warning, Error }

public interface ILogger
{
    void Log(string message, LogLevel level);

    // defaults
    void LogInfo(string message) => Log($"[INFO] {message}", LogLevel.Info);
    void LogWarning(string message) => Log($"[WARN] {message}", LogLevel.Warning);
    void LogError(string message) => Log($"[ERROR] {message}", LogLevel.Error);
}