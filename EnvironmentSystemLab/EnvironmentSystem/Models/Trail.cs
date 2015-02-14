namespace EnvironmentSystem.Models
{
    using System.Collections.Generic;
    using Objects;

    public class Trail : EnvironmentObject
    {
        private readonly int maxLife;
        private int life;

        public Trail(int x, int y, int width, int height, int maxLife)
            : base(x, y, width, height)
        {
            this.ImageProfile = new[,] { { '*' } };
            this.maxLife = maxLife;
        }

        public override void Update()
        {
            this.life++;
            if (this.life >= this.maxLife)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
