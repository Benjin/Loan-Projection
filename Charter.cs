using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Drawing;

namespace Loan_Projection
{
    class Charter
    {
        public static void MakeChart(string filename, string[] months, double[] cashValues, double[] debtValues)
        {
            Chart ch = new Chart();

            ch.Width = 2000;
            ch.Height = 1000;

            ChartArea area = new ChartArea();

            area.AxisX.Interval = 2;
            area.AxisX.Title = "Month";
            area.AxisX.LineColor = Color.LightGray;
            area.AxisX.MajorGrid.LineColor = Color.LightGray;

            area.AxisY.Interval = 2; // 2 billion
            area.AxisY.Title = "Amount - $B";
            area.AxisY.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            ch.ChartAreas.Add(area);

            Series cash = new Series();
            cash.Color = Color.Green;
            cash.ChartType = SeriesChartType.FastLine;
            cash.Points.DataBindXY(months, scaleDown(cashValues, 9)); // 9 = 10^9 value scale downard

            Series debt = new Series();
            debt.Color = Color.Red;
            debt.ChartType = SeriesChartType.FastLine;
            debt.Points.DataBindXY(months, scaleDown(debtValues, 9));

            ch.Series.Add(cash);
            ch.Series.Add(debt);

            FileStream output = File.Open(filename, FileMode.Create);
            ch.SaveImage(output, ChartImageFormat.Png);
            output.Close();
        }

        private static double[] scaleDown(double[] input, int amount)
        {
            double[] output = new double[input.Length];

            for (int i = 0; i < input.Length; i++)
                output[i] = input[i] / Math.Pow(10.0, amount);

            return output;
        }
    }
}
