using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace Loan_Projection
{
    class Charter
    {
        public static void MakeChart(string filename, string[] months, double[] cashValues, double[] debtValues)
        {
            Chart ch = new Chart();

            ch.Width = 2000;
            ch.Height = 1000;

            ch.ChartAreas.Add(new ChartArea());

            Series cash = new Series();
            cash.Points.DataBindXY(months, cashValues);

            Series debt = new Series();
            debt.Points.DataBindXY(months, debtValues);

            ch.Series.Add(cash);
            ch.Series.Add(debt);

            ch.ChartAreas[0].AxisX.Interval = 2;
            ch.ChartAreas[0].AxisY.Interval = 5000000; // 5 million
            ch.ChartAreas[0].AxisY.Title = "Amount (interval: $5M)";
            ch.ChartAreas[0].AxisX.Title = "Month";

            FileStream output = File.Open(filename, FileMode.Create);
            ch.SaveImage(output, ChartImageFormat.Png);
            output.Close();
        }
    }
}
