using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public interface IColumnValueHandler
    {
        string Title { get; }
        string Handle(int index, DataRow dataRow);
    }
}