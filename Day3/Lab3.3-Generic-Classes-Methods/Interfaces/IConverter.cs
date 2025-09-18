// namespace Lab3._3_Generic_Classes_Methods.Interfaces;

// public interface IConverter<TInput, TOutput>
// {
//     TOutput Convert(TInput input);
//     bool CanConvert(TInput input);
//     bool TryConvert(TInput input, out TOutput? output);
// }

// public interface IBidirectionalConverter<T1, T2> : IConverter<T1, T2>, IConverter<T2, T1>
// {
//     T1 ConvertBack(T2 input);
//     bool CanConvertBack(T2 input);
//     bool TryConvertBack(T2 input, out T1? output);
// }

namespace Lab3._3_Generic_Classes_Methods.Interfaces;

public interface IConverter<TInput, TOutput>
{
    bool CanConvert(TInput input);
    TOutput Convert(TInput input);
}