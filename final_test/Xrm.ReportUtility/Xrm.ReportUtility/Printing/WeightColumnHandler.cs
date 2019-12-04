using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class WeightColumnHandler : IColumnValueHandler
    {
        public string Title => "Масса упаковки";

        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Weight,14}";
        }
    }
}