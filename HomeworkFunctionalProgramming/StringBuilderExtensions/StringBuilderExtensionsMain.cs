namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StringBuilderExtensionsMain
    {
        public static void Main()
        {
            StringBuilder sb = new StringBuilder("Some text Some text Some text Some text Some text Some text Some text ");
            IEnumerable<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

            Console.WriteLine(sb.Substring(10, 20));
            Console.WriteLine(sb.RemoveText("ion method"));
            Console.WriteLine(sb.AppendAll<int>(numbers));
        }
    }
}
