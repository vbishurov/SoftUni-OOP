using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persons
{
    class Persons
    {
        static void Main()
        {
            Person[] persons = new Person[3];
            persons[0] = new Person("Pesho", 20);
            persons[1] = new Person("Gosho", 21,"gosho_tirbushona@abv.bg");
            persons[2] = new Person("Tedi", 14, "mnogo_golqma@abv.bg");

            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
