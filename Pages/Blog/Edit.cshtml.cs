#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiniPaintingWebsite.Data;
using MiniPaintingWebsite.Models;

namespace MiniPaintingWebsite.Pages.Blog
{
    public class EditModel : PageModel
    {
        private readonly MiniPaintingWebsite.Data.MiniPaintingWebsiteContext _context;

        public EditModel(MiniPaintingWebsite.Data.MiniPaintingWebsiteContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProgressBlog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgressBlogExists(ProgressBlog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProgressBlogExists(int id)
        {
            return _context.ProgressBlog.Any(e => e.Id == id);
        }
    }
}
