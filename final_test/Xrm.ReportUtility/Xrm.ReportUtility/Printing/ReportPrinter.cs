using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    class ReportPrinter : IReportPrinter
    {
        private const char Tabulation = '\t';

        private readonly LinkedList<IColumnValueHandler> _handlers = new LinkedList<IColumnValueHandler>();

        public void AppendColumnHandler(IColumnValueHandler handler)
        {
            _handlers.AddLast(handler);
        }

        public void PrependColumnHandler(IColumnValueHandler handler)
        {
            _handlers.AddFirst(handler);
        }

        public string Print(Report report)
        {
            var reportStringBuilder = new StringBuilder();
            foreach (var handler in _handlers) reportStringBuilder.Append(handler.Title).Append(Tabulation);

            reportStringBuilder.AppendLine();

            for (var i = 0; i < report.Data.Length; i++)
            {
                var dataRow = report.Data[i];
                foreach (var handler in _handlers) 
                    //implementation: composite
                    //composite uses tree-like structure with distinct classes for nodes and leaves
                    //this implementation only has 'leaves'
                    reportStringBuilder.Append(handler.Handle(i, dataRow)).Append(Tabulation);

                reportStringBuilder.AppendLine();
            }

            return reportStringBuilder.ToString();
        }
    }
}