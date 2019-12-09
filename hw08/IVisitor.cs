namespace hw08
{
    public interface IVisitor
    {
        void Visit(TriangleClient client);
        void Visit(RectangleClient client);
        void Visit(SquareClient client);
    }
}