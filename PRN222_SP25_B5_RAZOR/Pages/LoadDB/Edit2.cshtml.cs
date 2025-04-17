using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN222_SP25_B5_RAZOR.Pages.LoadDB
{
    public class Edit2Model : PageModel
    {
        private readonly Prn222Sp25B5Context ctx;

        public Edit2Model(Prn222Sp25B5Context ctx)
        {
            this.ctx = ctx;
        }

        public void OnGet(int id)
        {
            var std = ctx.Students.Find(id);
            if (std == null)
            {
                Redirect("Index");
            }
            else
            {
                var ds = ctx.Departments.ToList();
                ViewData["ds"] = ds;
                ViewData["std"] = std;
            }

        }

        public IActionResult OnPost(
            int id,
            string name,
            bool gender,
            string depart_id,
            DateOnly dob,
            double gpa
            )
        {
            var x = ctx.Students.Find(id);
            var d = ctx.Departments.Find(depart_id);
            if (d == null)
            {
                return RedirectToPage("Index");
            }

            if (x != null)
            {
                x.Name = name;
                x.Gender = gender;
                x.DepartId = depart_id;
                x.Dob = dob;
                x.Gpa = gpa;
                ctx.Students.Update(x);
                ctx.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
