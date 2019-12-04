using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class TotalWeightColumnHandler : IColumnValueHandler
    {
        public string Title => "Суммарный вес";
        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Weight * dataRow.Count, 13}";
        }
    }
}