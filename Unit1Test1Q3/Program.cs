using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Test1Q3
{
    class Program
    {
        delegate string HomeMadeReadLine();
        public static String ReadFunction()
        {
            return Console.ReadLine();
        }
        static void Main(string[] args)
        {
            HomeMadeReadLine readline = ReadFunction;
            Console.WriteLine("Please Enter Something Here...");
            string read = readline();
            Console.WriteLine("You entered: {0}", read);
        }
    }
}