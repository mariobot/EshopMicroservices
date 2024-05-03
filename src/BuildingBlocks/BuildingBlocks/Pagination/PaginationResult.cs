namespace BuildingBlocks.Pagination;

public class PaginationResult<TEntity>
    (int pageIndex, int pagSize, long count, IEnumerable<TEntity> data) 
    where TEntity : class
{
    public int PageIndex { get; } = pageIndex;
    public int PageSize { get; } = pagSize;
    public long Count { get; } = count;
    public IEnumerable<TEntity> Data { get; } = data;
}
