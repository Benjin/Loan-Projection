using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loan_Projection
{
    class OverallRecord
    {
        List<DateTime> dateList;
        List<double> cashList;
        List<double> debtList;

        public OverallRecord()
        {
            dateList = new List<DateTime>();
            cashList = new List<double>();
            debtList = new List<double>();
        }

        public string[] DateList
        {
            get
            {
                string[] output = new string[dateList.Count];

                int i = 0;

                foreach(DateTime date in dateList)
                {
                    output[i] = date.ToString("MMM yyyy");
                    i++;
                }

                return output;
            }
        }

        public double[] CashList
        {
            get
            {
                return cashList.ToArray<double>();
            }
        }

        public double[] DebtList
        {
            get
            {
                return debtList.ToArray<double>();
            }
        }

        public void Add(DateTime date, double cash, double debt)
        {
            dateList.Add(date);
            cashList.Add(cash);
            debtList.Add(debt);
        }
    }
}
