namespace hw08
{
    public class Rectangle : IFigure
    {
        public readonly int Width;
        public readonly int Height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}