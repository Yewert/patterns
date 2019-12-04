using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class TitleColumnHandler : IColumnValueHandler
    {
        public string Title => "Наименование";

        public string Handle(int index, DataRow dataRow)
        {
            return $"{dataRow.Name,12}";
        }
    }
}