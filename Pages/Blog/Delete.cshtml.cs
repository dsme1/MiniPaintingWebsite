#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MiniPaintingWebsite.Data;
using MiniPaintingWebsite.Models;

namespace MiniPaintingWebsite.Pages.Blog
{
    public class DeleteModel : PageModel
    {
        private readonly MiniPaintingWebsite.Data.MiniPaintingWebsiteContext _context;

        public DeleteModel(MiniPaintingWebsite.Data.MiniPaintingWebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProgressBlog ProgressBlog { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgressBlog = await _context.ProgressBlog.FirstOrDefaultAsync(m => m.Id == id);

            if (ProgressBlog == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProgressBlog = await _context.ProgressBlog.FindAsync(id);

            if (ProgressBlog != null)
            {
                _context.ProgressBlog.Remove(ProgressBlog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
