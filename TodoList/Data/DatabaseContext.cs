using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public  DatabaseContext() {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=todoListDB.db");
        }

        public DbSet<Models.TodoList> TodoLists { get; set; }
        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
