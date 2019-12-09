namespace hw08
{
    public class AnglesCountVisitor : IVisitor
    {
        public void Visit(TriangleClient client)
        {
            client.AnglesCount = 3;
        }

        public void Visit(RectangleClient client)
        {
            client.AnglesCount = 4;
        }

        public void Visit(SquareClient client)
        {
            client.AnglesCount = 4;
        }
    }
}