﻿namespace Space3D
{
    using System;
    using System.Globalization;
    using System.Threading;

    public class TestPoint
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Point3D point = new Point3D(4, 6.32645623623642, 7.239864527364287);

            Console.WriteLine(point);
            Console.WriteLine(Point3D.StartingPoint);
        }
    }
}
