using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Loan_Projection
{
    class Ingestor
    {
        public static Dictionary<long, Account> LoadAccounts(string filename)
        {
            Dictionary<long, Account> output = new Dictionary<long, Account>();

            StreamReader input = new StreamReader(filename);
            string line;

            input.ReadLine(); // skip the header line

            while ((line = input.ReadLine()) != null)
            {
                string[] info = line.Split('|');
                Account account = Account.Build(info);
                output.Add(account.AccountNum, account);
            }

            Console.WriteLine("" + output.Count + " accounts successfully parsed");

            return output;
        }

        public static Dictionary<long, Loan> LoadLoans(string filename, Dictionary<long, Account> accounts)
        {
            Dictionary<long, Loan> output = new Dictionary<long, Loan>();

            StreamReader input = new StreamReader(filename);
            string line;

            input.ReadLine(); // skip the header line

            while ((line = input.ReadLine()) != null)
            {
                string[] info = line.Split('|');
                Loan loan = Loan.Build(info);
                Account owner = accounts[long.Parse(info[1])];

                loan.Owner = owner; // get the account object
                owner.Loans.Add(loan); // bidirectional link

                output.Add(loan.Id, loan);
            }

            Console.WriteLine("" + output.Count + " loans successfully parsed");

            return output;
        }
    }
}
