﻿
using Microsoft.EntityFrameworkCore;

namespace Mission_08_GROUP_1_3.Models
{
    public class EFToDoRepository : IToDoRepository
    {
        private ToDoContext _context;
        public EFToDoRepository(ToDoContext context) 
        {
            _context = context;
        }

        public List<ToDo> ToDos => _context.ToDos.ToList();
        public List<Category> Categories => _context.Categories.ToList();
        public List<ToDo> GetTasksWithCategories()
        {
            return _context.ToDos.Include(t => t.Category).ToList();
        }

        public void AddTask(ToDo task)
        {
            //go to context file and add whatever was passed into me
            _context.Add(task);
            _context.SaveChanges();
        }

        public void EditTask(ToDo task)
        {
            //go to context file and add whatever was passed into me
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(ToDo task)
        {
            //go to context file and add whatever was passed into me
            _context.Remove(task);
            _context.SaveChanges();
        }

    }
}
