namespace StringDisperser
{
    using System;

    public static class StringDisperserMain
    {
        public static void Main()
        {
            StringDisperser stringDisperser = new StringDisperser(new[] { "gosho", "pesho", "tanio" });
            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");
            }

            Console.WriteLine();
        }
    }
}
