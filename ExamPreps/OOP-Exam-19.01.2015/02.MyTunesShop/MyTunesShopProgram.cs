﻿namespace MyTunesShop
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using Logic;

    public class MyTunesShopProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            MyTunesEngine engine = new ImprovedMyTunesEngine();
            StartOperations(engine);
        }

        private static void StartOperations(MyTunesEngine engine)
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                if (line == string.Empty)
                {
                    line = Console.ReadLine();
                    continue;
                }

                engine.ParseCommand(line);
                line = Console.ReadLine();
            }

            string printerResult = engine.Printer.SendToConsole();
            Console.Write(printerResult);
        }
    }
}
