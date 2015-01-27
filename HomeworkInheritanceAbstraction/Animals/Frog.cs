namespace Animals
{
    using System;

    internal class Frog : Animal, ISound
    {
        public Frog(string name, string gender, byte age)
            : base(name, gender, age)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Quak Quak");
        }
    }
}
