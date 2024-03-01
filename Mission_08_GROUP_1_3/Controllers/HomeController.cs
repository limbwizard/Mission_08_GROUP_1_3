using Microsoft.AspNetCore.Mvc;
using Mission_08_GROUP_1_3.Models;

/*using Mission_08_GROUP_1_3.Models;*/
using System.Diagnostics;

namespace Mission_08_GROUP_1_3.Controllers
{
    public class HomeController : Controller
    {

        private IToDoRepository _repo;
        public HomeController(IToDoRepository temp)
        {
            _repo = temp;
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpGet]
        public IActionResult AddEditTask()
        {
            // FIXME
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddEditTask", new TaskList());
        }


        [HttpPost]
        public IActionResult AddEditTask(TaskList response)
        {
            if (ModelState.IsValid)
            {
                _repo.Tasks.Add(response); //Add record to database
                _repo.SaveChanges();
            }
            else // invalid data
            {

                //FIXME
                ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

                return View(response);
            }

            return View("Confirmation", response);
        }

        public IActionResult Index()
        {
            //linq
            var tasks = _repo.Tasks
                .Include(m => m.Category)
                .Where(x => x.Year > 1800)
                .OrderBy(x => x.Title)
                .ToList();
    
            return View(tasks);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasks
                .Single(x => x.TaskId == id);

            // FIXME
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("TaskEntry", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(TaskList updatedInfo)
        {
            _repo.Update(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);


        }

        [HttpPost]
        public IActionResult Delete(TaskList tasklist)
        {
            _repo.Tasks.Remove(tasklist);
            _repo.SaveChanges();

            return RedirectToAction("Index");
        }

    }


}
}
