using katori.Data;
using katori.Interfaces;
using katori.Models;
using Microsoft.EntityFrameworkCore;

namespace katori.Repositories;

public class ParticularRepository : IParticularRepository
{
    private readonly ApplicationDbContext _context;
    public ParticularRepository(ApplicationDbContext context) { _context = context; }

    public Task<Particular> GetById(int id) { return _context.Particulars.SingleOrDefaultAsync(e => e.ParticularId == id); }
    public Task<List<Particular>> GetAll() { return _context.Particulars.ToListAsync(); }

    public bool Add(Particular particular)
    {
        _context.Particulars.Add(particular);
        return Save();
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
