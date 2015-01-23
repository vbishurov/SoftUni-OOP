using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Space3D;

namespace Paths
{
    class Paths3D : IEnumerable<Point3D> //Implementing interface
    {
        private List<Point3D> points;

        public Paths3D(params Point3D[] points)
        {
            this.Points = points.ToList();
        }

        public Paths3D(List<Point3D> points)
        {
            this.Points = points;
        }

        public List<Point3D> Points { get; set; }

        public int Count
        {
            get { return this.Points.Count; }
        }

        public void Add(Point3D point)
        {
            if (point == null)
            {
                throw new ArgumentNullException("Point cannot be empty.");
            }
            this.Points.Add(point);
        }

        //Operator overloading
        public Point3D this[int index]
        {
            get { return this.Points[index]; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Point cannot be empty.");
                }
                this.Points[index] = value;
            }
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            foreach (Point3D point3D in this.Points)
            {
                b.AppendLine(point3D.ToString());
            }
            return b.ToString();
        }

        //Foreach implementation
        public IEnumerator<Point3D> GetEnumerator()
        {
            for (int i = 0; i < this.Points.Count; i++)
            {
                yield return this.Points[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
