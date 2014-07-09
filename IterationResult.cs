using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class LoanIterationResult
    {
        public LoanStatus Status;
        public double Payment;

        public LoanIterationResult(LoanStatus status, double payment)
        {
            this.Status = status;
            this.Payment = payment;
        }
    }
}
