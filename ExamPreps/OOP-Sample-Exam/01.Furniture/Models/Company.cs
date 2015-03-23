using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    using Interfaces;

    class Company : ICompany
    {
        private const int MinNameLength = 5;
        private const int RegistrationNumberLength = 10;

        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < Company.MinNameLength)
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty or less than 5 sumbols.");
                }

                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value.Length != Company.RegistrationNumberLength)
                {
                    throw new ArgumentException("RegistrationNumber", "Registration Number must be 10 symbols long.");
                }

                if (value.Any(c => !char.IsDigit(c)))
                {
                    throw new ArgumentException("RegistrationNumber", "Registration Number must consist of digits only.");
                }

                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(f => String.Equals(f.Model, model, StringComparison.CurrentCultureIgnoreCase));
        }

        public string Catalog()
        {
            StringBuilder catalog = new StringBuilder();

            catalog.AppendFormat("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count <= 0)
            {
                return catalog.ToString();
            }

            var sortedFurnitures = this.Furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model);

            catalog.AppendLine();
            catalog.Append(string.Join(Environment.NewLine, sortedFurnitures));

            return catalog.ToString();
        }
    }
}
