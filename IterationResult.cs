using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class IterationResult
    {
        public LoanStatus Status;
        public double Payment;

        public IterationResult(LoanStatus status, double payment)
        {
            this.Status = status;
            this.Payment = payment;
        }
    }
}
