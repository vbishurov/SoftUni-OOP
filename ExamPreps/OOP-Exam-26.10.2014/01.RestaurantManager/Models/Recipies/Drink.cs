namespace RestaurantManager.Models.Recipies
{
    using System;
    using System.Text;
    using Interfaces;

    public class Drink : Recipe, IDrink
    {
        private const MetricUnit DrinkUnitOfMeasure = MetricUnit.Milliliters;
        private const string InvalidDrinkArgumentMessage = "The {0} for a drink must not be greater than {1}";
        private const int MaxDrinkCalories = 100;
        private const string MaxDrinkTimeToPrepare = "20 minutes";

        public Drink(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isCarbonated)
            : base(name, price, calories, quantityPerServing, timeToPrepare, Drink.DrinkUnitOfMeasure)
        {
            this.IsCarbonated = isCarbonated;
        }

        public bool IsCarbonated { get; private set; }

        public override int Calories
        {
            get
            {
                return base.Calories;
            }

            protected set
            {
                if (value > 100)
                {
                    throw new InvalidOperationException(
                        string.Format(Drink.InvalidDrinkArgumentMessage, "Calories", Drink.MaxDrinkCalories));
                }

                base.Calories = value;
            }
        }

        public override int TimeToPrepare
        {
            get
            {
                return base.TimeToPrepare;
            }

            protected set
            {
                if (value > 20)
                {
                    throw new InvalidOperationException(
                        string.Format(Drink.InvalidDrinkArgumentMessage, "TimeToPrepare", Drink.MaxDrinkTimeToPrepare));
                }

                base.TimeToPrepare = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(base.ToString())
                .AppendFormat("Carbonated: {0}", this.IsCarbonated ? "yes" : "no");
            return result.ToString();
        }
    }
}
