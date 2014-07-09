using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class Program
    {
        static Dictionary<long, Loan> loans;
        static Dictionary<long, Account> accounts;
        static OverallRecord master;

        static void Main(string[] args)
        {
            Init();

            DateTime startDate = new DateTime(2014, 1, 1);
            DateTime endDate = new DateTime(2014 + 15, 1, 1);

            Simulate(startDate, endDate);
            GenerateOutput();

            //Console.ReadKey();
        }

        static void Init()
        {
            accounts = Ingestor.LoadAccounts("accounts.csv");
            loans = Ingestor.LoadLoans("loans.csv", accounts);
            master = new OverallRecord();
        }

        static void Simulate(DateTime current, DateTime end)
        {
            Console.WriteLine("Running simulation");

            while(current < end)
            {
                Console.WriteLine(current.ToString("  yyyy - MMMM"));
                double cash = 0, debt = 0;

                foreach (Account a in accounts.Values)
                {
                    AccountIterationResult result = a.Iterate(current);
                    cash += result.Cash;
                    debt += result.Debt;
                }

                master.Add(current, cash, debt);

                current = current.AddMonths(1);
            }
        }

        static void GenerateOutput()
        {
            Console.WriteLine("Generating output files");

            Console.WriteLine("  Writing CSV files");
            foreach(Account a in accounts.Values)
            {
                a.DumpLog("account-");
            }

            Console.WriteLine("  Creating summary chart");
            Charter.MakeChart("chart.png", master.DateList, master.CashList, master.DebtList);
        }
    }
}
