using System.ComponentModel.DataAnnotations.Schema;

namespace TodoMiniAPI.Models
{
    public class Todo: BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public List<Category> Categories { get; set; } 
            = new ();
    }
}
