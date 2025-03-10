using E_Book_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Book_Store.Data;

public class EBookDbContext : DbContext
{
    public DbSet<EBook> EBooks { get; set; }

    public EBookDbContext(DbContextOptions<EBookDbContext> options) : base(options) { }
}

