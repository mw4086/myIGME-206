using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Program
    {
        static void Main(string[] args)
        {
            string readInput = null;
            int firstNumber = 0;
            int secondNumber = 0;
            int thirdNumber = 0;
            int fourthNumber = 0;
            Console.WriteLine("Please enter four Number");
            Console.WriteLine("First Number:");
            readInput = Console.ReadLine();
            firstNumber = Convert.ToInt32(readInput);

            Console.WriteLine("Second Number");
            readInput = Console.ReadLine();
            secondNumber = Convert.ToInt32(readInput);

            Console.WriteLine("Third Number");
            readInput = Console.ReadLine();
            thirdNumber = Convert.ToInt32(readInput);

            Console.WriteLine("Fourth Number");
            readInput = Console.ReadLine();
            fourthNumber = Convert.ToInt32(readInput);

            Console.WriteLine("What you have entered are: " + firstNumber + ", " + secondNumber + ", " + thirdNumber + ", " + fourthNumber);
            Console.ReadLine();
        }
    }
}
