namespace PCCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class Computer
    {
        private string name;
        private IList<Component> components;

        public Computer(string name)
        {
            this.Name = name;
            this.components = new List<Component>();
        }

        public Computer(string name, IList<Component> components)
            : this(name)
        {
            this.components = components;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty.");
                }

                this.name = value;
            }
        }

        public IList<Component> Components
        {
            get
            {
                return this.components;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Computer components cannot be empty.");
                }

                this.components = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.Components.Sum(element => element.Price);
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendFormat("Name: {0}{1}Price: {2:C}", this.name, Environment.NewLine, this.Price);
            if (this.components != null)
            {
                b.AppendLine();
                foreach (Component component in this.components)
                {
                    b.AppendLine(component.ToString());
                }
            }

            return b.ToString();
        }
    }
}
