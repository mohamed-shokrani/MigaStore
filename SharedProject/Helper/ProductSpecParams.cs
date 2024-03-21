namespace SharedProject.Helper;

public class ProductSpecParams
{
    private const int maxPageSize = 10;

    public int indexPage { get; set; } = 1;

    private int _pageSize = 7;
    public int pageSize
    {
        get => _pageSize;
        set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
    }

    public int? CategoryId { get; set; }
    public string? Sort { get; set; }
    public string? _search;
    public string? Search
    {
        get => _search;
        set => _search = value.ToLower();
    }
}
