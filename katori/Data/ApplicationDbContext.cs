using System;
using katori.Models;
using Microsoft.EntityFrameworkCore;

namespace katori.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Particular> Particulars { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }
}
