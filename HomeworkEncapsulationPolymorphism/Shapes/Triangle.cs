namespace Shapes
{
    internal class Triangle : BasicShape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateArea()
        {
            return (this.Width * this.Height) / 2;
        }

        public override double CalculatePerimeter()
        {
            return this.Width * 3;
        }
    }
}
