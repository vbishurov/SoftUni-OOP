namespace Student
{
    using System.Collections.Generic;

    public class Student
    {
        public Student(
            string firstName,
            string lastName,
            byte age,
            string facultyNumber,
            string phone,
            string email,
            IList<int> marks,
            int groupNumber,
            string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public byte Age { get; private set; }

        public string FacultyNumber { get; private set; }

        public string Phone { get; private set; }

        public string Email { get; private set; }

        public IList<int> Marks { get; private set; }

        public int GroupNumber { get; private set; }

        public string GroupName { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
