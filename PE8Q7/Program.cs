using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q7
{
    class Program
    {
        static void Main(string[] args)
        {
            string rev;
            Console.WriteLine("Please enter a word");
            string userInput = Console.ReadLine();
            rev = "";
            Console.WriteLine("Value of given String is: {0}", userInput);
            int i;
            i = userInput.Length - 1;
            while (i >= 0)
            {
                rev = rev + userInput[i];
                i--;
            }
            Console.WriteLine("Reversed string is: {0}", rev);
            Console.ReadLine();
        }
    }
}
