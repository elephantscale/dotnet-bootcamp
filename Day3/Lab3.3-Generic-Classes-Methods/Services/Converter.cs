// using Lab3._3_Generic_Classes_Methods.Interfaces;

// namespace Lab3._3_Generic_Classes_Methods.Services;

// public class Converter<TInput, TOutput> : IConverter<TInput, TOutput>
// {
//     private readonly Func<TInput, TOutput> _convertFunc;
//     private readonly Func<TInput, bool> _canConvertFunc;

//     public Converter(Func<TInput, TOutput> convertFunc, Func<TInput, bool>? canConvertFunc = null)
//     {
//         _convertFunc = convertFunc ?? throw new ArgumentNullException(nameof(convertFunc));
//         _canConvertFunc = canConvertFunc ?? (_ => true);
//     }

//     public TOutput Convert(TInput input)
//     {
//         if (!CanConvert(input))
//             throw new InvalidOperationException($"Cannot convert input of type {typeof(TInput).Name}");

//         return _convertFunc(input);
//     }

//     public bool CanConvert(TInput input)
//     {
//         try
//         {
//             return _canConvertFunc(input);
//         }
//         catch
//         {
//             return false;
//         }
//     }

//     public bool TryConvert(TInput input, out TOutput? output)
//     {
//         try
//         {
//             if (CanConvert(input))
//             {
//                 output = Convert(input);
//                 return true;
//             }
//         }
//         catch
//         {
//             // Conversion failed
//         }

//         output = default(TOutput);
//         return false;
//     }
// }

// public class BidirectionalConverter<T1, T2> : IBidirectionalConverter<T1, T2>
// {
//     private readonly IConverter<T1, T2> _forwardConverter;
//     private readonly IConverter<T2, T1> _backwardConverter;

//     public BidirectionalConverter(
//         Func<T1, T2> forwardFunc, 
//         Func<T2, T1> backwardFunc,
//         Func<T1, bool>? canConvertForward = null,
//         Func<T2, bool>? canConvertBackward = null)
//     {
//         _forwardConverter = new Converter<T1, T2>(forwardFunc, canConvertForward);
//         _backwardConverter = new Converter<T2, T1>(backwardFunc, canConvertBackward);
//     }

//     public T2 Convert(T1 input) => _forwardConverter.Convert(input);
//     public bool CanConvert(T1 input) => _forwardConverter.CanConvert(input);
//     public bool TryConvert(T1 input, out T2? output) => _forwardConverter.TryConvert(input, out output);

//     public T1 Convert(T2 input) => _backwardConverter.Convert(input);
//     public bool CanConvert(T2 input) => _backwardConverter.CanConvert(input);
//     public bool TryConvert(T2 input, out T1? output) => _backwardConverter.TryConvert(input, out output);

//     public T1 ConvertBack(T2 input) => Convert(input);
//     public bool CanConvertBack(T2 input) => CanConvert(input);
//     public bool TryConvertBack(T2 input, out T1? output) => TryConvert(input, out output);
// }

// // Common converters
// public static class CommonConverters
// {
//     public static readonly IConverter<string, int> StringToInt = new Converter<string, int>(
//         s => int.Parse(s),
//         s => int.TryParse(s, out _)
//     );

//     public static readonly IConverter<int, string> IntToString = new Converter<int, string>(
//         i => i.ToString()
//     );

//     public static readonly IConverter<string, decimal> StringToDecimal = new Converter<string, decimal>(
//         s => decimal.Parse(s),
//         s => decimal.TryParse(s, out _)
//     );

//     public static readonly IConverter<decimal, string> DecimalToString = new Converter<decimal, string>(
//         d => d.ToString("F2")
//     );

//     public static readonly IConverter<string, bool> StringToBool = new Converter<string, bool>(
//         s => bool.Parse(s),
//         s => bool.TryParse(s, out _)
//     );

//     public static readonly IConverter<bool, string> BoolToString = new Converter<bool, string>(
//         b => b.ToString()
//     );

//     public static readonly IBidirectionalConverter<string, int> StringIntConverter = 
//         new BidirectionalConverter<string, int>(
//             s => int.Parse(s),
//             i => i.ToString(),
//             s => int.TryParse(s, out _)
//         );
// }

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