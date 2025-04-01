using System;
using katori.Data;
using katori.Interfaces;

namespace katori.Repositories;

public class LedgerRepository : ILedgerRepository
{
    private readonly ApplicationDbContext _context;
    public LedgerRepository(ApplicationDbContext context) { _context = context; }

    public async Task CreateLedgers()
    {
    }
    public async Task CalculateLedgers() { }

}
