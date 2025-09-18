
namespace Lab3._3_Generic_Classes_Methods.Interfaces;

public interface IConverter<TInput, TOutput>
{
    bool CanConvert(TInput input);
    TOutput Convert(TInput input);
}
