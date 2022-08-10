using System;
using Adevinta_hw.Models;
using Microsoft.EntityFrameworkCore;

namespace Adevinta_hw.Data
{
    public class KonyvtarDbContext : DbContext
    {
        public KonyvtarDbContext(DbContextOptions<KonyvtarDbContext> options) : base(options)
        {

        }

        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}

