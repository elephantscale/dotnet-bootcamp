using Lab2_3.Interfaces;

namespace Lab2_3;

public static class InterfaceConcepts
{
    // Logger uses default interface methods
    private sealed class ConsoleLogger : ILogger
    {
        public void Log(string message, LogLevel level)
        {
            Console.WriteLine(message);
        }
    }

    // Explicit interface implementation demo
    private sealed class SmartSpeaker : IControllable, IAudioDevice
    {
        private int _volume;
        private bool _on;

        public void Power(bool on)
        {
            _on = on;
            Console.WriteLine($"SmartSpeaker power: {(_on ? "ON" : "OFF")}");
        }

        // Implicit: satisfies IControllable.SetVolume
        public void SetVolume(int level)
        {
            _volume = Math.Clamp(level, 0, 100);
            Console.WriteLine($"[IControllable] Volume -> {_volume}");
        }

        // Explicit: resolves name clash for IAudioDevice.SetVolume
        void IAudioDevice.SetVolume(int level)
        {
            _volume = Math.Clamp(level, 0, 100);
            Console.WriteLine($"[IAudioDevice] Volume -> {_volume}");
        }
    }

    public static void Run()
    {
        Console.WriteLine("\n=== Advanced Interface Concepts ===");

        // Default interface method usage
        ILogger logger = new ConsoleLogger();
        logger.LogInfo("Interface default method in action");
        logger.LogWarning("This is a warning");
        logger.LogError("And an error");

        // Explicit interface implementation usage
        var speaker = new SmartSpeaker();
        speaker.Power(true);
        speaker.SetVolume(30);                 // IControllable version
        ((IAudioDevice)speaker).SetVolume(70); // IAudioDevice version (explicit)
    }
}