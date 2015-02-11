namespace Customer
{
    using System;
    using System.Collections.Generic;

    public static class CustomerMain
    {
        public static void Main()
        {
            Customer c1 = new Customer(
                "Pesho",
                "Petkov",
                "Peshev",
                "1234567890",
                "Address",
                "7824266487",
                "pesho@abv.bg",
                new List<Payment>(),
                CustumerType.OneTime);

            Customer c2 = new Customer(
                "Pesho",
                "Petkov",
                "Peshev",
                "1234567890",
                "Address",
                "7824266487",
                "pesho@abv.bg",
                new List<Payment>(),
                CustumerType.OneTime);

            Console.WriteLine(c1 != c2);
        }
    }
}
