using Microsoft.AspNetCore.Mvc;
using PRN222_SP25_B5_SL1.Models_DB;

namespace PRN222_SP25_B5_SL1.Controllers
{
    public class LoadDBController : Controller
    {
        public IActionResult Index()
        {
            var st = Prn222Sp25B5Context.Instance.Students.ToList<Student>();
            ViewBag.st = st;
            return View();
        }

        public IActionResult test()
        {
            string name = "Nguyen Van A";
            int age = 20;
            ViewBag.name = name;
            ViewData["age"] = age;
            //ViewBag.age = age;

            //return View();

            string add = "none";
            return View((object)add);
            //return View("test", add);
        }

        //[HttpPost]
        //public IActionResult getData(IFormCollection f)
        //{
        //    ViewBag.fu = f["user"];
        //    ViewBag.fp = f["pass"];
        //    string u = Request.Form["user"];
        //    string p = Request.Form["pass"];
        //    ViewBag.u = u;
        //    ViewBag.p = p;
        //    return View();
        //}



        [HttpPost]
        public IActionResult getData(string user, string pass, int age)
        {
            ViewBag.u = user;
            ViewBag.p = pass;
            ViewBag.a = age;
            return View();
        }
    }
}
