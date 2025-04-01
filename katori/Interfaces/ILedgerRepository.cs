namespace katori.Interfaces;

public interface ILedgerRepository
{
    Task CreateLedgers();
    Task CalculateLedgers();
}
