using katori.Models;

namespace katori.Interfaces;

public interface ILedgerRepository
{
    Task<bool> SetSumOfParticulars(string ledgerName);
    Task<Ledger> GetByTitle(string title);

    Task<List<Ledger>> GetAll();
    Task<Ledger> GetById(int id);

    bool Add(Ledger ledger);
    bool Update(Ledger ledger);
    bool Delete(Ledger ledger);
    bool Save();

}
