namespace RestaurantManager.Models.Recipies
{
    using System;
    using System.Text;
    using Interfaces;

    public abstract class Recipe : IRecipe
    {
        private const string RequiredParameterMessage = "The {0} is required.";
        private const string PositiveParameterMessage = "The {0} must be positive.";

        private string name;
        private decimal price;
        private int calories;
        private int quantityPerServing;
        private int timeToPrepare;

        protected Recipe(string name, decimal price, int calories, int quantityPerServing, int timeToPrepare, MetricUnit unitOfMeasure)
        {
            this.name = name;
            this.price = price;
            this.calories = calories;
            this.quantityPerServing = quantityPerServing;
            this.timeToPrepare = timeToPrepare;
            this.UnitOfMeasure = unitOfMeasure;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(RequiredParameterMessage, "Name");
                }

                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(PositiveParameterMessage, "Price"));
                }

                this.price = value;
            }
        }

        public virtual int Calories
        {
            get
            {
                return this.calories;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(PositiveParameterMessage, "Calories"));
                }

                this.calories = value;
            }
        }

        public int QuantityPerServing
        {
            get
            {
                return this.quantityPerServing;
            }

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(PositiveParameterMessage, "QuantityPerServing"));
                }

                this.quantityPerServing = value;
            }
        }

        public virtual int TimeToPrepare
        {
            get
            {
                return this.timeToPrepare;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(string.Format(PositiveParameterMessage, "TimeToPrepare"));
                }

                this.timeToPrepare = value;
            }
        }

        public MetricUnit UnitOfMeasure { get; private set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("==  {0} == ${1:F2}", this.Name, this.Price).AppendLine()
                .AppendFormat("Per serving: {0} {1}, {2} kcal", this.QuantityPerServing, this.GetUnitString(), this.Calories).AppendLine()
                .AppendFormat("Ready in {0} minutes", this.TimeToPrepare);
            return result.ToString();
        }

        private string GetUnitString()
        {
            switch (this.UnitOfMeasure)
            {
                case MetricUnit.Grams:
                    return "g";
                case MetricUnit.Milliliters:
                    return "ml";
                default:
                    throw new InvalidOperationException("Invalid type of unit selected.");
            }
        }
    }
}
