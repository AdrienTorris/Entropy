using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module2.Areas.Feature2.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult Index2()
        {
            return Content("lkdlkkdslkds");
        }
    }
}
