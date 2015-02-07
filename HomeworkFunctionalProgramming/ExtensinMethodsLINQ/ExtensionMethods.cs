namespace ExtensinMethodsLINQ
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ExtensionMethods
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(i => !predicate(i));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            List<T> list = collection.ToList();

            for (int i = 0; i < count - 1; i++)
            {
                list.AddRange(collection);
            }

            return list;
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            var result = from s in collection
                         from suffix in suffixes
                         where s.EndsWith(suffix)
                         select s;
            return result.ToList();
        }
    }
}
