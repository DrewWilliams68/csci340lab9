using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealUniversity.Data;
using RealUniversity.Models;

namespace RealUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly RealUniversity.Data.SchoolContext _context;

        public IndexModel(RealUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Course = await _context.Courses
                .Include(c => c.Department).ToListAsync();
        }
    }
}
