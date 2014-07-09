using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class LogItem
    {
        public DateTime Date;
        public double IncomingPayment = 0, OutgoingPayment = 0;
        public double StartingCash, EndingCash = 0;
        public double DebtChange = 0, DebtBalance = 0;

        public LogItem(double startingCash, double debtBalance)
        {
            this.StartingCash = startingCash;
            this.DebtBalance = debtBalance;
        }

        public void Add(IterationResult iteration)
        {
            if (iteration.Status == LoanStatus.Sold) { }

            else if (iteration.Status == LoanStatus.Delinquent)
            {

            }

            else // LoanStatus == Active
            {

            }
        }
    }
}
