namespace BitArray
{
    using System;

    public class BitArrayTest
    {
        public static void Main(string[] args)
        {
            BitArray largeNumber = new BitArray(1337);

            for (int i = 0; i < 1337; i++)
            {
                largeNumber[i] = 1;
            }

            Console.WriteLine(largeNumber);

            BitArray notSoLargeNumber = new BitArray(20);

            notSoLargeNumber[7] = 1;
            Console.WriteLine();
            Console.WriteLine(notSoLargeNumber);

            Console.WriteLine();
            Console.WriteLine(notSoLargeNumber[6]);
            Console.WriteLine(notSoLargeNumber[7]);

            Console.WriteLine();
            Console.WriteLine(notSoLargeNumber.DisplayBits());

            Console.WriteLine();
            Console.WriteLine(largeNumber.DisplayBits());
        }
    }
}
