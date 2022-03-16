#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniPaintingWebsite.Models;

namespace MiniPaintingWebsite.Data
{
    public class MiniPaintingWebsiteContext : DbContext
    {
        public MiniPaintingWebsiteContext (DbContextOptions<MiniPaintingWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<MiniPaintingWebsite.Models.ProgressBlog> ProgressBlog { get; set; }
    }
}
