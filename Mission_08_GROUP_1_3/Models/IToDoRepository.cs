namespace Mission_08_GROUP_1_3.Models
{
    public interface IToDoRepository
    {
        List<ToDo> ToDos { get; }

        public void AddTask(ToDo task);

        public void EditTask(ToDo task);

        public void DeleteTask(ToDo task);


    }
}
