namespace EnvironmentSystem.Core.Generator
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Objects;

    public class ObjectGenerator
    {
        private readonly int worldWidth;
        private readonly int worldHeight;

        public ObjectGenerator(int worldWidth, int worldHeight)
        {
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
        }

        /// <summary>
        /// Adds objects only once to the passed collection.
        /// </summary>
        /// <param name="objects"></param>
        public void Initiliaze(List<EnvironmentObject> objects)
        {
            objects.Add(new Ground(0, 25, 50, 2));
        }

        /// <summary>
        /// Dynamically adds objects to the passed collection.
        /// </summary>
        /// <param name="objects"></param>
        public void DynamicAllyAdd(List<EnvironmentObject> objects)
        {
            const int StarsCount = 10;
            if (objects.Count(o => o is FallingStar) <= StarsCount)
            {
                int chance = Engine.Rnd.Next(0, 100);
                int x = Engine.Rnd.Next(0, this.worldWidth - 1);
                int y = Engine.Rnd.Next(0, this.worldHeight / 2);
                var envObject = 
                    chance < 80 ? 
                    new UnstableFallingStar(x, y, 1, 1, new Point(0, 0)) : 
                    new FallingStar(x, y, 1, 1, new Point(0, 0));

                if (objects.Any(o => o is Star && ((Star)o).Bounds == envObject.Bounds))
                {
                    x = Engine.Rnd.Next(0, this.worldWidth);
                    y = Engine.Rnd.Next(0, this.worldHeight / 2);
                    envObject =
                    chance < 80 ?
                    new UnstableFallingStar(x, y, 1, 1, new Point(0, 0)) :
                    new FallingStar(x, y, 1, 1, new Point(0, 0));
                }

                objects.Add(envObject);
            }
        }
    }
}
