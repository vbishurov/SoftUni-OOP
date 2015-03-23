﻿namespace FurnitureManufacturer.Models.Furniture.Chairs
{
    using Interfaces;

    public class Chair : Furniture, IChair
    {
        public Chair(string model, string material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}, Legs: {1}", base.ToString(), this.NumberOfLegs);
        }
    }
}
