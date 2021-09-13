using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a sentance then I will put double quotes around it!");
            string playerInput = Console.ReadLine();

            string[] words = playerInput.Split(' ');
            string finalResult = string.Join(" ", words).Replace(" ", "\"");
            Console.WriteLine(finalResult);
            Console.ReadLine();
        }
    }
}
