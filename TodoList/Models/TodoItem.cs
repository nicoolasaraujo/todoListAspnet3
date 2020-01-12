namespace TodoList.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public TodoList TodoList { get; set; }
    }
}
