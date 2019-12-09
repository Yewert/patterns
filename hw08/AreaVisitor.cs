    using System;

namespace hw08
{
    public class AreaVisitor : IVisitor
    {
        public void Visit(RectangleClient client)
        {
            client.Area = client.Figure.Width * client.Figure.Height;
        }

        public void Visit(SquareClient client)
        {
            client.Area = client.Figure.Side * client.Figure.Side;
        }

        public void Visit(TriangleClient client)
        {
            var (a, b, c) = (client.Figure.A, client.Figure.B, client.Figure.C);
            var p =  ((double)(a + b + c)) / 2;

            client.Area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}