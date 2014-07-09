using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class Account
    {
        long Accountum;
        DateTime AsOfDate;
        double Cash;
        double Debt;
        HashSet<Loan> Loans;

    }
}
