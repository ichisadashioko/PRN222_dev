using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN222_SP25_B5_RAZOR.Pages.LoadDB
{
    public class EditModel : PageModel
    {
        private readonly Prn222Sp25B5Context ctx;

        public EditModel(Prn222Sp25B5Context ctx)
        {
            this.ctx = ctx;
        }

        [BindProperty]
        public Student std { get; set; }

        public void OnGet(int id)
        {
            std = ctx.Students.Find(id);
            if (std == null)
            {
                Redirect("Index");
            }
            else
            {
                var ds = ctx.Departments.ToList();
                ViewData["ds"] = ds;
            }

        }

        public IActionResult OnPost()
        {
            var x = ctx.Students.Find(std.Id);
            if (x != null)
            {
                ctx.Attach(x).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                ctx.Attach(std).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }

            return RedirectToPage("Index");

        }
    }
}
