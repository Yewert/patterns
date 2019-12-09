namespace hw08
{
    public abstract class FigureClient<TFigure> where TFigure : IFigure
    {
        public readonly TFigure Figure;
        public double Area { get; set; }
        public int AnglesCount { get; set; }

        public DrawingResult Picture { get; set; }

        protected FigureClient(TFigure figure)
        {
            Figure = figure;
        } 

        public abstract void Accept(IVisitor visitor);
    }
}