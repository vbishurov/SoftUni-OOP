namespace Paths
{
    using System;
    using System.IO;
    using System.Text;
    using Space3D;

    internal static class Storage
    {
        public static Paths3D LoadPaths(string file)
        {
            try
            {
                Paths3D paths = new Paths3D();
                using (StreamReader reader = new StreamReader(file))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        string[] lineSplitted = line.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        double[] pointCoordinates = Point3D.ExtractPoint(line);
                        Point3D point = new Point3D(pointCoordinates[0], pointCoordinates[1], pointCoordinates[2]);
                        paths.Add(point);
                        line = reader.ReadLine();
                    }
                }

                return paths;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e.InnerException;
            }
        }

        public static void SavePaths(Paths3D paths, string file, bool append = false)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file, append, Encoding.UTF8))
                {
                    foreach (Point3D point3D in paths)
                    {
                        writer.WriteLine(point3D);
                    }

                    string action = append == true ? "appended to" : "overwritten";
                    Console.WriteLine("File {0} successfully", action);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e.InnerException;
            }
        }
    }
}
