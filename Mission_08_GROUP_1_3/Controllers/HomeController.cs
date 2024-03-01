using Microsoft.AspNetCore.Mvc;
using Mission_08_GROUP_1_3.Models;
using System.Linq;
using System.Diagnostics;

namespace Mission_08_GROUP_1_3.Controllers
{
    // HomeController inherits from Controller base class
    public class HomeController : Controller
    {
        // Declare a variable to hold the repository
        private IToDoRepository _repo;

        // Constructor injects the repository into the controller
        public HomeController(IToDoRepository temp)
        {
            _repo = temp;
        }

        // Index action method to display the tasks in quadrants (handled in the view)
        public IActionResult Index()
        {
            // Use LINQ to get all non-completed tasks and order them by DueDate if needed
            var tasks = _repo.ToDos.Where(t => t.Completed == false).OrderBy(t => t.DueDate).ToList();

            // Pass the tasks to the view
            return View(tasks);
        }

        // This action method handles both adding and editing tasks
        // GET: Shows the form for adding or editing a task
        public IActionResult AddEditTask(int taskId = 0)
        {
            // If taskId is 0, we understand it's a new task
            if (taskId == 0)
            {
                // Create a new task and pass it to the view
                return View(new ToDo());
            }
            else
            {
                // Find the task by ID for editing
                var task = _repo.ToDos.FirstOrDefault(t => t.TaskId == taskId);

                // If the task doesn't exist, redirect to Index
                if (task == null) return RedirectToAction("Index");

                // Pass the task to the view for editing
                return View(task);
            }
        }

        // POST: Handles the submission of the form for adding or editing tasks
        [HttpPost]
        public IActionResult AddEditTask(ToDo task)
        {
            // Check if the model state is valid
            if (ModelState.IsValid)
            {
                // If the TaskId is 0, it's a new task, so we add it
                if (task.TaskId == 0)
                {
                    _repo.AddTask(task);
                }
                else
                {
                    // Otherwise, we update the existing task
                    _repo.EditTask(task);
                }
                // Redirect to the Index action after saving
                return RedirectToAction("Index");
            }

            // If the model state is not valid, return to the view with the current task data
            return View(task);
        }

        // Action for deleting an existing task
        // POST: because we're changing server state
        [HttpPost]
        public IActionResult Delete(int taskId)
        {
            // Find the task by ID
            var task = _repo.ToDos.FirstOrDefault(t => t.TaskId == taskId);

            // If the task exists, delete it
            if (task != null)
            {
                _repo.DeleteTask(task);
            }

            // Redirect to the Index action after deletion
            return RedirectToAction("Index");
        }

        // Action for marking a task as completed
        // POST: because we're changing server state
        [HttpPost]
        public IActionResult Complete(int taskId)
        {
            // Find the task by ID
            var task = _repo.ToDos.FirstOrDefault(t => t.TaskId == taskId);

            // If the task exists, mark it as completed
            if (task != null)
            {
                task.Completed = true;

                // Assuming EditTask will handle task updates
                _repo.EditTask(task);
            }

            // Redirect to the Index action after completion
            return RedirectToAction("Index");
        }
    }
}
