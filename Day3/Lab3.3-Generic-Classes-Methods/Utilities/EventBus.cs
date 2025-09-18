namespace Lab3._3_Generic_Classes_Methods.Utilities;

// Simple generic event bus
public sealed class EventBus<TEvent>
{
    private readonly List<Action<TEvent>> _handlers = new();

    public void Subscribe(Action<TEvent> handler) => _handlers.Add(handler);
    public void Publish(TEvent evt)
    {
        foreach (var h in _handlers) h(evt);
    }
}