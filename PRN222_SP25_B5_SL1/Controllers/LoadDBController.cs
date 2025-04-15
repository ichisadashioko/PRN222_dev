using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN222_SP25_B5_SL1.Models_DB;

namespace PRN222_SP25_B5_SL1.Controllers
{
    public class LoadDBController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.dept = Prn222Sp25B5Context.Instance.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student st)
        {
            var x = Prn222Sp25B5Context.Instance.Students.Find(st.Id);
            if(x == null)
            {
                Prn222Sp25B5Context.Instance.Students.Add(st);
                Prn222Sp25B5Context.Instance.SaveChanges();
            }
            return Redirect("Index");
        }

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [BindProperty]
        public Department d { get; set; }
        public IActionResult Index()
        {
            var st = Prn222Sp25B5Context.Instance.Students.Include(x => x.Depart).ToList<Student>();
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

            //string add = "none";
            //return View((object)add);
            //string add = "none";
            return View();
            //return View("test", add);
        }

        [HttpPost]
        public IActionResult getData()
        {
            ViewBag.u = d.Id;
            ViewBag.p = d.Name;
            return View();
        }
        //public IActionResult getData(Department d)
        //{
        //    ViewBag.u = d.Id;
        //    ViewBag.p = d.Name;
        //    return View();
        //}

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



        //[HttpPost]
        //public IActionResult getData(string user, string pass, int age)
        //{
        //    ViewBag.u = user;
        //    ViewBag.p = pass;
        //    ViewBag.a = age;
        //    return View();
        //}
    }
}
