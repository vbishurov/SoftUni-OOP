namespace Laptops
{
    using System;

    public class Laptops
    {
        public static void Main(string[] args)
        {
            Battery lion = new Battery("Li-Ion, 4-cells, 2550 mAh");
            Battery nicd = new Battery("Ni-Cd", 4.5f);
            Laptop laptopOne = new Laptop("Lenovo Yoga 2 Pro", 869.88m, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "128GB SSD", "Intel HD Graphics 4400", lion, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
            Laptop laptopTwo = new Laptop("Aspire E3-111-C5GL", 259.49m);
            Laptop laptopThree = new Laptop("Acer some model", 1567.43m, battery: nicd, processor: "3.2 GHz", ram: "16 GB");
            Laptop laptopFour = new Laptop("Acer some model", 1567.43m, battery: nicd, processor: "3.2 GHz", ram: "16 GB");

            ////Laptop laptopOne = new Laptop("Lenovo Yoga 2 Pro", 869.88m, "Lenovo", "Intel Core i5-4210U (2-core, 1.70 - 2.70 GHz, 3MB cache)", "8 GB", "-128GB SSD", "Intel HD Graphics 4400", lion, "13.3\" (33.78 cm) – 3200 x 1800 (QHD+), IPS sensor display");
            //// This causes negative HDD size exception

            ////Laptop laptopThree = new Laptop("Acer some model", 1567.43m, battery: nicd, processor: "3.2 GHz", ram: "-1 GB");
            //// This causes negative ram exception

            Console.WriteLine(laptopOne);
            Console.WriteLine();
            Console.WriteLine(laptopTwo);
            Console.WriteLine();
            Console.WriteLine(laptopThree);
            Console.WriteLine();
            Console.WriteLine(laptopFour);
        }
    }
}
