// namespace Lab3._3_Generic_Classes_Methods.Interfaces;

// public interface IProcessor<T>
// {
//     T Process(T input);
//     IEnumerable<T> ProcessBatch(IEnumerable<T> inputs);
//     Task<T> ProcessAsync(T input);
//     Task<IEnumerable<T>> ProcessBatchAsync(IEnumerable<T> inputs);
// }

// public interface IProcessor<TInput, TOutput>
// {
//     TOutput Process(TInput input);
//     IEnumerable<TOutput> ProcessBatch(IEnumerable<TInput> inputs);
//     Task<TOutput> ProcessAsync(TInput input);
//     Task<IEnumerable<TOutput>> ProcessBatchAsync(IEnumerable<TInput> inputs);
// }

// public interface IValidationProcessor<T> : IProcessor<T>
// {
//     bool IsValid(T input);
//     IEnumerable<string> GetValidationErrors(T input);
//     T ProcessWithValidation(T input);
// }
namespace Lab3._3_Generic_Classes_Methods.Interfaces;

public interface IProcessor<TIn, TOut>
{
    TOut Process(TIn input);
}