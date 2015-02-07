namespace Student
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class StudentMain
    {
        public static void Main()
        {
            List<Student> students = new List<Student>()
            {
                new Student("Pesho", "Peshev", 20, "734015", "027886427", "Pesho@abv.bg", new List<int>() { 5, 6 }, 2, "Plovdiv")
            };

            Random rnd = new Random();

            string[] groupNames = { "Plovdiv", "Sofia", "Varna", "Burgas", "Chinese", "Geeks", "Nerds", "Gamers", "Losers" };

            var specialties = new List<StudentSpecialty>() 
            { 
                new StudentSpecialty("Web Developer", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString()),
                new StudentSpecialty("QA", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString()),
                new StudentSpecialty("Web Developer", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString()),
                new StudentSpecialty("QA", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString()),
                new StudentSpecialty("Web Developer", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString()),
                new StudentSpecialty("Java Developer", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString()),
                new StudentSpecialty("Java Developer", rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString())
            };

            using (StreamReader reader = new StreamReader("../../Students-data.txt"))
            {
                string line = reader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    string[] student = Regex.Split(line, @"\s+");
                    line = reader.ReadLine();
                    students.Add(new Student(
                        student[1],
                        student[2],
                        (byte)rnd.Next(0, 100),
                        rnd.Next(1000, 1100).ToString() + rnd.Next(10, 20).ToString(),
                        "+" + rnd.Next(350, 380).ToString() + "2" + rnd.Next(100000, 999999),
                        student[3],
                        new List<int>() { rnd.Next(2, 6), rnd.Next(2, 7), rnd.Next(2, 6), rnd.Next(2, 6) },
                        rnd.Next(0, 100),
                        groupNames[rnd.Next(0, groupNames.Length)]));

                    line = reader.ReadLine();
                }
            }

            //// Problem 04
            // students.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName).ToList().ForEach(Console.WriteLine);

            //// Problem 05
            // students.Where(s => s.FirstName.CompareTo(s.LastName) == -1).ToList().ForEach(Console.WriteLine);

            //// Problem 06
            // students.Where(s => s.Age >= 18 && s.Age <= 24).
            //    Select(s => new { s.FirstName, s.LastName, s.Age }).
            //    ToList()
            //    .ForEach(s => Console.WriteLine("Name: {0} {1}, Age: {2}", s.FirstName, s.LastName, s.Age));

            //// Problem 07
            // students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName).ToList().ForEach(Console.WriteLine);
            // var result = from student in students
            //             orderby student.FirstName descending, student.LastName descending
            //             select student;
            // result.ToList().ForEach(Console.WriteLine);

            ////Problem 08
            // var result = from student in students
            //             where student.Email.EndsWith("@abv.bg")
            //             select student;
            // result.ToList().ForEach(Console.WriteLine);

            ////Problem 09
            // var result = from student in students
            //             where student.Phone.StartsWith("02") ||
            //                   student.Phone.StartsWith("+3592") ||
            //                   student.Phone.StartsWith("+359 2")
            //             select student;
            // result.ToList().ForEach(Console.WriteLine);

            ////Problem 10
            // var result = from student in students
            //             where student.Marks.Contains(6)
            //             select new { Name = student.FirstName + " " + student.LastName, Marks = string.Join(", ", student.Marks) };
            // result.ToList().ForEach(s => Console.WriteLine("Name: {0}, Marks: {1}", s.Name, s.Marks));

            ////Problem 11
            // var result = students.Where(s => s.Marks.Count(m => m == 2) == 2).ToList();
            // result.ForEach(s => Console.WriteLine(s.FirstName + " " + s.LastName + ", " + string.Join(", ", s.Marks)));

            ////Problem 12
            // var result = students.Where(s => Regex.IsMatch(s.FacultyNumber, @"\d\d\d\d14")).ToList();
            // result.ForEach(s => Console.WriteLine("Name: {0} {1}, {2}", s.FirstName, s.LastName, s.FacultyNumber));

            ////Problem 13
            // var result = from student in students
            //             group student by student.GroupName into groups
            //             select new { GroupName = groups.Key, students = string.Join("\n\t", groups.ToList()) };
            // result.ToList().ForEach(s => Console.WriteLine("{0}: \n\t{1}", s.GroupName, s.students));

            // Problem 14
            var result = from student in students
                         join specialty in specialties
                         on student.FacultyNumber equals specialty.FacultyNumber
                         orderby student.FirstName
                         select new
                         {
                             Name = student.FirstName + " " + student.LastName,
                             student.FacultyNumber,
                             Specialty = specialty.SpecialtyName
                         };

            result.ToList().ForEach(s => Console.WriteLine("{0,-15} {1,-15} {2}", s.Name, s.Specialty, s.FacultyNumber));
        }
    }
}
