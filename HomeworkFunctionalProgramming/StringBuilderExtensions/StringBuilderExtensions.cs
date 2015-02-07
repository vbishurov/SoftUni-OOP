namespace StringBuilderExtensions
{
    using System.Collections.Generic;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static string Substring(this StringBuilder b, int startIndex, int length)
        {
            return b.ToString().Substring(startIndex, length);
        }

        public static StringBuilder RemoveText(this StringBuilder b, string text)
        {
            return b.Replace(text.ToLower(), string.Empty);
        }

        public static StringBuilder AppendAll<T>(this StringBuilder b, IEnumerable<T> items)
        {
            return b.Append(string.Join(string.Empty, items));
        }
    }
}
