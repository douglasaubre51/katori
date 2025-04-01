using System;
using katori.Models;
using Microsoft.EntityFrameworkCore;

namespace katori.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Journal> Journals { get; set; }
    public DbSet<Particular> Particulars { get; set; }
    public DbSet<Ledger> Ledgers { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        ConfigureLedger(builder);
    }

    private void ConfigureLedger(ModelBuilder builder)
    {
        //unique titles
        builder.Entity<Ledger>()
        .HasIndex(e => e.Title)
        .IsUnique();

        //relations
        builder.Entity<Ledger>()
        .HasMany(e => e.Particulars)
        .WithOne(e => e.Ledger);
    }
}
