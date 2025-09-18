

namespace Lab3._3_Generic_Classes_Methods.Utilities;

public static class GenericValidator
{
    public static bool IsDefault<T>(T value) => EqualityComparer<T>.Default.Equals(value, default!);
    public static bool NotNull<T>(T? value) where T : class => value is not null;
}
