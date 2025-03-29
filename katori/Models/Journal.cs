using System.ComponentModel.DataAnnotations;

namespace katori.Models;

public class Journal
{
    [Key]
    public int JournalId { get; set; }

    public string Particular1 { get; set; }
    public string Particular2 { get; set; }
    public string Comment { get; set; }

    public decimal Debit { get; set; }
    public decimal Credit { get; set; }

    public DateOnly Date { get; set; }
}
