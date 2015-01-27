namespace School
{
    using System;

    using System.Collections.Generic;

    public class SchoolTest
    {
        public static void Main(string[] args)
        {
            try
            {
                Student pesho = new Student("Pesho", 48076);
                Student gosho = new Student("Gosho", 47895, "izrud");
                Student ivan = new Student("Ivan Georgiev", 48963);
                Student todor = new Student("Todor Popov", 42346);
                Student kiril = new Student("Kiril Ivanov", 45632);
                // Student ginka = new Student("Ginka Markova", 47895); // Causes unique class number exception

                Discipline java = new Discipline("Java", 6, new List<Student>() { pesho, gosho }, "worst course ever");
                Discipline oop = new Discipline("OOP", 14, new List<Student>() { gosho, ivan, todor, kiril });
                Discipline cSharp = new Discipline("C# Basics", 6, new List<Student>() { gosho, todor, kiril });

                Teacher nakov = new Teacher("Svetlin Nakov", new List<Discipline>() { java, oop }, "the best");
                Teacher kolev = new Teacher("Filip Kolev", new List<Discipline>() { cSharp });

                Class firstClass = new Class("Class 1.", new List<Student>() { pesho, gosho, kiril }, new List<Teacher>() { nakov }, "first students ever");
                Class secondClass = new Class("Class 2.", new List<Student>() { pesho, gosho, ivan, todor, kiril }, new List<Teacher>() { nakov, kolev });

                Console.WriteLine(pesho);
                Console.WriteLine();
                Console.WriteLine(gosho);
                Console.WriteLine();

                Console.WriteLine(java);
                Console.WriteLine();
                Console.WriteLine(oop);
                Console.WriteLine();

                Console.WriteLine(nakov);
                Console.WriteLine();
                Console.WriteLine(kolev);
                Console.WriteLine();

                Console.WriteLine(firstClass);
                Console.WriteLine();
                Console.WriteLine(secondClass);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }
    }
}
