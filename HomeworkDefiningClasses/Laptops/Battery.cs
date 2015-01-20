using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laptops
{
    class Battery
    {
        //Fields
        private string type;
        private float life;

        //Constructors
        public Battery(string type)
        {
            this.Type = type;
        }

        public Battery(string type, float life)
            : this(type)
        {
            this.Life = life;
        }

        //Properties
        public string Type
        {
            get { return this.type; }
            set
            {
                if (value != null && value.Length < 1)
                {
                    throw new ArgumentException("Battery type cannot be empty.");
                }
                this.type = value;
            }
        }

        public float Life
        {
            get { return this.life; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Battery life cannot be negative.");
                }
                this.life = value;
            }
        }

        public override string ToString()
        {
            string result = null;
            if (this.Type != null)
            {
                result = "Battery: " + this.Type;
            }
            if (this.Life > 0)
            {
                result += Environment.NewLine + "Battery Life: " + this.Life + " hours";
            }
            return result;
        }
    }
}
