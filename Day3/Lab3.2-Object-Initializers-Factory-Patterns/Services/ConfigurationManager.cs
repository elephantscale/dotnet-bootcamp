namespace Lab3._2_Object_Initializers_Factory_Patterns.Services;

public sealed class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> _instance =
        new(() => new ConfigurationManager());

    public static ConfigurationManager Instance => _instance.Value;

    private ConfigurationManager()
    {
        InstanceId = "CFG-001";
        Source = "appsettings.json";
        DatabaseConnection = "Server=localhost;Database=AppDB";
        ApiKey = "XXX-YYY-ZZZ-1234";
    }

    private string ApiKey { get; }
    public string MaskedApiKey =>
        $"{new string('*', 3)}-{new string('*', 3)}-{new string('*', 3)}-{ApiKey[^4..]}";

    public string InstanceId { get; }
    public string Source { get; }
    public string DatabaseConnection { get; }
}