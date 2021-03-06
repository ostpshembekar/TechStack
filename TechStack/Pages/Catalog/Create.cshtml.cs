﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TechStack.Infrastructure;

namespace TechStack.Pages.Catalog
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public Models.Catalog Catalog { get; set; }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            Catalog.Id = _context.Catalog.Count() + 1;
            _context.Add(Catalog);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}