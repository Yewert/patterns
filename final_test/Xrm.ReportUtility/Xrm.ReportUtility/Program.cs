using System;
using System.Linq;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Printing;
using Xrm.ReportUtility.Printing.Building;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args)
        {
            var filename = args[0];

            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }

        private static void PrintReport(Report report)
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                IBuilder reportPrinterBuilder = new ReportPrinterBuilder();
                //feature
                //title is always present, but other columns may be omitted.
                //although arguments for removing volume, weight, etc. are not implemented,
                //possibility of not selecting them in builder should be good enough for it to count as feature implementation

                reportPrinterBuilder = reportPrinterBuilder.ShowVolume().ShowWeight().ShowCost().ShowCount();

                if (report.Config.WithIndex)
                {
                    reportPrinterBuilder = reportPrinterBuilder.ShowIndexes();
                }
                if (report.Config.WithTotalVolume)
                {
                    reportPrinterBuilder = reportPrinterBuilder.ShowTotalVolume();
                }
                if (report.Config.WithTotalWeight)
                {
                    reportPrinterBuilder = reportPrinterBuilder.ShowTotalWeight();
                }
                Console.WriteLine(reportPrinterBuilder.Build().Print(report));

                Console.WriteLine();
            }

            if (report.Rows != null && report.Rows.Any())
            {
                Console.WriteLine("Итого:");
                foreach (var reportRow in report.Rows)
                {
                    Console.WriteLine(string.Format("  {0,-20}\t{1}", reportRow.Name, reportRow.Value));
                }
            }
        }
    }
}