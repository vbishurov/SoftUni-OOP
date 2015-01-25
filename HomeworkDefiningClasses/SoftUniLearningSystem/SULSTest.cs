namespace SoftUniLearningSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SULSTest
    {
        public static void Main(string[] args)
        {
            Trainer kolev = new JuniorTrainer("Filip", "Kolev", 28);
            SeniorTrainer nakov = new SeniorTrainer("Svetlin", "Nakov");

            Student zavarshil = new GraduateStudent("Zavarshil", "Student", 38678, 5.98f, 23);
            CurrentStudent ivan = new OnsiteStudent("Ivan", "Ivanov", 58945, 5.46f, "OOP", 4, 22);
            CurrentStudent todor = new OnlineStudent("Todor", "Georgiev", 75234, 3.66f, "C# Basics", 20);
            DropoutStudent pesho = new DropoutStudent("Pesho", "Peshev", 46786, 2.54f, "low grades", 45);

            pesho.Reapply();
            Console.WriteLine();

            kolev.CreateCourse("C# Basics");
            Console.WriteLine();

            nakov.DeleteCourse("C# Basics");
            Console.WriteLine();

            List<Person> people = new List<Person>() { kolev, nakov, pesho, zavarshil, ivan, todor };

            people.Where(p => p is CurrentStudent).OrderBy(p => ((Student)p).AverageGrade).ToList().ForEach(p => Console.WriteLine(p + Environment.NewLine));
        }
    }
}
