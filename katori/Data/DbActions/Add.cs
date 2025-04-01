using katori.Models;

namespace katori.Data.DbActions;

public class Add
{
    public static void AddJournals(IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();


            var particulars = new List<Particular>();

            particulars.AddRange(
                new Particular
                {
                    Title = "Cash",
                    Amount = 45000,
                    Date = new DateOnly(2001, 11, 19)
                },

                new Particular
                {
                    Title = "Sales",
                    Amount = 93200,
                    Date = new DateOnly(2131, 1, 9),
                }
            );

            var ledger = new Ledger()
            {
                Title = "Cash",
                Particulars = particulars
            };

            context.Ledgers
            .Add(ledger);

            context.SaveChanges();
        }
    }
}
