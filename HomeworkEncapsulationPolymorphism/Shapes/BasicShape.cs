namespace Shapes
{
    internal abstract class BasicShape : IShape
    {
        protected BasicShape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        protected double Width { get; private set; }

        protected double Height { get; private set; }

        public abstract double CalculateArea();

        public abstract double CalculatePerimeter();
    }
}
