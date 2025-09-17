using Lab2_3.Interfaces;

namespace Lab2_3.Models;

public abstract class MediaPlayer : INotifiable, ISaveable
{
    protected MediaPlayer(string name, TimeSpan duration)
    {
        Name = name;
        Duration = duration;
    }

    public string Name { get; }
    public TimeSpan Duration { get; }
    public TimeSpan Position { get; protected set; }

    public event Action<string>? OnNotify;

    public abstract void Play();
    public virtual void Pause() => Notify($"{Name}: Paused at {Position:mm\\:ss}");
    public virtual void Stop() { Position = TimeSpan.Zero; Notify($"{Name}: Stopped"); }

    public void Notify(string message) => OnNotify?.Invoke(message);

    // super-lightweight serialization
    public virtual string Save() => $"{GetType().Name}|{Name}|{Duration.TotalSeconds}|{Position.TotalSeconds}";

    public virtual void Load(string data)
    {
        var parts = data.Split('|');
        if (parts.Length >= 4)
            Position = TimeSpan.FromSeconds(double.Parse(parts[3]));
    }
}

public sealed class AudioPlayer : MediaPlayer
{
    public AudioPlayer(string name, TimeSpan duration, string format = "MP3")
        : base(name, duration) => Format = format;

    public string Format { get; }

    public override void Play()
    {
        Notify($"{Name}: Playing audio ({Format})…");
        Position = TimeSpan.FromSeconds(Math.Min(Duration.TotalSeconds, Position.TotalSeconds + 15));
    }
}

public sealed class VideoPlayer : MediaPlayer
{
    public VideoPlayer(string name, TimeSpan duration, string resolution = "1080p")
        : base(name, duration) => Resolution = resolution;

    public string Resolution { get; }

    public override void Play()
    {
        Notify($"{Name}: Playing video ({Resolution})…");
        Position = TimeSpan.FromSeconds(Math.Min(Duration.TotalSeconds, Position.TotalSeconds + 30));
    }

    public void SetBrightness(int level) => Notify($"{Name}: Brightness set to {Math.Clamp(level, 0, 100)}");
}