namespace FractionCalculator
{
    using System;

    public struct Fraction
    {
        private long numerator;

        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator / this.GreatestCommonDiviser(numerator, denominator);
            this.Denominator = denominator / this.GreatestCommonDiviser(numerator, denominator);
        }

        public long Numerator
        {
            get
            {
                return this.numerator;
            }

            set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArithmeticException("Cannot divide by 0");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            long greatestCommonFactor = a.Denominator * b.Denominator;
            Fraction result = new Fraction(
                (a.Numerator * b.Denominator) + (b.Numerator * a.Denominator),
                greatestCommonFactor);
            return result;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            long greatestCommonFactor = a.Denominator * b.Denominator;
            Fraction result = new Fraction(
                (a.Numerator * b.Denominator) - (b.Numerator * a.Denominator),
                greatestCommonFactor);
            return result;
        }

        public override string ToString()
        {
            double result = (double)this.Numerator / this.Denominator;
            return result.ToString();
        }

        private long GreatestCommonDiviser(long a, long b)
        {
            long valueA;
            while (a % b != 0)
            {
                valueA = a;
                a = b;
                b = valueA % b;
            }

            return b;
        }
    }
}
