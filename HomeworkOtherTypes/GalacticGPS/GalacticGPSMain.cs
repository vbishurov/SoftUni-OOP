namespace GalacticGPS
{
    using System;

    public static class GalacticGpsMain
    {
        public static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
