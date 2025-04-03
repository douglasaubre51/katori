using katori.Data;
using katori.Enums;
using katori.Interfaces;
using katori.Models;
using Microsoft.EntityFrameworkCore;

namespace katori.Repositories;

public class LedgerRepository : ILedgerRepository
{
    private readonly ApplicationDbContext _context;
    public LedgerRepository(ApplicationDbContext context) { _context = context; }

    public async Task<bool> SetSumOfParticulars(string ledgerName)
    {
        var ledger = await _context.Ledgers
        .Include(e => e.Particulars)
        .SingleOrDefaultAsync(e => e.Title == ledgerName);

        decimal debit = ledger.Particulars
        .Where(e => e.LedgerType == LedgerTypes.DEBIT)
        .Sum(e => e.Amount);

        decimal credit = ledger.Particulars
        .Where(e => e.LedgerType == LedgerTypes.CREDIT)
        .Sum(e => e.Amount);

        ledger.TotalCredit = debit;
        ledger.TotalDebit = credit;

        return Save();
    }
    public async Task<Ledger> GetByTitle(string title)
    {
        return await _context.Ledgers
        .AsNoTracking()
        .SingleOrDefaultAsync(e => e.Title == title);
    }

    public async Task<List<Ledger>> GetAll()
    {
        return await _context.Ledgers
        .Include(e => e.Particulars)
        .ToListAsync();
    }
    public async Task<Ledger> GetById(int id)
    {
        return await _context.Ledgers
        .Include(e => e.Particulars)
        .SingleOrDefaultAsync(e => e.Id == id);
    }

    public bool Add(Ledger ledger)
    {
        _context.Ledgers.Add(ledger);
        return Save();
    }
    public bool Update(Ledger ledger)
    {
        _context.Ledgers.Update(ledger);
        return Save();
    }
    public bool Delete(Ledger ledger)
    {
        _context.Ledgers.Remove(ledger);
        return Save();
    }
    public bool Save()
    {
        bool result = _context.SaveChanges() > 0;
        Console.WriteLine($"State entries :{result}");

        return result;
    }
}
