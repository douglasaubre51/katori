using System;
using katori.Models;

namespace katori.Interfaces;

public interface IJournalRepository
{
    Task<Journal> GetById(int id);
    Task<List<Journal>> GetAll();

    bool Add(Journal journal);
    bool Update(Journal journal);
    bool Delete(Journal journal);
    bool Save();

}
