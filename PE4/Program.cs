using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4
{
    class Program
    {
        static void Main(string[] args)
        {
            method();
        }
        static void method()
        {
            int var1;
            int var2;
            bool result;

            Console.WriteLine("Please enter first number");
            var1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter second number");
            var2 = Convert.ToInt32(Console.ReadLine());

            result = (var1 < 10 && var2 < 10);
            if (result == true)
            {
                Console.WriteLine("You have entered " + var1 + " and " + var2);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please re-enter the correct number");
                method();
            }
        }
    }
}
