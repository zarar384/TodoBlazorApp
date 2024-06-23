namespace TodoWeb.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }

        public CategoryDto()
        {
            Color = GetRandomColor();
        }

        private string GetRandomColor()
        {
            Random random = new Random();
            return $"#{random.Next(0x1000000):X6}";
        }
    }
}
