using System.Linq;
using System.Text;

namespace RyanKenward.Strings.Business
{
    public class Zipper
    {
        /// <summary>
        /// Interweaves the characters of two strings together.
        /// </summary>
        /// <param name="str1">The first string to interweave.</param>
        /// <param name="str2">The second string to interweave.</param>
        /// <returns>The interweaved string.</returns>
        public string zip(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1))
                return str2;
            if (string.IsNullOrEmpty(str2))
                return str1;

            var chars1 = str1.ToArray();
            var chars2 = str2.ToArray();

            // create interweaved pairs of chars. note: cuts off excess chars if one string is longer than the other.
            var chars = chars1.Zip(chars2, (a, b) => new char[] { a, b });

            // combine char pairs into single string.
            var sb = new StringBuilder();
            foreach (var pair in chars)
                sb.Append(new string(pair));

            // append remaining chars of string to interweaved string if one string is longer.
            sb.Append(AppendSuffix(str1, chars.Count()));
            sb.Append(AppendSuffix(str2, chars.Count()));

            return sb.ToString();
        }

        /// <summary>
        /// Calculates the suffix of the given string after the specified number of characters.
        /// </summary>
        /// <param name="str">A string.</param>
        /// <param name="count">Number of characters.</param>
        /// <returns>The suffix.</returns>
        private string AppendSuffix(string str, int count)
        {
            if (count < str.Length)
                return str.Substring(count, (str.Length - count));

            return string.Empty;
        }
    }
}
