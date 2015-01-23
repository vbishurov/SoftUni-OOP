using System;
using System.Text.RegularExpressions;

namespace Space3D
{
    public class Point3D
    {
        private double x;
        private double y;
        private double z;

        private static readonly Point3D startingPoint;

        static Point3D()
        {
            startingPoint = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public static Point3D StartingPoint
        {
            get
            {
                return Point3D.startingPoint;
            }
        }

        public static double[] ExtractPoint(string line)
        {
            Regex re = new Regex(@"{ (\d+\.?\d*), (\d+\.?\d*), (\d+\.?\d*) }");
            Match match = re.Match(line);
            double[] result = new double[3];
            result[0] = double.Parse(match.Groups[1].Value);
            result[1] = double.Parse(match.Groups[2].Value);
            result[2] = double.Parse(match.Groups[3].Value);
            return result;
        }

        public override string ToString()
        {
            return String.Format("{{ {0:0.##}, {1:0.##}, {2:0.##} }}", this.X, this.Y, this.Z);
        }
    }
}
