using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentance with No, I will change it to yes!");
            string userInput = Console.ReadLine();

            Console.WriteLine(userInput.Replace("no", "yes"));
            Console.ReadLine();
        }
    }
}
