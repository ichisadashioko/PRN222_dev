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
    }
}
