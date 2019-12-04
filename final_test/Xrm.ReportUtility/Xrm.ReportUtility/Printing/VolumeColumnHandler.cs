using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class VolumeColumnHandler : IColumnValueHandler
    {
        public string Title => "Объём упаковки";

        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Volume,14}";
        }
    }
}