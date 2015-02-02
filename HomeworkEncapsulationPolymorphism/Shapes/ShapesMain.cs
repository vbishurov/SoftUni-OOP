namespace Shapes
{
    using System;
    using System.Collections.Generic;

    public static class ShapesMain
    {
        public static void Main(string[] args)
        {
            Rectangle rect1 = new Rectangle(2, 3);
            Rectangle rect2 = new Rectangle(8, 12);

            Triangle triangle1 = new Triangle(3, 1);
            Triangle triangle2 = new Triangle(20, 8);

            Circle circle1 = new Circle(5);
            Circle circle2 = new Circle(20);

            List<IShape> shapes = new List<IShape>() { rect1, triangle1, circle1, rect2, triangle2, circle2 };

            Console.WriteLine("Areas: ");
            shapes.ForEach(p => Console.WriteLine(p.CalculateArea()));

            Console.WriteLine();

            Console.WriteLine("Perimeters:");
            shapes.ForEach(p => Console.WriteLine(p.CalculatePerimeter()));
        }
    }
}
