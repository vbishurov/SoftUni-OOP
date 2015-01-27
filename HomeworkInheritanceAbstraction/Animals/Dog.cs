namespace Animals
{
    using System;

    internal class Dog : Animal, ISound
    {
        public Dog(string name, string gender, byte age)
            : base(name, gender, age)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Bark Bark");
        }
    }
}
