namespace EnvironmentSystem.Models.Data.Structures
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class QuadTree<T>
        where T : ICollidable
    {
        private const int MaxObjectsPerNode = 10;
        private const int MaxLevels = 5;

        private int level;
        private List<T> objects;
        private Rectangle bounds;
        private QuadTree<T>[] nodes;

        public QuadTree(int level, Rectangle bounds)
        {
            this.level = level;
            this.bounds = bounds;
            this.objects = new List<T>();
            this.nodes = new QuadTree<T>[4];
        }

        /*
         * Insert the object into the quadtree. If the node
         * exceeds the capacity, it will split and add all
         * objects to their corresponding nodes.
         */
        public void Insert(T obj)
        {
            if (this.nodes[0] != null)
            {
                int index = this.GetIndex(obj.Bounds);

                if (index != -1)
                {
                    this.nodes[index].Insert(obj);
                    return;
                }
            }

            this.objects.Add(obj);

            if (this.objects.Count > QuadTree<T>.MaxObjectsPerNode && this.level < QuadTree<T>.MaxLevels)
            {
                if (this.nodes[0] == null)
                {
                    this.Split();
                }

                int i = 0;
                while (i < this.objects.Count)
                {
                    int index = this.GetIndex(this.objects[i].Bounds);
                    if (index != -1)
                    {
                        this.nodes[index].Insert(this.objects[i]);
                        this.objects.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        /*
         * Return all objects that could collide with the given object
         */
        public List<T> GetItems(List<T> returnObjects, Rectangle bounds)
        {
            int index = this.GetIndex(bounds);
            if (index != -1 && this.nodes[0] != null)
            {
                this.nodes[index].GetItems(returnObjects, bounds);
            }

            returnObjects.AddRange(this.objects);

            return returnObjects;
        }

        public void Remove(T item)
        {
            int index = this.GetIndex(item.Bounds);
            if (index != -1)
            {
                this.nodes[index].Remove(item);
            }
            else if (this.objects.Contains(item))
            {
                this.objects.Remove(item);
            }
            else
            {
                throw new ArgumentException("Quadtree does not contain such item.");
            }
        }

        public void Clear()
        {
            this.objects.Clear();

            for (int i = 0; i < this.nodes.Length; i++)
            {
                if (this.nodes[i] != null)
                {
                    this.nodes[i].Clear();
                    this.nodes[i] = null;
                }
            }
        }

        private void Split()
        {
            int subWidth = this.bounds.Width / 2;
            int subHeight = this.bounds.Height / 2;
            int x = this.bounds.TopLeft.X;
            int y = this.bounds.TopLeft.Y;

            this.nodes[0] = new QuadTree<T>(this.level + 1, new Rectangle(x + subWidth, y, subWidth, subHeight));
            this.nodes[1] = new QuadTree<T>(this.level + 1, new Rectangle(x, y, subWidth, subHeight));
            this.nodes[2] = new QuadTree<T>(this.level + 1, new Rectangle(x, y + subHeight, subWidth, subHeight));
            this.nodes[3] = new QuadTree<T>(this.level + 1, new Rectangle(x + subWidth, y + subHeight, subWidth, subHeight));
        }

        /*
         * Determine which node the object belongs to. -1 means
         * object cannot completely fit within a child node and is part
         * of the parent node
         */
        private int GetIndex(Rectangle pRect)
        {
            int index = -1;
            double verticalMidpoint = this.bounds.TopLeft.X + (this.bounds.Width / 2);
            double horizontalMidpoint = this.bounds.TopLeft.Y + (this.bounds.Height / 2);

            // Object can completely fit within the top quadrants
            bool withinTopQuadrant = pRect.TopLeft.Y < horizontalMidpoint && pRect.TopLeft.Y + pRect.Height < horizontalMidpoint;

            // Object can completely fit within the bottom quadrants
            bool withinBottomQuadrant = pRect.TopLeft.Y > horizontalMidpoint;

            // Object can completely fit within the left quadrants
            if (pRect.TopLeft.X < verticalMidpoint && pRect.TopLeft.X + pRect.Width < verticalMidpoint)
            {
                if (withinTopQuadrant)
                {
                    index = 1;
                }
                else if (withinBottomQuadrant)
                {
                    index = 2;
                }
            }

            // Object can completely fit within the right quadrants
            else if (pRect.TopLeft.X > verticalMidpoint)
            {
                if (withinTopQuadrant)
                {
                    index = 0;
                }
                else if (withinBottomQuadrant)
                {
                    index = 3;
                }
            }

            return index;
        }
    }
}