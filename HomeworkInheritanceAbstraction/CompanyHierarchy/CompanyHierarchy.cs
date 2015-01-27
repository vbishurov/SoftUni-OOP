namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public class CompanyHierarchy
    {
        public static void Main(string[] args)
        {
            Project suls = new Project("SoftUni Learning System", new DateTime(2014, 2, 16), "Very successful project", "open");
            Project animalShelter = new Project("Animal Shelter", new DateTime(2010, 6, 28), "Help the animals", "closed");
            Project catParadise = new Project("Cat Paradise", new DateTime(2008, 10, 4), "Impossible task", "open");

            Sale notebook = new Sale("Notebook", new DateTime(2014, 10, 26), 2);
            Sale sulsSale = new Sale("SoftUni Learning System", new DateTime(2015, 1, 4), 256314535);
            Sale telerik = new Sale("Telerik", new DateTime(2014, 12, 17), 866583658368536);
            Sale phone = new Sale("Phone", new DateTime(2010, 5, 14), 222);

            Developer pesho = new Developer("Pesho", "Peshev", "izrud1", 8500, "production", new List<Project>() { suls, animalShelter, catParadise });

            SalesEmployee gosho = new SalesEmployee("Gosho", "Petrov", "izrud2", 4300, "sales", new List<Sale>() { notebook, sulsSale, telerik, phone });

            Manager nakov = new Manager("Svetlin", "Nakov", "theBoss", 545245276354, "Accounting", new List<Employee>() { pesho, gosho });

            List<Person> people = new List<Person>() { pesho, gosho, nakov };

            people.ForEach(p => Console.WriteLine(p + Environment.NewLine));
        }
    }
}
