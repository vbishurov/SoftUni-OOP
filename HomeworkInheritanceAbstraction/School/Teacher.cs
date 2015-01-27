namespace School
{
    using System.Collections.Generic;
    using System.Text;

    internal class Teacher : Person
    {
        public Teacher(string name, List<Discipline> disciplines, string details = null)
            : base(name, details)
        {
            this.Disciplines = disciplines;
        }

        public List<Discipline> Disciplines { get; set; }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine(base.ToString());
            b.Append("Disciplines: ");
            foreach (Discipline discipline in this.Disciplines)
            {
                b.AppendLine();
                b.Append(discipline.ToString());
            }

            if (!string.IsNullOrEmpty(this.Details))
            {
                b.AppendLine();
                b.Append("Teacher details: " + this.Details);
            }
            
            return b.ToString();
        }
    }
}
