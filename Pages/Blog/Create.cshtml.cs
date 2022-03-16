#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniPaintingWebsite.Data;
using MiniPaintingWebsite.Models;

namespace MiniPaintingWebsite.Pages.Blog
{
    public class CreateModel : PageModel
    {
        private readonly MiniPaintingWebsite.Data.MiniPaintingWebsiteContext _context;

        public CreateModel(MiniPaintingWebsite.Data.MiniPaintingWebsiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProgressBlog ProgressBlog { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ProgressBlog.Add(ProgressBlog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
