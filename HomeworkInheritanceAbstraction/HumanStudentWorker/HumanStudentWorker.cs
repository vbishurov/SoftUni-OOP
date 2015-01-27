namespace HumanStudentWorker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HumanStudentWorker
    {
        public static void Main(string[] args)
        {
            Student pesho = new Student("Pesho", "Peshev", "bKn67b4fjE");
            Student tosho = new Student("Tosho", "Toshev", "r7mmgfJJsf");
            Student gosho = new Student("Georgi", "Ivanov", "iYqGIHx");
            Student kiril = new Student("Kiril", "Todorov", "IAK3H");
            Student ivan = new Student("Ivan", "Petrov", "LK0cNKwmW");
            Student dragan = new Student("Dragan", "Cankov", "okAvu07GUR");
            Student ginka = new Student("Ginka", "Tuhluva", "GWkafEUrT");
            Student minka = new Student("Minka", "Todorova", "PHTsQ");
            Student john = new Student("John", "Lennon", "y3mlX4F");
            Student allison = new Student("Allison", "DiLaurentis", "EV0ytP38Og");

            // Student exception1 = new Student("Exception", "Test", "EV0"); // Too short exception
            // Student exception2 = new Student("Exception", "Test", "sa0ajsk_"); // Too short exception

            Worker alberte = new Worker("Albert", "Haas", 1865.435m, 6);
            Worker roderic = new Worker("Roderic", "Mlakaar", 3050.1156m, 12);
            Worker gregor = new Worker("Gregor", "Raimondi", 3721.1626m, 11);
            Worker lorens = new Worker("Lorens", "Ratti", 987.474m, 3);
            Worker vincentius = new Worker("Vincentius", "Himura", 1085.4747m, 4);
            Worker ulvi = new Worker("Ulvi", "Everett", 1289.1376m, 4);
            Worker dalton = new Worker("Dalton", "MacIver", 2340.4874m, 10);
            Worker silvio = new Worker("Silvio", "Osbourne", 3860.546m, 7);
            Worker fabijan = new Worker("Fabijan", "Mingo", 475.1867m, 14);
            Worker shou = new Worker("Shou", "Charmchi", 1816.651m, 11);

            List<Student> students = new List<Student>()
            {
                pesho, 
                gosho, 
                tosho, 
                kiril, 
                ivan,
                dragan,
                ginka, 
                minka,
                john, 
                allison
            };
            var sortedStudents = students.OrderBy(p => p.FacultyNumber);
            foreach (Student student in sortedStudents)
            {
                Console.WriteLine("Name: {0} {1}, Faculty number: {2}", student.FirstName, student.LastName, student.FacultyNumber);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>()
            {
                alberte, 
                roderic,
                gregor,
                lorens, 
                vincentius,
                ulvi, 
                dalton, 
                silvio, 
                fabijan, 
                shou
            };
            var sortedWorkers = workers.OrderByDescending(p => p.MoneyPerHour());
            foreach (Worker worker in sortedWorkers)
            {
                Console.WriteLine("Name: {0} {1}, Money per hour: {2:0.##}$", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }

            Console.WriteLine();

            List<Human> humans = new List<Human>();
            humans.AddRange(students);
            humans.AddRange(workers);
            var sortedHumans = humans.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);
            foreach (Human human in sortedHumans)
            {
                Console.WriteLine("Name: {0} {1}", human.FirstName, human.LastName);
            }
        }
    }
}
