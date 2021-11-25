using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;

namespace PE21
{
    class Program
    {
        static void Main()
        {
            string input;
            Console.Write("a string: ");
            input = Console.ReadLine();
            var freqs = input.Where(c => Char.IsLetter(c)).GroupBy(c => Char.ToUpper(c)).ToDictionary(g => g.Key, g => g.Count());
            foreach (var item in freqs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Reverse(input));
            Console.Write("Palindrome => ");
            Console.Write(checkPalindrome(input));
        }
        static string Reverse(string s)
        {
            char[] c = s.ToCharArray();
            Array.Reverse(c);
            return new string(c);
        }
        static string checkPalindrome(string s)
        {
            s = Regex.Replace(s, @"[^A-Za-z0-9]+", "").ToLower();
            string s1 = s.Substring(0, s.Length / 2);
            string s2 = Reverse(s).Substring(0, s.Length / 2);
            return s1.Equals(s2) ? "True" : "False";
        }
    }
}