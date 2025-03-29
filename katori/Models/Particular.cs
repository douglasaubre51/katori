using System.ComponentModel.DataAnnotations;

namespace katori.Models;

public class Particular
{
    [Key]
    public int ParticularId { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public int JournalId { get; set; }
}
