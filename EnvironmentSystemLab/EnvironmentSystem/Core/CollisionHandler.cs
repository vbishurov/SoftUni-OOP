namespace EnvironmentSystem.Core
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;
    using Models.Data.Structures;
    using Models.Objects;

    public static class CollisionHandler
    {
        private static QuadTree<ICollidable> collidingObjects;

        public static void Initlialize(int worldWidth, int worldHeight)
        {
            CollisionHandler.collidingObjects = new QuadTree<ICollidable>(0, new Rectangle(0, 0, worldWidth, worldHeight));
        }

        public static void HandleCollisions(IList<EnvironmentObject> objects)
        {
            foreach (var obj in objects)
            {
                CollisionHandler.collidingObjects.Insert(obj);
            }

            foreach (var obj in objects)
            {
                var candidateCollisionItems = CollisionHandler.collidingObjects.GetItems(new List<ICollidable>(), obj.Bounds);

                foreach (var item in candidateCollisionItems)
                {
                    if (Rectangle.Intersects(obj.Bounds, item.Bounds) && item != obj)
                    {
                        var collisionInfo = new CollisionInfo(item);
                        obj.RespondToCollision(collisionInfo);
                    }
                }
            }

            CollisionHandler.collidingObjects.Clear();
        }
    }
}
