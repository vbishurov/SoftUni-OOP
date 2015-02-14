namespace EnvironmentSystem.Models
{
    using System.Collections.Generic;
    using Core;
    using Objects;

    public class FallingStar : MovingObject
    {
        private readonly int fallDirection = Engine.Rnd.Next(0, 3) - 1;

        public FallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = new[,] { { '0' } };
        }

        public int FallDirection
        {
            get { return this.fallDirection; }
        }

        public int CollideTrailNormalize { get; protected set; }

        public bool IsFalling { get; protected set; }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Trail || collisionInfo.HitObject is Ground)
            {
                this.Exists = false;
            }
        }

        public override void Update()
        {
            int chance = Engine.Rnd.Next(0, 1000);
            if (chance < 10)
            {
                this.IsFalling = true;
            }

            if (this.IsFalling)
            {
                this.Bounds.TopLeft.Y++;
                this.Bounds.TopLeft.X += this.FallDirection;
                if (this.Bounds.TopLeft.X < 0)
                {
                    this.Bounds.TopLeft.X = 0;
                    this.CollideTrailNormalize = -1;
                }
                else if (this.Bounds.TopLeft.X > Engine.WorldWidth - 1)
                {
                    this.Bounds.TopLeft.X = Engine.WorldWidth - 1;
                    this.CollideTrailNormalize = 1;
                }
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.IsFalling)
            {
                var trail = new Trail(
                                this.Bounds.TopLeft.X - (this.FallDirection - this.CollideTrailNormalize),
                                this.Bounds.TopLeft.Y - 1,
                                this.Bounds.Width,
                                this.Bounds.Width,
                                3);
                return new List<EnvironmentObject> { trail };
            }

            return new List<EnvironmentObject>();
        }
    }
}
