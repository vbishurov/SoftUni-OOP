using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Laptops
{
    class Laptop
    {
        private string model;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphics;
        private string hdd;
        private string screen;
        private Battery battery;
        private decimal price;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer = null, string processor = null,
            string ram = null, string hdd = null, string graphics = null, Battery battery = null, string screen = null)
            : this(model, price)
        {
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.Graphics = graphics;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Battery = battery;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Model cannot be empty");
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Manufacturer cannot be empty");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Processor cannot be empty");
                }
                this.processor = value;
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                var amount = Int32.Parse(Regex.Match(value, @"-?\d+").Value);
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Ram cannot be empty");
                }
                if (amount < 0)
                {
                    throw new ArgumentOutOfRangeException("Ram Memory cannot be negative number");
                }
                this.ram = value;
            }
        }

        public string Graphics
        {
            get { return this.graphics; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Graphics Card cannot be empty");
                }
                this.graphics = value;
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (value != null)
                {
                    var size = Int32.Parse(Regex.Match(value, @"-?\d+").Value);
                    if (size < 0)
                    {
                        throw new ArgumentOutOfRangeException("HDD size cannot be negative");
                    }
                    if (value.Length < 1)
                    {
                        throw new ArgumentException("HDD cannot be empty");
                    }
                }

                this.hdd = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Screen cannot be empty");
                }
                this.screen = value;
            }
        }

        public Battery Battery { get; set; }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Model: " + this.Model);
            if (this.Manufacturer != null)
            {
                b.AppendLine("Manufacturer: " + this.Manufacturer);
            }
            if (this.Processor != null)
            {
                b.AppendLine("Processor: " + this.Processor);
            }
            if (this.Ram != null)
            {
                b.Append("RAM: " + this.Ram);
                if (Regex.IsMatch(this.ram, @"^\d+$")) 
                {
                    b.Append(" GB");
                }
                b.AppendLine();
            }
            if (this.Hdd != null)
            {
                b.AppendLine("HDD: " + this.Hdd);
            }
            if (this.Screen != null)
            {
                b.AppendLine("Screen: " + this.Screen);
            }
            if (this.Battery != null)
            {
                b.AppendLine(this.Battery.ToString());
            }
            b.Append("Price: " + this.Price);

            return b.ToString();
        }
    }
}
