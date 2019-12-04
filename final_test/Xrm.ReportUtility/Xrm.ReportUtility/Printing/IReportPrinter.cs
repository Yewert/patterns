using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public interface IReportPrinter
    {
        void AppendColumnHandler(IColumnValueHandler handler);
        void PrependColumnHandler(IColumnValueHandler handler);
        string Print(Report report);
    }
}