namespace hw08
{
    public class RectangleClient : FigureClient<Rectangle>
    {
        public RectangleClient(Rectangle figure) : base(figure)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}