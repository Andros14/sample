using System.Linq;
using System.Collections.Generic;
using System;

namespace GeneralExtensions
{
    public static class CollectionExtensions
    {
        private static IEnumerable<IEnumerable<T>> SplitImplementation<T>(this IEnumerable<T> value, int partSize)
        {
            while (value.Count() > 0)
            {
                yield return value.Take(partSize);
                value = value.Skip(partSize);
            }
        }

        /// <summary>
        /// Indicates whether the specified object is null or empty.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="value">The sequence of elements to check.</param>
        /// <returns>true if the value parameter is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return value?.Any() != true;
        }

        /// <summary>
        /// Splits the sequence of elements into parts.
        /// </summary>
        /// <typeparam name="T">The type of the elements of source.</typeparam>
        /// <param name="value">The sequence of elements to split.</param>
        /// <param name="partSize">The size of the part.</param>
        /// <returns>Sequences of elements.</returns>
        /// <exception cref="ArgumentException">Length less than 1.</exception>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> value, int partSize)
        {
            if (partSize < 1)
                throw new ArgumentException();

            if (value.IsNullOrEmpty())
                return new List<IEnumerable<T>>() { value };

            return value.SplitImplementation(partSize);
        }
    }
}
