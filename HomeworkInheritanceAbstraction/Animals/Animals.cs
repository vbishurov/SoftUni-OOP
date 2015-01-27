namespace Animals
{
    using System;
    using System.Linq;

    public class Animals
    {
        public static void Main(string[] args)
        {
            Cat tom = new Tomcat("Tom", 15);
            Cat pesho = new Tomcat("Pesho", 7);
            Cat lili = new Kitten("Lili", 4);
            Cat gosho = new Tomcat("Gosho", 2);
            Cat bella = new Kitten("Bella", 1);
            Cat kiki = new Kitten("Kiki", 9);

            Cat[] cats = { tom, pesho, gosho, lili, bella, kiki };
            Console.WriteLine("Cat average age: {0:0.}", cats.Average(p => p.Age));

            Dog sharo = new Dog("Sharo", "male", 20);
            Dog giga = new Dog("Giga", "Female", 12);
            Dog aq = new Dog("Aq", "Female", 4);
            Dog juji = new Dog("Juji", "Female", 8);
            Dog aira = new Dog("Aira", "Female", 2);
            Dog malcho = new Dog("Malcho", "Male", 15);

            Dog[] dogs = { sharo, giga, aq, juji, aira, malcho };
            Console.WriteLine("Dog average age: {0:0.}", dogs.Average(p => p.Age));

            Frog binky = new Frog("Binky", "Male", 4);
            Frog bogart = new Frog("Bogart", "Male", 8);
            Frog booney = new Frog("Booney", "Female", 16);
            Frog fricky = new Frog("Fricky", "Female", 18);
            Frog feckles = new Frog("Feckles", "Male", 10);
            Frog foony = new Frog("Foony", "Female", 14);

            Frog[] frogs = { binky, booney, bogart, fricky, feckles, foony };
            Console.WriteLine("Frog average age: {0:0.}", frogs.Average(p => p.Age));
        }
    }
}
