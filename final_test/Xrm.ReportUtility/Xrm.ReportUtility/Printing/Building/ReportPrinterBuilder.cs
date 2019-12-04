using System;
using System.Collections.Generic;

namespace Xrm.ReportUtility.Printing.Building
{
    //implementation: fluent builder
    public class ReportPrinterBuilder : IBuilder
    {
        private readonly IReportPrinter _reportPrinter;
        
        public ReportPrinterBuilder()
        {
            _reportPrinter = new ReportPrinter();
            _reportPrinter.AppendColumnHandler(new TitleColumnHandler());
        }

        private ReportPrinterBuilder(IReportPrinter reportPrinter)
        {
            _reportPrinter = reportPrinter;
        }

        public IBuilder ShowVolume()
        {
            _reportPrinter.AppendColumnHandler(new VolumeColumnHandler());
            return this;
        }

        public IBuilder ShowWeight()
        {
            _reportPrinter.AppendColumnHandler(new WeightColumnHandler());
            return this;
        }

        public IBuilder ShowCost()
        {
            _reportPrinter.AppendColumnHandler(new CostColumnHandler());
            return this;
        }

        public IBuilder ShowCount()
        {
            _reportPrinter.AppendColumnHandler(new CountColumnHandler());
            return this;
        }

        public IBuilder ShowIndexes()
        {
            _reportPrinter.PrependColumnHandler(new IndexColumnHandler());
            return this;
        }

        public IBuilder ShowTotalVolume()
        {
            _reportPrinter.AppendColumnHandler(new TotalVolumeColumnHandler());
            return this;
        }

        public IBuilder ShowTotalWeight()
        {
            _reportPrinter.AppendColumnHandler(new TotalWeightColumnHandler());
            return this;
        }

        public IReportPrinter Build()
        {
            return _reportPrinter;
        }
    }

}