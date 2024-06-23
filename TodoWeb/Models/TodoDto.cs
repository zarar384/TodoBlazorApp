using TodoWeb.Models.Interfaces;

namespace TodoWeb.Models
{
    public class TodoDto: ICard
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }

        public List<CategoryDto> Categories { get; set; }
            = new();
    }
}
