namespace PCCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PCCatalog
    {
        public static void Main(string[] args)
        {
            Component graphicsRadeon = new Component("Radeon", 549.67m, "bullshit");
            Component graphicsGeForce = new Component("GeForce", 612.95m, "Very nice graphics card");

            Component procIntel = new Component("Intel", 442.54m, "Awesome");
            Component procAMD = new Component("AMD", 395.427m, "almost there");

            Computer compAMD = new Computer("AMD", new List<Component>() { graphicsRadeon, procAMD });
            Computer compIntel = new Computer("Intel");
            compIntel.Components.Add(procIntel);
            compIntel.Components.Add(graphicsGeForce);

            List<Computer> computers = new List<Computer>() { compIntel, compAMD };

            computers.OrderBy(e => e.Price).ToList().ForEach(e => Console.WriteLine(e.ToString()));
        }
    }
}
