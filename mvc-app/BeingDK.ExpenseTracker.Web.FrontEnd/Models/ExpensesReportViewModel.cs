using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Helpers;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Models
{
    public class Graph 
    {
        public string XCoordinate { get; set; }
        public string YCoordinate { get; set; }
    }

    public partial class ExpensesReportViewModel
    {
        public IEnumerable<Expense> Expenses = Enumerable.Empty<Expense>();
        private readonly AppDataContext db = new AppDataContext();
        public string GraphUrl { get; set; }

        [Required]
        public DateTime SelectedMonth { get; set; }

        internal ExpensesReportViewModel Get()
        {
            var month = SelectedMonth.Month;
            var year = SelectedMonth.Year;
            var firstDayOfMonth = new DateTime(year, month, 1);
            var daysInMonth = DateTime.DaysInMonth(year, month);
            var lastDayOfMonth = new DateTime(year, month, daysInMonth);

            Expenses = db.Expenses.Where(x => x.IncurredAt >= firstDayOfMonth && x.IncurredAt <= lastDayOfMonth)
                                  .OrderBy(x=>x.IncurredAt)
                                  .ToList();

            var graphData = Expenses.GroupBy(x => x.IncurredAt)
                    .Select(x => new Graph { XCoordinate = x.Key.ToString("dd-MM-yyyy")
                    , YCoordinate = x.Sum(y => y.Amount).ToString() })
                    .ToList();


            if(graphData!=null && graphData.Any())
            {
                var chartWebImage = new Chart(width: 900, height: 500, theme: ChartTheme.Yellow)
                                   .AddTitle("Monthly expenses")
                                   .AddSeries("Default", chartType: "Line",
                                       xValue: graphData, xField: "XCoordinate",
                                       yValues: graphData, yFields: "YCoordinate")
                                   .ToWebImage();

                if (chartWebImage != null)
                {
                    var imagePath = @"images\" + Guid.NewGuid() + ".jpeg";
                    chartWebImage.Save(@"~\" + imagePath);
                    GraphUrl = imagePath;
                }
            }

            return this;
        }
    }
}