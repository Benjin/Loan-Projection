using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class AccountIterationResult
    {
        public double Cash, Debt;

        public AccountIterationResult(double cash, double debt)
        {
            this.Cash = cash;
            this.Debt = debt;
        }
    }
}
