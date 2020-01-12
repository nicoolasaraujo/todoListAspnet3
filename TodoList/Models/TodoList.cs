using System.Collections.Generic;

namespace TodoList.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<TodoItem> Items { get; set; }
    }
}
