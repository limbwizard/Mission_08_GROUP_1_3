namespace Mission_08_GROUP_1_3.Models
{
    public interface ITaskRepository
    {
        List<Task> Tasks { get; }

        public void AddTask(Task task);

        public void EditTask(Task task);

        public void DeleteTask(Task task);


    }
}
