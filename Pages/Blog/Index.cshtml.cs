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
    public class IndexModel : PageModel
    {
        private readonly MiniPaintingWebsite.Data.MiniPaintingWebsiteContext _context;

        public IndexModel(MiniPaintingWebsite.Data.MiniPaintingWebsiteContext context)
        {
            _context = context;
        }

        public IList<ProgressBlog> ProgressBlog { get;set; }

        public async Task OnGetAsync()
        {
            ProgressBlog = await _context.ProgressBlog.ToListAsync();
        }
    }
}
