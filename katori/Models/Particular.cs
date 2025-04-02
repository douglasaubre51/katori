using System.ComponentModel.DataAnnotations;
using katori.Enums;

namespace katori.Models;

public class Particular
{
    [Key]
    public int ParticularId { get; set; }

    public string Title { get; set; } = "";
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public LedgerTypes LedgerType { get; set; }

    public Ledger? Ledger { get; set; }

}
