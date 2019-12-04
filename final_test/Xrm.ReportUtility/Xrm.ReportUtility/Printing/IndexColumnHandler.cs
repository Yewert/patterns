using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Printing
{
    public class IndexColumnHandler : IColumnValueHandler
    {
        public string Title => "№";

        public string Handle(int index, DataRow dataRow)
        {
            return $"{index}";
        }
    }
}