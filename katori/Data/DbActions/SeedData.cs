using Microsoft.EntityFrameworkCore;

using katori.Models;
using katori.Enums;

namespace katori.Data.DbActions;

public class SeedData
{
    public static void Execute(IApplicationBuilder builder)
    {
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            // create few ledgers
            var ledger1 = new Ledger();
            ledger1.Title = "cash";
            ledger1.LedgerType = LedgerTypes.CREDIT;

            var ledger2 = new Ledger();
            ledger2.Title = "purchase";
            ledger2.LedgerType = LedgerTypes.DEBIT;

            var ledger3 = new Ledger();
            ledger3.Title = "insurance";
            ledger3.LedgerType = LedgerTypes.DEBIT;

            var ledger4 = new Ledger();
            ledger4.Title = "sales";
            ledger4.LedgerType = LedgerTypes.CREDIT;

            var ledger5 = new Ledger();
            ledger5.Title = "drug-money";
            ledger5.LedgerType = LedgerTypes.DEBIT;

            var ledger6 = new Ledger();
            ledger6.Title = "manapattil-chandi-fund";
            ledger6.LedgerType = LedgerTypes.CREDIT;

            // add them to ledgers table
            context.Ledgers.AddRange(ledger1, ledger2, ledger3, ledger4, ledger5, ledger6);
            context.SaveChanges();

            // create few journals
            var journal1 = new Journal()
            {
                Particular1 = "sales",
                Particular2 = "purchase",
                Comment = "this is a robbery!, keep your hands where i can see them!",
                Debit = 100,
                Credit = 1005000,
                Date = new DateOnly(2004, 5, 12)
            };

            var journal2 = new Journal()
            {
                Particular1 = "insurance",
                Particular2 = "manapattil-chandi-fund",
                Comment = "666!",
                Debit = 10000,
                Credit = 66666666,
                Date = new DateOnly(6666, 6, 6)
            };

            var journal3 = new Journal()
            {
                Particular1 = "cash",
                Particular2 = "purchase",
                Comment = "i need cash!",
                Debit = 5000,
                Credit = 120000,
                Date = new DateOnly(2134, 5, 21)
            };

            var journal4 = new Journal()
            {
                Particular1 = "insurance",
                Particular2 = "purchase",
                Comment = "this is my insurance!",
                Debit = 1000000,
                Credit = 1005,
                Date = new DateOnly(2890, 11, 14)
            };

            // add them to journals table
            context.Journals.AddRange(journal1, journal2, journal3, journal4);
            context.SaveChanges();

            // create particulars and add them to ledgers
            // get ledgers
            var sales = context.Ledgers
            .Include(e => e.Particulars)
            .Single(e => e.Title == "sales");
            var purchase = context.Ledgers
            .Include(e => e.Particulars)
            .Single(e => e.Title == "purchase");
            var insurance = context.Ledgers
            .Include(e => e.Particulars)
            .Single(e => e.Title == "insurance");
            var manapattilChandiFund = context.Ledgers
            .Include(e => e.Particulars)
            .Single(e => e.Title == "manapattil-chandi-fund");
            var cash = context.Ledgers
            .Include(e => e.Particulars)
            .Single(e => e.Title == "cash");

            // create particulars
            var particular1 = new Particular()
            {
                Title = "purchase",
                Amount = 1005000,
                LedgerType = LedgerTypes.DEBIT,
                Date = new DateOnly(2004, 5, 12)
            };

            var particular2 = new Particular()
            {
                Title = "sales",
                Amount = 100,
                LedgerType = LedgerTypes.CREDIT,
                Date = new DateOnly(2004, 5, 12)
            };

            var particular3 = new Particular()
            {
                Title = "manapattil-chandi-fund",
                Amount = 66666666,
                LedgerType = LedgerTypes.CREDIT,
                Date = new DateOnly(6666, 6, 6)
            };

            var particular4 = new Particular()
            {
                Title = "insurance",
                Amount = 10000,
                LedgerType = LedgerTypes.DEBIT,
                Date = new DateOnly(6666, 6, 6)
            };

            var particular5 = new Particular()
            {
                Title = "purchase",
                Amount = 120000,
                LedgerType = LedgerTypes.DEBIT,
                Date = new DateOnly(2134, 5, 21)
            };

            var particular6 = new Particular()
            {
                Title = "cash",
                Amount = 5000,
                LedgerType = LedgerTypes.CREDIT,
                Date = new DateOnly(2134, 5, 21)
            };

            var particular7 = new Particular()
            {
                Title = "purchase",
                Amount = 1005,
                LedgerType = LedgerTypes.DEBIT,
                Date = new DateOnly(2890, 11, 14)
            };

            var particular8 = new Particular()
            {
                Title = "insurance",
                Amount = 1000000,
                LedgerType = LedgerTypes.DEBIT,
                Date = new DateOnly(2890, 11, 14)
            };

            // add them to ledgers accordingly
            sales.Particulars.Add(particular1);
            purchase.Particulars.Add(particular2);
            insurance.Particulars.Add(particular3);
            manapattilChandiFund.Particulars.Add(particular4);
            cash.Particulars.Add(particular5);
            purchase.Particulars.Add(particular6);
            insurance.Particulars.Add(particular7);
            purchase.Particulars.Add(particular8);

            context.SaveChanges();
        }
    }
}
