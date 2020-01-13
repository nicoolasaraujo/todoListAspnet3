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

        public override TodoItem Create(TodoItem entity)
        {
            entity.TodoList = this.RepositoryContext.Set<Models.TodoList>().Find(entity.TodoList.Id);
            var result = this.RepositoryContext.Set<TodoItem>().Add(entity).Entity;
            this.RepositoryContext.SaveChanges();
            return result;
        }
    }
}