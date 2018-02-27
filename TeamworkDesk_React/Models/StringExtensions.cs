using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TeamworkDesk_React.Models
{
    public static class StringExtensions
    {
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static string Shorten(this string str, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords needs to be greater than 0");
            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ', '\n');
            // words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            if (words.Length <= numberOfWords)
                return str;

            // Take the numberOfWords from the string array and join them in a new string.

            var parsedWords = string.Join(" ", words.Take(numberOfWords));
            var finalResult = parsedWords + "...";
            return finalResult;

        }
    }
}