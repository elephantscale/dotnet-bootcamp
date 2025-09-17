using Lab2_3.Models;

namespace Lab2_3.Services;

public class MediaLibrary
{
    private readonly List<MediaPlayer> _players = new();

    public void Add(MediaPlayer player)
    {
        _players.Add(player);
        player.OnNotify += msg => Console.WriteLine($"  [Event] {msg}");
        Console.WriteLine($"Added media: {player.Name} ({player.GetType().Name})");
    }

    public void PlayAll()
    {
        Console.WriteLine("\nPlaying all media:");
        foreach (var p in _players) p.Play();
    }

    public void ShowDetails()
    {
        Console.WriteLine("\nMedia library:");
        foreach (var p in _players)
        {
            Console.WriteLine($"- {p.Name} [{p.GetType().Name}] Duration {p.Duration:mm\\:ss}, Pos {p.Position:mm\\:ss}");
        }
    }

    public void SpecialOps()
    {
        Console.WriteLine("\nType-specific operations:");
        foreach (var p in _players)
        {
            if (p is VideoPlayer v) v.SetBrightness(70);
            if (p is AudioPlayer a) a.Notify($"{a.Name}: Added to playlist 'Favorites'");
        }
    }

    public void SaveLoadRoundtrip()
    {
        Console.WriteLine("\nSave/Load roundtrip (first item):");
        if (_players.Count == 0) return;
        var data = _players[0].Save();
        Console.WriteLine($"  Saved: {data}");
        _players[0].Load(data);
    }

    public void Stats()
    {
        Console.WriteLine("\nLibrary stats:");
        Console.WriteLine($"  Items: {_players.Count}");
        Console.WriteLine($"  Audio: {_players.Count(p => p is AudioPlayer)}");
        Console.WriteLine($"  Video: {_players.Count(p => p is VideoPlayer)}");
    }
}