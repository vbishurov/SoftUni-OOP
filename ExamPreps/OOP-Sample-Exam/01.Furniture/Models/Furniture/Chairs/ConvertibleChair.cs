namespace FurnitureManufacturer.Models.Furniture.Chairs
{
    using Interfaces;

    class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedHeight = 0.10m;

        private readonly decimal initialHeight;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            this.IsConverted = false;
            this.initialHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.Height = this.IsConverted ? this.initialHeight : ConvertedHeight;
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}
