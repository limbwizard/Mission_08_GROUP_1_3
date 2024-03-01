 using Microsoft.EntityFrameworkCore;

namespace Mission_08_GROUP_1_3.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) :base(options)
        { 
        }

        public DbSet<ToDo> ToDos { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
