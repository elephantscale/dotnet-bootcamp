namespace Lab1_7.Models
{
    public class ApplicationConfiguration
    {
        private readonly Dictionary<string, object> _settings;

        // Indexer property
        public object? this[string key]
        {
            get => _settings.TryGetValue(key, out var value) ? value : null;
            set => _settings[key] = value!;
        }

        // Strongly-typed properties
        public string ApplicationName
        {
            get => GetSetting<string>("ApplicationName") ?? "Default App";
            set => SetSetting("ApplicationName", value);
        }

        public int MaxUsers
        {
            get => GetSetting<int>("MaxUsers");
            set
            {
                if (value < 1) throw new ArgumentException("Max users must be at least 1");
                SetSetting("MaxUsers", value);
            }
        }

        public bool EnableLogging
        {
            get => GetSetting<bool>("EnableLogging");
            set => SetSetting("EnableLogging", value);
        }

        public TimeSpan SessionTimeout
        {
            get => TimeSpan.FromMinutes(GetSetting<int>("SessionTimeoutMinutes"));
            set => SetSetting("SessionTimeoutMinutes", (int)value.TotalMinutes);
        }

        // Computed properties
        public int SettingsCount => _settings.Count;
        public IEnumerable<string> SettingKeys => _settings.Keys;

        public ApplicationConfiguration()
        {
            _settings = new Dictionary<string, object>();
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            ApplicationName = "My .NET Application";
            MaxUsers = 100;
            EnableLogging = true;
            SessionTimeout = TimeSpan.FromMinutes(30);
        }

        private T? GetSetting<T>(string key)
        {
            if (_settings.TryGetValue(key, out var value) && value is T t) return t;
            return default;
        }

        private void SetSetting(string key, object value)
        {
            _settings[key] = value;
            Console.WriteLine($"Setting updated: {key} = {value}");
        }

        public void PrintConfiguration()
        {
            Console.WriteLine("\n=== Application Configuration ===");
            foreach (var kv in _settings.OrderBy(s => s.Key))
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            Console.WriteLine($"Total Settings: {SettingsCount}");
            Console.WriteLine("================================\n");
        }
    }
}