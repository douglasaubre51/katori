using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace katori.Models;

[Index(nameof(Title), IsUnique = true)]
public class Ledger
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public List<Particular>? Particulars { get; set; }

}
