using katori.Models;

namespace katori.Data.DbActions;

public class Add
{
    public static void AddJournals(IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var journal1 = new Journal()
            {
                Particular1 = "Purchase",
                Particular2 = "Sales",
                Comment = "made Purchase and Sales!",
                Debit = 79040,
                Credit = 80001,
                Date = new DateOnly(2024, 5, 24)
            };

            var journal2 = new Journal()
            {
                Particular1 = "Inventory",
                Particular2 = "Sales",
                Comment = "made Inventory and Sales!",
                Debit = 124652,
                Credit = 24001,
                Date = new DateOnly(2004, 8, 2)
            };

            var journal3 = new Journal()
            {
                Particular1 = "Cash",
                Particular2 = "Insurance",
                Comment = "made Cash and Insurance!",
                Debit = 90,
                Credit = 100290,
                Date = new DateOnly(3244, 6, 29)
            };

            context.Journals.Add(journal1);
            context.Journals.Add(journal2);
            context.Journals.Add(journal3);

            context.SaveChanges();
        }
    }
}
