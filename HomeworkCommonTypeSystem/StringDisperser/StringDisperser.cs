namespace StringDisperser
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;

    public class StringDisperser : IEnumerable, ICloneable, IComparable<StringDisperser>
    {
        public StringDisperser(string[] args)
        {
            this.Arguments = args;
        }

        public string[] Arguments { get; private set; }

        public static bool operator ==(StringDisperser sd1, StringDisperser sd2)
        {
            return sd1.Equals(sd2);
        }

        public static bool operator !=(StringDisperser sd1, StringDisperser sd2)
        {
            return !(sd1 == sd2);
        }

        public IEnumerator GetEnumerator()
        {
            return this.Arguments.SelectMany(argument => argument).GetEnumerator();
        }

        public object Clone()
        {
            return new StringDisperser(this.Arguments);
        }

        public int CompareTo(StringDisperser other)
        {
            return this.GetTotalStringsValue().CompareTo(other.GetTotalStringsValue());
        }

        public override bool Equals(object obj)
        {
            return this.Arguments.Equals((obj as StringDisperser).Arguments);
        }

        public override int GetHashCode()
        {
            var hash = this.Arguments[0].GetHashCode();
            for (int i = 1; i < this.Arguments.Length; i++)
            {
                hash += this.Arguments[i].GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append(string.Join(", ", this.Arguments));
            return b.ToString();
        }

        private string GetTotalStringsValue()
        {
            StringBuilder b = new StringBuilder();
            foreach (string argument in this.Arguments)
            {
                b.Append(argument);
            }

            return b.ToString();
        }
    }
}
