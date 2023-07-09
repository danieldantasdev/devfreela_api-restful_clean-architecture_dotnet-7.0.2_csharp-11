namespace DevFreela.Core.Dtos.Paginations;

public class PaginationResultDto<T>
{
    public PaginationResultDto()
    {
    }

    public PaginationResultDto(int page, int totalPages, int pageSize, int itemsCount, List<T> data)
    {
        Page = page;
        TotalPages = totalPages;
        PageSize = pageSize;
        ItemsCount = itemsCount;
        Data = data;
    }

    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int ItemsCount { get; set; }
    public List<T> Data { get; set; }
}