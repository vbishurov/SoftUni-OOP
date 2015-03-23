﻿namespace FurnitureManufacturer
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Threading;
    using Engine;

    public class FurnitureProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            FurnitureManufacturerEngine.Instance.Start();
        }
    }
}
