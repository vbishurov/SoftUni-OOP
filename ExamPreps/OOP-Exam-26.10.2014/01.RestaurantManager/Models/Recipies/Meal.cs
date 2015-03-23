namespace RestaurantManager.Models.Recipies
{
    using System.Text;
    using Interfaces;

    public abstract class Meal : Recipe, IMeal
    {
        private const MetricUnit MealUnitOfMeasure = MetricUnit.Grams;

        protected Meal(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan)
            : base(name, price, calories, quantityPerServing, timeToPrepare, Meal.MealUnitOfMeasure)
        {
            this.IsVegan = isVegan;
        }

        public bool IsVegan { get; private set; }

        public virtual void ToggleVegan()
        {
            this.IsVegan = !this.IsVegan;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (this.IsVegan)
            {
                result.Append("[VEGAN] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
