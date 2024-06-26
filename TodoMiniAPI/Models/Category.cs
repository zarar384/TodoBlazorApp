﻿namespace TodoMiniAPI.Models
{
    public class Category: BaseModel
    {
        public string Text { get; set; }
        public string ObjectType { get; set; } //table name
        public string Color { get; set; }

        public Category()
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
