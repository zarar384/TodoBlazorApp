namespace TodoWeb.Models.Interfaces
{
    public interface ICard
    {
        string Title { get; set; }
        string Description { get; set; }
        List<CategoryDto> Categories { get; set; }
    }
}
