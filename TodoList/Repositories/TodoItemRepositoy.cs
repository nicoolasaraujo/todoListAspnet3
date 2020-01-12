using TodoList.Contracts;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Repositories
{
    public class TodoItemRepository : RepositoryBase<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }
        
    }
}