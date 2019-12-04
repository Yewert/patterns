namespace Xrm.ReportUtility.Printing.Building
{
    public interface IBuilder
    {
        IBuilder ShowVolume();
        IBuilder ShowWeight();
        IBuilder ShowCost();
        IBuilder ShowCount();
        IBuilder ShowIndexes();
        IBuilder ShowTotalVolume();
        IBuilder ShowTotalWeight();
        IReportPrinter Build();
    }
}