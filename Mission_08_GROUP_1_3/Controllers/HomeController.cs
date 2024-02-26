using Microsoft.AspNetCore.Mvc;
/*using Mission_08_GROUP_1_3.Models;*/
using System.Diagnostics;

namespace Mission_08_GROUP_1_3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
