using katori.Data;
using katori.Interfaces;
using katori.Models;
using Microsoft.EntityFrameworkCore;

namespace katori.Repositories;

public class JournalRepository : IJournalRepository
{
    private readonly ApplicationDbContext _context;
    public JournalRepository(ApplicationDbContext context) { _context = context; }

    public Task<Journal> GetById(int id) { return _context.Journals.SingleOrDefaultAsync(e => e.JournalId == id); }
    public Task<List<Journal>> GetAll() { return _context.Journals.ToListAsync(); }

    public bool Add(Journal journal)
    {
        _context.Journals.Add(journal);
        return Save();
    }

    public bool Update(Journal journal)
    {
        _context.Journals.Update(journal);
        return Save();
    }
    public bool Delete(Journal journal)
    {
        _context.Journals.Remove(journal);
        return Save();
    }
    public bool Save() { return _context.SaveChanges() > 0; }

}
