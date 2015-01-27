namespace HumanStudentWorker
{
    using System;
    using System.Text;

    internal class Worker : Human
    {
        private const int WorkDaysPerWeek = 5;

        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Week salary cannot be negative.");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Work hours per day cannot be negative.");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / (this.WorkHoursPerDay * Worker.WorkDaysPerWeek);
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.AppendLine("Week salary: " + this.WeekSalary);
            b.AppendLine("Work hours per day: " + this.WorkHoursPerDay);
            b.Append("Money per hour: " + this.MoneyPerHour());
            return b.ToString();
        }
    }
}
