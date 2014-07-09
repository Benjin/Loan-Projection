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
        long Id;
        Account Owner;
        double UnpaidBalance;
        double PaymentAmount;
        LoanStatus Status;
    }
}
