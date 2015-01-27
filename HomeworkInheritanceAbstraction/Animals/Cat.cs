namespace Animals
{
    using System;

    internal abstract class Cat : Animal, ISound
    {
        protected Cat(string name, string gender, byte age)
            : base(name, gender, age)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Meow Meow");
        }
    }
}
