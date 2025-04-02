using System;
using katori.Models;

namespace katori.Interfaces;

public interface IParticularRepository
{
    Task<Particular> GetById(int id);
    Task<List<Particular>> GetAll();

    Task<bool> CreateParticular(Journal journal);

    bool Update(Particular particular);
    bool Delete(Particular particular);
    bool Save();

}
