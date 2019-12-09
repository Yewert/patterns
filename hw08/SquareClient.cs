namespace hw08
{
    public class SquareClient : FigureClient<Square>
    {
        public SquareClient(Square figure) : base(figure)
        {
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}