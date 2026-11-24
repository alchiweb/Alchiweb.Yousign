using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using AlchiwebApp.PagingFiltering.Filtering;
using AlchiwebApp.PagingFiltering.Paging;

namespace Alchiweb.Yousign.Sample.Core.Custom;


public record BasePagingDto<TSortingEnum, T> : BasePagingDto<TSortingEnum>
    where TSortingEnum : struct, Enum
    where T : class, new()
{
    public BasePagingDto(TSortingEnum? sorting = null, int? pageSize = null, int? page = null) : base(sorting, pageSize, page)
    {
    }

     public static T Parse(string s, IFormatProvider? provider)
    {
        TryParse(s, provider, out var result);
        return result ?? new T();
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out T result)
    {
        result = null;
        if (string.IsNullOrEmpty(s))
        {
            return false;
        }
        T? deserializerResult = null;
        try
        {
            deserializerResult = JsonSerializer.Deserialize(s, typeof(T)/*, AppJsonContext.Default*/) as T;
        }
        catch (Exception)
        { }
        if (deserializerResult == null)
        {
            return false;
        }
        result = deserializerResult;
        return true;
    }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this, typeof(T)/*, AppJsonContext.*/);
    }

}


public record BasePagingDto<TSortingEnum> : BasePagingDto where TSortingEnum : struct, Enum
{
    [JsonPropertyName("o")]
    public Dictionary<TSortingEnum, SortingInfos> SortBy { get; set; } = [];

    public BasePagingDto(TSortingEnum? sorting = null, int? pageSize = null, int? page = null) : base(pageSize, page)
    {
        if (sorting != null)
            SortBy.Add(sorting.Value, new SortingInfos(0, false));
    }
}

public record BasePagingDto : IBasePaging
{
    [JsonPropertyName("p")]
    public int? Page { get; set; }
    [JsonPropertyName("s")]
    public int? PageSize { get; set; }
    public BasePagingDto(int? pageSize = null, int? page = null)
    {
        if (pageSize != null)
            PageSize = pageSize;
        if (page != null)
            Page = page;
    }

}



