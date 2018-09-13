using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechStack.Infrastructure;
using TechStack.Models;

namespace TechStack.Pages.Catalog
{
    public class IndexModel : PageModel
    {
        private readonly TechStack.Infrastructure.ApplicationDbContext _context;

        public IndexModel(TechStack.Infrastructure.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Models.Catalog> Catalog { get;set; }

        public async Task OnGetAsync()
        {
            Catalog = await _context.Catalog.ToListAsync();
        }
    }
}
