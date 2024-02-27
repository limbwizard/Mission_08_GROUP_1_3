using Microsoft.AspNetCore.Mvc;
/*using Mission_08_GROUP_1_3.Models;*/
using System.Diagnostics;

namespace Mission_08_GROUP_1_3.Controllers
{
    public class HomeController : Controller
    {
        


        private TaskEntryContext _context;
        public HomeController(TaskEntryContext temp)
        {
            _context = temp;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddEditTask()
        {
            // FIXME
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddEditTask", new Task());
        }


        [HttpPost]
        public IActionResult AddEditTask(Task response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response); //Add record to database
                _context.SaveChanges();
            }
            else // invalid data
            {

                //FIXME
                ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(response);
            }

            return View("Confirmation", response);
        }

        public IActionResult Index()
        {
            //linq
            var tasks = _context.Tasks
                .Include(m => m.Category)
                .Where(x => x.Year > 1800)
                .OrderBy(x => x.Title)
                .ToList();
    
            return View(tasks);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            // FIXME
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("TaskEntry", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);


        }

        [HttpPost]
        public IActionResult Delete(Task task)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }


}
}
