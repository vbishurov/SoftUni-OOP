using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = new DateTime(2014, 1, 31);
            DateTime end = new DateTime(2014, 1, 10);

            TimeSpan diff = start - end;
            Console.WriteLine(diff);
        }
    }
}
