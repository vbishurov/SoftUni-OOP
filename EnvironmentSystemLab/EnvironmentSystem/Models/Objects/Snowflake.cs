namespace EnvironmentSystem.Models.Objects
{
    using System.Collections.Generic;

    public class Snowflake : MovingObject
    {
        private const char SnowflakeCharImage = '*';

        public Snowflake(int x, int y, int width, int height, Point direction)
            : base(x, y, width, height, direction)
        {
            this.ImageProfile = this.GenerateImageProfile();
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            if (collisionInfo.HitObject is Ground)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            if (!this.Exists)
            {
                Ground snow = new Ground(this.Bounds.TopLeft.X, this.Bounds.TopLeft.Y - 1, this.Bounds.Width, this.Bounds.Height);
                snow.ImageProfile[0, 0] = '.';
                return new List<EnvironmentObject>() { snow };
            }

            return new List<EnvironmentObject>();
        }

        protected virtual char[,] GenerateImageProfile()
        {
            return new char[,] { { Snowflake.SnowflakeCharImage } };
        }
    }
}
