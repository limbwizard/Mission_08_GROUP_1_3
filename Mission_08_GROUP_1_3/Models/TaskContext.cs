using Microsoft.EntityFrameworkCore;

namespace Mission_08_GROUP_1_3.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) :base(options)
        { 
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
