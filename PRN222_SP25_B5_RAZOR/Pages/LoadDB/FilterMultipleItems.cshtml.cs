using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PRN222_SP25_B5_RAZOR.Pages.LoadDB
{
    public class FilterMultipleItemsModel : PageModel
    {
        private readonly Prn222Sp25B5Context _context;

        public FilterMultipleItemsModel(Prn222Sp25B5Context context)
        {
            _context = context;
        }

        public IList<Department> Departments { get; set; } = default;
        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Departments = await _context.Departments.ToListAsync();
            Student = await _context.Students
                .Include(s => s.Depart).ToListAsync();
        }

        //[BindProperty]
        //public List<string> SelectedDepartments { get; set; } = new();

        public async Task OnPostAsync(string[] SelectedDepartments)
        {
            ViewData["SelectedDepartments"] = SelectedDepartments.ToList();
            Departments = await _context.Departments.ToListAsync();
            if (SelectedDepartments != null)
            {
                //SelectedDepartments.Contains
                Student = (await _context.Students
                    .Include(s => s.Depart).ToListAsync()).Where(s => SelectedDepartments.Contains(s.DepartId)).ToList();
            }
            else
            {
                Student = await _context.Students
                    .Include(s => s.Depart).ToListAsync();
            }
        }
    }
}
