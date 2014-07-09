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
            loans = Ingestor.LoadLoans("loans.csv");
            accounts = Ingestor.LoadAccounts("accounts.csv");
        }
    }
}
