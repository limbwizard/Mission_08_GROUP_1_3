
namespace Mission_08_GROUP_1_3.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;
        public EFTaskRepository(TaskContext context) 
        {
            _context = context;     
        }

        public List<Task> Tasks => _context.Tasks.ToList();


        public void AddTask(Task task)
        {
            //go to context file and add whatever was passed into me
            _context.Add(task);
            _context.SaveChanges();
        }

        public void EditTask(Task task)
        {
            //go to context file and add whatever was passed into me
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(Task task)
        {
            //go to context file and add whatever was passed into me
            _context.Remove(task);
            _context.SaveChanges();
        }

    }
}
