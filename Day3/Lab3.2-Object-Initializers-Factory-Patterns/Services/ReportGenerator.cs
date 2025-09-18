namespace Lab3._2_Object_Initializers_Factory_Patterns.Services;

public enum ReportFormat { Pdf, Excel, Html }

public sealed class ReportGenerator
{
    private string _title = "Report";
    private ReportFormat _format = ReportFormat.Pdf;
    private DateTime _from = DateTime.Today.AddDays(-30);
    private DateTime _to = DateTime.Today;
    private readonly Dictionary<string, string> _filters = new();
    private readonly List<(string Field, bool Desc)> _sorts = new();

    public ReportGenerator WithTitle(string title) { _title = title; return this; }
    public ReportGenerator WithFormat(ReportFormat format) { _format = format; return this; }
    public ReportGenerator WithDateRange(DateTime from, DateTime to) { _from = from; _to = to; return this; }
    public ReportGenerator AddFilter(string key, string value) { _filters[key] = value; return this; }
    public ReportGenerator SortBy(string field, bool descending = false) { _sorts.Add((field, descending)); return this; }

    public string Build()
    {
        var ext = _format switch
        {
            ReportFormat.Excel => "xlsx",
            ReportFormat.Html => "html",
            _ => "pdf"
        };
        var file = $"{_title.Replace(' ', '_')}_{_to:yyyyMMdd}.{ext}";

        Console.WriteLine("\nReport Configuration:");
        Console.WriteLine($"- Title: {_title}");
        Console.WriteLine($"- Format: {_format}");
        Console.WriteLine($"- Date Range: {_from:d} to {_to:d}");
        if (_filters.Count > 0)
            Console.WriteLine($"- Filters: {string.Join(", ", _filters.Select(kv => $"{kv.Key}={kv.Value}"))}");
        if (_sorts.Count > 0)
            Console.WriteLine($"- Sort: {string.Join(", ", _sorts.Select(s => $"{s.Field} {(s.Desc ? "DESC" : "ASC")}"))}");
        Console.WriteLine($"- Generated: {file}");
        return file;
    }
}