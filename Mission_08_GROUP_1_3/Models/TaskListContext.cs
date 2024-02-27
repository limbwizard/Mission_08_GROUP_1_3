using Microsoft.EntityFrameworkCore;

namespace Mission_08_GROUP_1_3.Models
{
    public class TaskListContext : DbContext
    {
        public TaskListContext(DbContextOptions<TaskListContext> options) :base(options)
        { 
        }

        DbSet<TaskList> Tasks { get; set; }
    }
}
