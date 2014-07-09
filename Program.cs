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

        static void Main(string[] args)
        {
            Init();

            DateTime startDate = new DateTime(2014, 1, 1);
            DateTime endDate = new DateTime(2014 + 15, 1, 1);

            Simulate(startDate, endDate);
            GenerateOutput();

            Console.ReadKey();
        }

        static void Init()
        {
            accounts = Ingestor.LoadAccounts("accounts.csv");
            loans = Ingestor.LoadLoans("loans.csv", accounts);
        }

        static void Simulate(DateTime current, DateTime end)
        {
            while(current < end)
            {
                foreach (Account a in accounts.Values)
                    a.Iterate(current);

                Console.WriteLine(current);

                current = current.AddMonths(1);
            }
        }

        static void GenerateOutput()
        {
            foreach(Account a in accounts.Values)
            {
                a.DumpLog("account-");
            }

            MakeChart();
        }

        static void MakeChart()
        {

        }
    }
}
