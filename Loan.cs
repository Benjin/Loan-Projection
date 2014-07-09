using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    enum LoanStatus { Active, Delinquent, Sold };

    class Loan
    {
        public long Id;
        public Account Owner;
        public DateTime AsOfDate;
        public double UnpaidBalance;
        public double PaymentAmount;
        public LoanStatus Status;

        public DateTime delinquencyExpiration;

        private static Random rand = new Random();

        public static Loan Build(string[] info)
        {
            Loan output = new Loan();

            output.Id = long.Parse(info[0]);
            output.AsOfDate = DateTime.Parse(info[2]);
            output.UnpaidBalance = double.Parse(info[3]);
            output.PaymentAmount = double.Parse(info[4]);
            output.Status = (LoanStatus)Enum.Parse(typeof(LoanStatus), info[5]);

            if (output.Status == LoanStatus.Delinquent)
                output.delinquencyExpiration = output.AsOfDate.AddYears(2);

            return output;
        }

        public IterationResult Iterate(DateTime currentDate)
        {
            if (Status == LoanStatus.Delinquent)
            {
                if(currentDate > delinquencyExpiration) // time to sell off the loan
                {
                    Status = LoanStatus.Sold;
                    return new IterationResult(LoanStatus.Sold, UnpaidBalance / 2);
                }
                else
                    return new IterationResult(LoanStatus.Delinquent, PaymentAmount);

            }

            if (Status == LoanStatus.Sold)
                return new IterationResult(LoanStatus.Sold, 0);

            // currently active

            // sell off loan
            if(rand.NextDouble() < 0.01)
            {
                IterationResult output = new IterationResult(LoanStatus.Active, UnpaidBalance); // leave as Active in result b/c payment
                Status = LoanStatus.Sold;
                UnpaidBalance = 0;
                return output;
            }

            // goes delinquent
            else if(rand.NextDouble() < 0.02)
            {
                Status = LoanStatus.Delinquent;
                delinquencyExpiration = currentDate.AddYears(2);
                return new IterationResult(LoanStatus.Delinquent, PaymentAmount);
            }

            // make payment
            else
            {
                UnpaidBalance -= 0.8 * PaymentAmount;
                return new IterationResult(LoanStatus.Active, PaymentAmount);
            }
        }
    }
}
