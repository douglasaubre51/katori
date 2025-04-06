using System;
using katori.Models;

namespace katori.Interfaces;

public interface IParticularRepository
{
    Task<bool> CreateParticular(Journal journal);
    Task<List<Particular>> GetDebitParticularsByTitle(string ledgerName);
    Task<List<Particular>> GetCreditParticularsByTitle(string ledgerName);

    Task<Particular> GetById(int id);
    Task<List<Particular>> GetAll();

    bool Update(Particular particular);
    bool Delete(Particular particular);
    bool Save();

}
