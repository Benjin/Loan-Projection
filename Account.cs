using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class Account
    {
        public long AccountNum;
        public DateTime AsOfDate;
        public double Cash;
        public double Debt;
        public HashSet<Loan> Loans;
        public List<LogItem> Log;

        public static Account Build(string[] info)
        {
            Account output = new Account();

            output.AccountNum = long.Parse(info[0]);
            output.AsOfDate = DateTime.Parse(info[1]);
            output.Cash = double.Parse(info[2]);
            output.Debt = double.Parse(info[3]);
            output.Loans = new HashSet<Loan>();
            output.Log = new List<LogItem>();

            return output;
        }

        public void DumpLog(string prefix)
        {

        }

        public void Iterate(DateTime currentDate)
        {
            LogItem accountLog = new LogItem(Cash, Debt);
            accountLog.Date = currentDate;

            foreach(Loan l in Loans)
            {
                IterationResult currentResult = l.Iterate(currentDate);
                accountLog.Add(currentResult);
            }

            Log.Add(accountLog);
        }
    }
}
