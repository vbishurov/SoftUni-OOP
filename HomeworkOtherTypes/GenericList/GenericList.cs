namespace GenericList
{
    using System;
    using System.Linq;
    using System.Text;

    [Version(1, 22)]
    public class GenericList<T> where T : IComparable<T>
    {
        private const byte DefaultCapacity = 16;

        private T[] arr;
        private byte capacity;

        public GenericList(byte capacity = DefaultCapacity, params T[] contents)
        {
            this.arr = new T[capacity];
            this.Arr = contents;
            this.Capacity = capacity;
            this.Count = contents.Length;
        }

        public int Count { get; private set; }

        private byte Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Cannot have les than 1 element.");
                }

                this.capacity = value;
            }
        }

        private T[] Arr
        {
            get
            {
                return this.arr;
            }

            set
            {
                this.arr = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Enter index in range [0...{0}]", this.Count - 1));
                }

                return this.Arr[index];
            }

            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Enter index in range [0...{0}]", this.Count - 1));
                }

                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.Arr[index] = value;
            }
        }

        public void Add(T element)
        {
            if (this.Count + 1 > this.Arr.Length)
            {
                T[] newArr = new T[this.Arr.Length * 2];
                for (int i = 0; i < this.Arr.Length; i++)
                {
                    newArr[i] = this.Arr[i];
                }

                this.Arr = newArr;
            }

            this.Arr[this.Count] = element;
            this.Count++;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                b.AppendLine(this.Arr[i].ToString());
            }

            return b.ToString().Trim();
        }

        public void Remove(int index)
        {
            T[] newArr = new T[this.Count - 1 < this.Arr.Length / 2 ? this.Arr.Length / 2 : this.Arr.Length];
            for (int i = 0; i < this.Arr.Length; i++)
            {
                if (i == index)
                {
                    continue;
                }
                else if (i > index)
                {
                    newArr[i - 1] = this.Arr[i];
                }
                else
                {
                    newArr[i] = this.Arr[i];
                }
            }

            this.Arr = newArr;
            this.Count--;
        }

        public void Insert(int index, T element)
        {
            T[] newArr = new T[this.Count + 1 > this.Arr.Length ? this.Arr.Length * 2 : this.Arr.Length];
            for (int i = 0; i < this.Arr.Length; i++)
            {
                if (i == index)
                {
                    newArr[i] = element;
                }
                else if (i > index)
                {
                    newArr[i] = this.Arr[i - 1];
                }
                else
                {
                    newArr[i] = this.Arr[i];
                }
            }

            this.Arr = newArr;
            this.Count++;
        }

        public void Clear()
        {
            this.Arr = new T[1];
            this.Count = 0;
        }

        public int Find(T value)
        {
            for (int i = 0; i < this.Arr.Length; i++)
            {
                if (this.Arr[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public T Min<U>()
        {
            return this.Arr.Min();
        }

        public T Max<U>()
        {
            return this.Arr.Max();
        }

        public bool Contains(T value)
        {
            return this.Arr.Contains(value);
        }
    }
}
