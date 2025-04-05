using Microsoft.EntityFrameworkCore;

namespace katori.Data.DbActions;

public class Retrieve
{
    public static void RetrieveLedgers(IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

            using (var stream = new StreamWriter("retrievedData.txt"))
            {
                var ledgers = context.Ledgers
                .Include(e => e.Particulars)
                .ToList();

                stream.WriteLine(DateTime.Now);

                foreach (var l in ledgers)
                {
                    stream.WriteLine("ledger:-\n");
                    stream.WriteLine(l.Id);
                    stream.WriteLine(l.Title);

                    foreach (var p in l.Particulars)
                    {
                        stream.WriteLine("\nparticular:-\n");
                        stream.WriteLine(p.ParticularId);
                        stream.WriteLine(p.Title);
                        stream.WriteLine(p.Amount);
                        stream.WriteLine(p.Date);
                        stream.WriteLine(p.LedgerType.ToString());
                    }
                }
            }
        }
    }
}
