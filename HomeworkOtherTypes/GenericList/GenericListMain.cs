namespace GenericList
{
    using System;

    public static class GenericListMain
    {
        public static void Main()
        {
            GenericList<int> test = new GenericList<int>(1, 1);
            test.Add(2);
            test.Add(4);
            test.Add(5);
            test.Add(6);
            test.Insert(2, 3);
            Console.WriteLine(test.Find(4));
        }
    }
}
