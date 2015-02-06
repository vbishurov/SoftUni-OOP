namespace AsynchronousTimer
{
    using System;
    using System.Threading;

    public static class AsynchronousTimerMain
    {
        public static void Main()
        {
            AsyncTimer one = new AsyncTimer(TestMethod1, 10, 800);
            AsyncTimer two = new AsyncTimer(TestMethod2, 40, 900);

            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("Main Method responds");
                Thread.Sleep(1000);
            }
        }

        public static void TestMethod1()
        {
            Console.WriteLine("Test Method 1 responds");
        }

        public static void TestMethod2()
        {
            Console.WriteLine("Test Method 2 responds");
        }
    }
}
