namespace EnvironmentSystem.Models
{
    using System.Collections.Generic;
    using Core;
    using Objects;

    public abstract class Star : EnvironmentObject
    {
        private readonly char[] images = { '@', '0', 'o', 'a', 'b', 'c', 'd', 'e', 'f', '/', '6', '4', 'h' };
        private int countUpdates;

        protected Star(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void Update()
        {
            if (this.countUpdates >= 10)
            {
                this.ImageProfile = this.GenerateImageProfile();
                this.countUpdates = 0;
            }

            this.countUpdates++;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Trail)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }

        private char[,] GenerateImageProfile()
        {
            return new[,] { { this.images[Engine.Rnd.Next(0, this.images.Length)] } };
        }
    }
}
