namespace DistanceCalculator
{
    using System;
    using Space3D;

    public class CalcDistTest
    {
        public static void Main(string[] args)
        {
            Point3D p1 = new Point3D(2, 3, 4);
            Point3D p2 = new Point3D(6, 7, 8);
            double distance = DistanceCalculator.CalcDistance(p1, p2);
            Console.WriteLine("{0:F}", distance);
        }
    }
}
