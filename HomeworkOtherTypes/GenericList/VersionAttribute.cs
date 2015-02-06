namespace GenericList
{
    using System;

    public class VersionAttribute : Attribute
    {
        private readonly int minor;
        private readonly int major;

        public VersionAttribute(int major, int minor)
        {
            this.minor = minor;
            this.major = major;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.major, this.minor);
        }
    }
}
