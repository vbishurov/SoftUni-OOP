namespace RestaurantManager.Models.Recipies.Meals
{
    using System.Text;
    using Interfaces;

    public class Dessert : Meal, IDessert
    {
        public Dessert(
            string name,
            decimal price,
            int calories,
            int quantityPerServing,
            int timeToPrepare,
            bool isVegan,
            bool withSugar = true)
            : base(name, price, calories, quantityPerServing, timeToPrepare, isVegan)
        {
            this.WithSugar = withSugar;
        }

        public bool WithSugar { get; private set; }

        public void ToggleSugar()
        {
            this.WithSugar = !this.WithSugar;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            if (!this.WithSugar)
            {
                result.Append("[NO SUGAR] ");
            }

            result.Append(base.ToString());
            return result.ToString();
        }
    }
}
