using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
            StreamWriter outfile = new StreamWriter(prefix + AccountNum + ".csv");

            outfile.WriteLine("|Date|Incoming Payments|Outgoing Payments|Starting Cash Balance|Ending Cash Balance|Debt Taken/Paid Off|Debt Balance|");
            outfile.WriteLine("|----|-----------------|-----------------|---------------------|-------------------|-------------------|------------|");

            foreach(LogItem l in Log)
                outfile.WriteLine(l.ToString());
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
