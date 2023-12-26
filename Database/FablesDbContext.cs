using FablesProvider.Core.Models;
using FablesProvider.Core.Pages;
using Microsoft.EntityFrameworkCore;
using System;

namespace FablesProvider.Database;

public class FablesDbContext : DbContext
{
    public FablesDbContext(DbContextOptions<FablesDbContext> options) : base(options)
    {
    }

    public DbSet<BookPage> BookPages { get; set; }
    public DbSet<BookCover> BookCovers { get; set; }
}
