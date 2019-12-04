using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class CostColumnHandler : IColumnValueHandler
    {
        public string Title => "Стоимость";

        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Cost,9}";
        }
    }
}