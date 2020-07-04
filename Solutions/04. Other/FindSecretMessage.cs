using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class FindSecretMessage
    {
        public string GetMessage(string text)
        {
            var charFrequency = new Dictionary<char, int>();
            foreach(char c in text)
            {
                if (!charFrequency.ContainsKey(c))
                {
                    charFrequency.Add(c, 0);
                }
                charFrequency[c]++;
            }
            foreach(var kvp in charFrequency.OrderBy(kvp => kvp.Value))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
            char[] leastFrequestChars = charFrequency.Where(kvp => kvp.Value < 10).Select(kvp => kvp.Key).ToArray();

            return ConstructMessage(text, leastFrequestChars);
        }

        private string ConstructMessage(string text, char[] leastFrequestChars)
        {
            HashSet<char> validChars = new HashSet<char>(leastFrequestChars);
            StringBuilder sb = new StringBuilder();
            foreach(char c in text)
            {
                if (validChars.Contains(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}