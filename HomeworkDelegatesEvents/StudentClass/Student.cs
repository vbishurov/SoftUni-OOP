namespace StudentClass
{
    using System;

    public class Student
    {
        private string name;
        private byte age;

        public Student(string name, byte age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event EventHandler<PropertyChangedEventArgs<string>> PropertyChanged;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name", "Name cannot be empty");
                }

                this.OnPropertyChanged(new PropertyChangedEventArgs<string>("Name", this.Name, value));
                this.name = value;
            }
        }

        public byte Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age", "Age must be in range[0...100]");
                }

                this.OnPropertyChanged(new PropertyChangedEventArgs<string>("Age", this.Age.ToString(), value.ToString()));
                this.age = value;
            }
        }

        private void OnPropertyChanged(PropertyChangedEventArgs<string> eventArgs)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, eventArgs);
            }
        }
    }
}
