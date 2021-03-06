﻿using System;
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
        public double StartingCash, EndingCash;
        public double DebtChange = 0, DebtBalance;

        private static string dateFormatter = "yyyy-MM-dd";

        public LogItem(double startingCash, double debtBalance)
        {
            this.StartingCash = startingCash;
            this.EndingCash = StartingCash;
            this.DebtBalance = debtBalance;
        }

        public void Add(LoanIterationResult iteration)
        {
            if (iteration.Status == LoanStatus.Sold)
            {
                if (iteration.Payment == 0) // totally complete
                    return;

                // unscheduled closure
                DebtChange -= iteration.Payment < DebtBalance ? iteration.Payment : DebtBalance;
                DebtBalance -= iteration.Payment;

                if(DebtBalance < 0)
                {
                    OutgoingPayment += -DebtBalance;
                    DebtBalance = 0;
                }
            }

            else if (iteration.Status == LoanStatus.Delinquent)
            {
                OutgoingPayment += iteration.Payment;
                DebtChange += iteration.Payment;
                DebtBalance += iteration.Payment;
            }

            else // LoanStatus == Active
            {
                IncomingPayment += iteration.Payment;
                OutgoingPayment += iteration.Payment;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("|");

            sb.Append(Date.ToString(dateFormatter) + "|");
            sb.Append("$" + IncomingPayment + "|");
            sb.Append("$" + OutgoingPayment + "|");
            sb.Append("$" + StartingCash + "|");
            sb.Append("$" + EndingCash + "|");
            sb.Append("$" + DebtChange + "|");
            sb.Append("$" + DebtBalance + "|");

            return sb.ToString();
        }
    }
}
