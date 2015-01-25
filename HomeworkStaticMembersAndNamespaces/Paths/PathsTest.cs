namespace Paths
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Space3D;

    public class PathsTest
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Point3D a = new Point3D(0, 1, 1);
            Point3D b = new Point3D(1, 1, 1);
            Point3D c = new Point3D(0, 1, 0);
            Point3D d = new Point3D(1, 1, 0);
            Point3D e = new Point3D(0, 0, 1);
            Point3D f = new Point3D(1, 0, 1);
            Point3D g = Point3D.StartingPoint;
            Point3D h = new Point3D(1, 0, 0);

            List<Point3D> points = new List<Point3D>() { a, b, c, d, e, f, g, h };

            // Paths3D paths = new Paths3D(points); // Constructor from list
            Paths3D paths = new Paths3D(a, b, c, d, e, f, g, h); // Constructor from params
            
            Console.WriteLine(paths.ToString());

            paths[4] = new Point3D(7, 7, 8);
            Console.WriteLine(paths[4]);

            Console.WriteLine(paths.Count);
            paths.Add(new Point3D(2, 3, 4));
            Console.WriteLine(paths.Count);

            Paths3D testStorage = Storage.LoadPaths("../../input.txt");
            Console.WriteLine(testStorage);

            // Storage.SavePaths(paths, "../../output.txt", true); // Appending
            Storage.SavePaths(paths, "../../output.txt"); // Overwriting

            Console.WriteLine();
            testStorage = Storage.LoadPaths("../../output.txt");
            Console.WriteLine(testStorage);
        }
    }
}
