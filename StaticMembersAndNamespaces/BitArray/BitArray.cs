using System;
using System.Numerics;
using System.Text;

namespace BitArray
{
    class BitArray
    {
        private int length;
        private BigInteger bitValues;

        public BitArray(int size)
        {
            this.Length = size;
        }

        public int Length
        {
            get { return this.length; }
            private set
            {
                if (value < 1 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("Bir array length must be in range [1...100 000]");
                }
                this.length = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index > this.Length)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid. Enter index in range[0...{1}].", index, this.Length));
                }
                return (bitValues & (1 << index)) == 0 ? 0 : 1;
            }
            set
            {
                if (index < 0 || index > this.Length)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid. Enter index in range[0...{1}].", index, this.Length));
                }
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException(String.Format("Value {0} is invalid. Valid values are 0 and 1."));
                }

                bitValues &= ~((BigInteger)1 << index);

                bitValues |= ((BigInteger)value << index);
            }
        }

        public string DisplayBits()
        {
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < this.Length; i++)
            {
                b.Append(this[i]);
            }
            return b.ToString();
        }

        public override string ToString()
        {
            return this.bitValues.ToString();
        }
    }
}
