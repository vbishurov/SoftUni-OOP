namespace EnvironmentSystem.Models
{
    using System.Collections.Generic;
    using Core;
    using Objects;

    public class UnstableFallingStar : FallingStar
    {
        private int ticks;
        private bool isBanged;

        public UnstableFallingStar(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = new[,] { { '@' } };
        }

        public override void Update()
        {
            int chance = Engine.Rnd.Next(0, 1000);
            if (chance < 10)
            {
                this.IsFalling = true;
            }

            if (this.IsFalling && !this.isBanged)
            {
                this.ticks++;

                this.Bounds.TopLeft.Y++;
                this.Bounds.TopLeft.X += this.FallDirection;
                if (this.Bounds.TopLeft.X < 0 && this.ticks < 8)
                {
                    this.Bounds.TopLeft.X = 0;
                    this.CollideTrailNormalize = -1;
                }
                else if (this.Bounds.TopLeft.X > Engine.WorldWidth - 1 && this.ticks < 8)
                {
                    this.Bounds.TopLeft.X = Engine.WorldWidth - 1;
                    this.CollideTrailNormalize = 1;
                }
            }

            if (this.ticks >= 8)
            {
                this.ticks++;
                this.isBanged = true;
                this.ImageProfile = new[,] { { ' ' } };
            }

            if (this.ticks >= 10)
            {
                this.Exists = false;
                this.isBanged = false;
                this.ticks = 0;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (this.IsFalling && !this.isBanged && this.ticks < 6)
            {
                var trail = new Trail(
                                this.Bounds.TopLeft.X - (this.FallDirection - this.CollideTrailNormalize),
                                this.Bounds.TopLeft.Y - 1,
                                this.Bounds.Width,
                                this.Bounds.Width,
                                3);
                return new List<EnvironmentObject> { trail };
            }

            if (this.isBanged)
            {
                var bang = new List<EnvironmentObject>();
                for (int row = -2; row <= 2; row++)
                {
                    for (int column = -2; column <= 2; column++)
                    {
                        if (row == 0 && column == 0)
                        {
                            continue;
                        }

                        bang.Add(new Trail(
                                this.Bounds.TopLeft.X + column,
                                this.Bounds.TopLeft.Y + row,
                                this.Bounds.Width,
                                this.Bounds.Width,
                                2));
                    }
                }

                return bang;
            }

            return new List<EnvironmentObject>();
        }
    }
}
