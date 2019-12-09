namespace hw08
{
    public class TriangleClient : FigureClient<Triangle>
    {
        public TriangleClient(Triangle figure) : base(figure)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}