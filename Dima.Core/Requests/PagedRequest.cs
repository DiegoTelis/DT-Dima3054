namespace Dima.Core.Requests;

public abstract class PagedRequest: Request
{
    public int PageNumber { get; set; } = Configuration.DefaultaPageNumber;
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
}
