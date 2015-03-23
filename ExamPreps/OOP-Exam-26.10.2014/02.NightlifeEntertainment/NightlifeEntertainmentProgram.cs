namespace NightlifeEntertainment
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using Models.Logic;

    public class NightlifeEntertainmentProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            CinemaEngine engine = new ImprovedCinemaEngine();
            StartOperations(engine);
        }

        private static void StartOperations(CinemaEngine engine)
        {
            string line = Console.ReadLine();
            while (line != "end")
            {
                engine.ParseCommand(line);
                line = Console.ReadLine();
            }

            Console.Write(engine.Output);
        }
    }
}
