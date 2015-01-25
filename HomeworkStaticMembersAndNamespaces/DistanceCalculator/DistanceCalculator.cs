namespace DistanceCalculator
{
    using System;
    using Space3D;

    public static class DistanceCalculator
    {
        public static double CalcDistance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt(((p2.X - p1.X) * (p2.X - p1.X)) + ((p2.Y - p1.Y) * (p2.Y - p1.Y)) + ((p2.Z - p1.Z) * (p2.Z - p1.Z)));
        }
    }
}
