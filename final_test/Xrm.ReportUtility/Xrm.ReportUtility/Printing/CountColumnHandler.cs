using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class CountColumnHandler : IColumnValueHandler
    {
        public string Title => "Количество";

        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Count,10}";
        }
    }
}