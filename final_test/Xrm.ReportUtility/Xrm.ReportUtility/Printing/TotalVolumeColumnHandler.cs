using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class TotalVolumeColumnHandler : IColumnValueHandler
    {
        public string Title => "Суммарный объём";
        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Volume * dataRow.Count, 15}";
        }
    }
}