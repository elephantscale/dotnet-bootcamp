namespace Lab3._3_Generic_Classes_Methods.Models;

public abstract class Entity
{
    public int Id { get; set; }
}

// Per-type counter to auto-assign ids inside Repository<T>
internal static class IdCounter<T> where T : Entity
{
    private static int _next = 1;
    public static int Next() => _next++;
}