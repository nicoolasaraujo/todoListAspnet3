using TodoList.Contracts;
using TodoList.Data;

namespace TodoList.Repositories
{
    public class TodoListRepository : RepositoryBase<Models.TodoList>, ITodoListRepository
    {
        public TodoListRepository(DatabaseContext repositoryContext) : base(repositoryContext)
        {
        }       
    }
}