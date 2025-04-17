using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PRN222_SP25_B5_RAZOR.Pages.StudentGen
{
    public class IndexModel : PageModel
    {
        private readonly Prn222Sp25B5Context _context;

        public IndexModel(Prn222Sp25B5Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public List<Department> Departments { get; set; } = default;
        //public async Task OnGetAsync()
        //{
        //    Student = await _context.Students
        //        .Include(s => s.Depart).ToListAsync();
        //    Departments = await _context.Departments.ToListAsync();
        //}

        public async Task OnGetAsync()
        {
            string departid = null;
            
            if (Request.Query.ContainsKey("departid"))
            {
                departid = Request.Query["departid"];
            }
            Student = await _context.Students
            .Include(s => s.Depart).ToListAsync();
            Departments = await _context.Departments.ToListAsync();

            if (!departid.IsNullOrEmpty())
            {
                Student = Student.Where(s => s.DepartId == departid).ToList();
            }
            else
            {
                // TODO
            }
        }
    }
}
