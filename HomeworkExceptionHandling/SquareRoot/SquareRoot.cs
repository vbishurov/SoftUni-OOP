using System;

namespace SquareRoot
{
    class SquareRoot
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0)
                {
                    throw new ArgumentOutOfRangeException("Square root for negative numbers is undefined.");
                }
                Console.WriteLine("Square root from: {0} is {1}", number, Math.Sqrt(number));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.Error.WriteLine("Square root of negative number is undefined.");
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good Bye.");
            }
        }
    }
}
