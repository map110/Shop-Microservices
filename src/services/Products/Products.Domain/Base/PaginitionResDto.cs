using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Products.Domain.Base;

public class PaginitionResDto<T>
{
    public T Data { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int PageIndex { get; set; }
}