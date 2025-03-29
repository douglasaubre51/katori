using System;
using katori.Models;

namespace katori.Interfaces;

public interface IParticularRepository
{
    Task<Particular> GetById(int id);
    Task<List<Particular>> GetAll();

    bool Add(Particular particular);
    bool Update(Particular particular);
    bool Delete(Particular particular);
    bool Save();

}
