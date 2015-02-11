namespace Customer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Customer : ICloneable, IComparable<Customer>
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string id;
        private string permanentAddress;
        private string mobilePhone;
        private string email;

        public Customer(
            string firstName,
            string middleName,
            string lastName,
            string id,
            string permanentAddress,
            string mobilePhone,
            string email,
            List<Payment> payments,
            CustumerType custumerType)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Payments = payments;
            this.Type = custumerType;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name", "First name cannot be empty");
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Middle name", "Middle name cannot be empty");
                }

                this.middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name", "Last name cannot be empty");
                }

                this.lastName = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                if (value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException("ID", "ID must be 10 characters long");
                }

                if (value.Any(t => !char.IsDigit(t)))
                {
                    throw new ArgumentException("ID", "ID can consist of numbers only");
                }

                this.id = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Permanent Address", "Permanent Address cannot be empty");
                }

                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Mobile phone", "Product name cannot be empty");
                }

                if (value.Any(t => !char.IsDigit(t) && !char.IsWhiteSpace(t) && t != '-'))
                {
                    throw new ArgumentException("Phone", "Phone can consist of numbers only");
                }

                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Email", "Email cannot be empty");
                }

                this.email = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.MiddleName + " " + this.LastName;
            }
        }

        public List<Payment> Payments { get; private set; }

        public CustumerType Type { get; private set; }

        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(Customer c1, Customer c2)
        {
            return !c1.Equals(c2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Customer))
            {
                return false;
            }

            if (!this.FirstName.Equals(((Customer)obj).FirstName))
            {
                return false;
            }

            if (!this.MiddleName.Equals(((Customer)obj).MiddleName))
            {
                return false;
            }

            if (!this.LastName.Equals(((Customer)obj).LastName))
            {
                return false;
            }

            if (!this.Id.Equals(((Customer)obj).Id))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hash =
                this.FirstName.GetHashCode() + this.MiddleName.GetHashCode() + this.LastName.GetHashCode() + this.Id.GetHashCode();
            return hash;
        }

        public object Clone()
        {
            return new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                this.Payments,
                this.Type);
        }

        public int CompareTo(Customer other)
        {
            var comparisonOfNames = this.FullName.CompareTo(other.FullName);
            if (comparisonOfNames == 0)
            {
                return this.Id.CompareTo(other.Id);
            }
            else
            {
                return comparisonOfNames;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Name: " + this.FullName);
            b.Append("ID: " + this.Id);
            return b.ToString();
        }
    }
}
