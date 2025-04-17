using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN222_SP25_B5_RAZOR.Pages.LoadDB
{
    public class CreateModel : PageModel
    {
        private readonly Prn222Sp25B5Context ctx;

        public CreateModel(Prn222Sp25B5Context ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Student std { get; set; } = default;
        public void OnGet()
        {
            var ds = ctx.Departments.ToList();
            ViewData["ds"] = ds;
        }

        public IActionResult OnPost()
        {
            var x = ctx.Students.Find(std.Id);
            if (x == null)
            {
                ctx.Students.Add(std);
                ctx.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
