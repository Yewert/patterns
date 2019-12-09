namespace hw08
{
    public class DrawVisitor : IVisitor
    {
        public void Visit(TriangleClient client)
        {
            client.Picture = new DrawingResult();
        }

        public void Visit(RectangleClient client)
        {
            client.Picture = new DrawingResult();
        }

        public void Visit(SquareClient client)
        {
            client.Picture = new DrawingResult();
        }
    }
}