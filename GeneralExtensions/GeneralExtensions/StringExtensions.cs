using System;
using System.Linq;
using System.Collections.Generic;

namespace GeneralExtensions
{
    public static class StringExtensions
    {
        private static bool IsBothNull(string a, string b)
        {
            return a.IsNull() && b.IsNull();
        }

        private static bool IsEquals(string value, string comparable, StringComparison stringComparison)
        {
            if (IsBothNull(value, comparable))
                return true;

            return value != null && string.Equals(value, comparable, stringComparison);
        }

        private static bool IsContains(this string value, string comparable, StringComparison stringComparison)
        {
            if (IsBothNull(value, comparable))
                return true;

            return value.IsNotNull() && value.Contains(comparable, stringComparison);
        }

        /// <summary>
        /// Indicates whether the specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>true if the value parameter is null or System.String.Empty, or if value consists exclusively of white-space characters.</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Specifies whether the source string is equals to the specified string.
        /// </summary>
        /// <param name="value">The source string.</param>
        /// <param name="comparable">String for comparison.</param>
        /// <returns>true if the source string is equal to the specified string; otherwise, false.</returns>
        public static bool IsEquals(this string value, string comparable)
        {
            return IsEquals(value, comparable, StringComparison.Ordinal);
        }

        /// <summary>
        /// Specifies whether the source string is equals the specified string, ignoring case.
        /// </summary>
        /// <param name="value">The source string.</param>
        /// <param name="comparable">String for comparison.</param>
        /// <returns>true if the source string is equal to the specified string; otherwise, false.</returns>
        public static bool IsIgnoreCaseEquals(this string value, string comparable)
        {
            return IsEquals(value, comparable, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Specifies whether the source string is contains the specified string.
        /// </summary>
        /// <param name="value">The source string.</param>
        /// <param name="comparable">String for comparison.</param>
        /// <returns>true if the source string is contains to the specified string; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The comparable string is null.</exception>
        public static bool IsContains(this string value, string comparable)
        {
            return value.IsContains(comparable, StringComparison.Ordinal);
        }

        /// <summary>
        /// Specifies whether the source string is contains the specified string, ignoring case.
        /// </summary>
        /// <param name="value">The source string.</param>
        /// <param name="comparable">String for comparison.</param>
        /// <returns>true if the source string is contains to the specified string; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The comparable string is null.</exception>
        public static bool IsIgnoreCaseContains(this string value, string comparable)
        {
            return value.IsContains(comparable, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Splits the string into number of substrings.
        /// </summary>
        /// <param name="value">The string to split.</param>
        /// <param name="length">Length of substrings.</param>
        /// <returns>An collection whose elements contain the substrings in this string.</returns>
        /// <exception cref="ArgumentException">Length less than 1.</exception>
        public static List<string> Split(this string value, int length)
        {
            return value.AsEnumerable()
                .Split(length)
                .Select(part => new string(part?.ToArray()))
                .ToList();
        }
    }
}
