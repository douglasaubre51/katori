using System;

namespace katori.DTO;

public class JournalDTO
{
    public string Particular1 { get; set; } = "";
    public string Particular2 { get; set; } = "";
    public string Comment { get; set; } = "";

    public decimal Debit { get; set; }
    public decimal Credit { get; set; }

    public DateOnly Date { get; set; }

}
