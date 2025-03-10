using E_Book_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Book_Store.Data;

public class EBookDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<EBook> EBooks { get; set; }

    public EBookDbContext(DbContextOptions<EBookDbContext> options) : base(options) { }
}

