namespace ExtensinMethodsLINQ
{
    using System;
    using System.Collections.Generic;

    public static class MainExtensinMethodsLinq
    {
        public static void Main()
        {
            IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine(string.Join(", ", numbers.WhereNot<int>(a => a == 6)));

            Console.WriteLine(string.Join(", ", numbers.Repeat<int>(3)));

            IEnumerable<string> stringItems = new List<string>() { "Plovdiv", "Sofia", "Varna", "Burgas", "Tarnovo" };
            IEnumerable<string> suffixes = new List<string>() { "a", "div" };
            Console.WriteLine(string.Join(", ", stringItems.WhereEndsWith(suffixes)));
        }
    }
}
