using System.ComponentModel.DataAnnotations;
using katori.Enums;
using Microsoft.EntityFrameworkCore;

namespace katori.Models;

[Index(nameof(Title), IsUnique = true)]
public class Ledger
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public LedgerTypes LedgerType { get; set; }
    public List<Particular>? Particulars { get; set; }

    public decimal TotalDebit { get; set; }
    public decimal TotalCredit { get; set; }
}
