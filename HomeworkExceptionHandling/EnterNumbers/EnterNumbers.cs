namespace EnterNumbers
{
    using System;

    public class EnterNumbers
    {
        public static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int counter = 10;

            for (int i = 0; i < 100; i++)
            {
                start = ReadNumber(start, end - counter + 1);
                counter--;
                if (counter == 0)
                {
                    break;
                }
            }
        }

        public static int ReadNumber(int start, int end)
        {
            int number = 0;
            try
            {
                Console.Write("Enter number such as: {0} < your number {1}: ", start, end);
                number = int.Parse(Console.ReadLine());
                if (!(start < number && number < end))
                {
                    while (!(start < number && number < end))
                    {
                        Console.WriteLine("Your number is not in range [{0}...{1}]", start, end);
                        Console.Write("Enter number such as: {0} < your number {1}: ", start, end);
                        number = int.Parse(Console.ReadLine());
                    }
                }
            }
            catch (FormatException)
            {
                Console.Error.WriteLine("Invalid Number!");
            }

            return number;
        }
    }
}
