using katori.Data;
using katori.Interfaces;
using katori.Models;
using Microsoft.EntityFrameworkCore;

namespace katori.Repositories;

public class ParticularRepository : IParticularRepository
{
    private readonly ApplicationDbContext _context;
    public ParticularRepository(ApplicationDbContext context) { _context = context; }

    //create new particular from journal
    public async Task<bool> CreateParticular(Journal journal)
    {
        var ledger1 = await _context.Ledgers
        .Include(e => e.Particulars)
        .SingleAsync(e => e.Title == journal.Particular1);

        var ledger2 = await _context.Ledgers
        .Include(e => e.Particulars)
        .SingleAsync(e => e.Title == journal.Particular2);

        var particular1 = new Particular()
        {
            Title = journal.Particular2,
            Amount = journal.Debit,
            Date = journal.Date,
            LedgerType = ledger2.LedgerType
        };

        var particular2 = new Particular()
        {
            Title = journal.Particular1,
            Amount = journal.Debit,
            Date = journal.Date,
            LedgerType = ledger1.LedgerType
        };


        ledger1.Particulars.Add(particular1);
        ledger2.Particulars.Add(particular2);

        return Save();
    }

    public Task<Particular> GetById(int id)
    {
        return _context.Particulars
        .SingleOrDefaultAsync(e => e.ParticularId == id);
    }
    public Task<List<Particular>> GetAll()
    {
        return _context.Particulars
        .ToListAsync();
    }

    public bool Update(Particular particular)
    {
        _context.Particulars.Update(particular);
        return Save();
    }
    public bool Delete(Particular particular)
    {
        _context.Particulars.Remove(particular);
        return Save();
    }
    public bool Save() { return _context.SaveChanges() > 0; }

}
