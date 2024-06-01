namespace TodoMiniAPI.Helpers
{
    public record PaginationHeader(int currentPage, int pageSize, int totalItems, int totalPages);
}
