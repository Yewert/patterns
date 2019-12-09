using System;

namespace hw08
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var s = new Square(10);
            var r = new Rectangle(10, 20);
            var t = new Triangle(1, 2, 3);
            
            var sc = new SquareClient(s);
            var rc = new RectangleClient(r);
            var tc = new TriangleClient(t);
            
            var arv = new AreaVisitor();
            var anv = new AnglesCountVisitor();
//            var dv = new DrawVisitor();

            sc.Accept(arv);
            rc.Accept(anv);
            Console.WriteLine(sc.Area);
            Console.WriteLine(rc.AnglesCount);
        }
    }
}