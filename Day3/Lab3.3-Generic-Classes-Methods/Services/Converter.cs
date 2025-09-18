

using Lab3._3_Generic_Classes_Methods.Interfaces;

namespace Lab3._3_Generic_Classes_Methods.Services;

public static class Converter
{
    // Register a few concrete converters
    public static readonly IConverter<string, int> StringToInt = new StringToIntConverter();
    public static readonly IConverter<int, string> IntToString = new IntToStringConverter();
    public static readonly IConverter<bool, string> BoolToString = new BoolToStringConverter();

    private sealed class StringToIntConverter : IConverter<string, int>
    {
        public bool CanConvert(string input) => int.TryParse(input, out _);
        public int Convert(string input) => int.Parse(input);
    }

    private sealed class IntToStringConverter : IConverter<int, string>
    {
        public bool CanConvert(int input) => true;
        public string Convert(int input) => input.ToString();
    }

    private sealed class BoolToStringConverter : IConverter<bool, string>
    {
        public bool CanConvert(bool input) => true;
        public string Convert(bool input) => input.ToString();
    }
}
