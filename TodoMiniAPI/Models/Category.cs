namespace TodoMiniAPI.Models
{
    public class Category: BaseModel
    {
        public string Name { get; set; }
        public string ObjectType { get; set; } //table name
    }
}
