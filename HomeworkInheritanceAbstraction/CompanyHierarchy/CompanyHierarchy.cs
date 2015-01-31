namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using Models;
    using People;

    public class CompanyHierarchyTest
    {
        public static Project suls = new Project("SoftUni Learning System", new DateTime(2014, 2, 16), "Very successful project", "open");
        public static Project animalShelter = new Project("Animal Shelter", new DateTime(2010, 6, 28), "Help the animals", "closed");
        public static Project catParadise = new Project("Cat Paradise", new DateTime(2008, 10, 4), "Impossible task", "open");

        public static Sale notebook = new Sale("Notebook", new DateTime(2014, 10, 26), 2);
        public static Sale sulsSale = new Sale("SoftUni Learning System", new DateTime(2015, 1, 4), 256314535);
        public static Sale telerik = new Sale("Telerik", new DateTime(2014, 12, 17), 866583658368536);
        public static Sale phone = new Sale("Phone", new DateTime(2010, 5, 14), 222);

        public static Developer pesho = new Developer("Pesho", "Peshev", "izrud1", 8500, "production", new List<Project>() { suls, animalShelter, catParadise });

        public static SalesEmployee gosho = new SalesEmployee("Gosho", "Petrov", "izrud2", 4300, "sales", new List<Sale>() { notebook, sulsSale, telerik, phone });

        public static Manager nakov = new Manager("Svetlin", "Nakov", "theBoss", 545245276354, "Accounting", new List<Employee>() { pesho, gosho });

        public static List<Person> people = new List<Person>() { pesho, gosho, nakov };

        public static void Main(string[] args)
        {
            people.ForEach(p => Console.WriteLine(p + Environment.NewLine));
        }
    }
}
