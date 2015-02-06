namespace InterestCalculator
{
    using System;

    public static class CalculatorMain
    {
        public static void Main()
        {
            InterestCalculator simple = new InterestCalculator(2500, 7.2f, 15, InterestType.simple);

            InterestCalculator compound = new InterestCalculator(500, 5.6f, 10, InterestType.compound);

            Console.WriteLine("{0:0.0000}",compound.CalcInterest);
            Console.WriteLine("{0:0.0000}", simple.CalcInterest);
        }
    }
}
