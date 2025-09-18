namespace Lab3._3_Generic_Classes_Methods.Interfaces;

public interface IProcessor<TIn, TOut>
{
    TOut Process(TIn input);
}
