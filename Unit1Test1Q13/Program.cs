using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Test1Q13
{
    struct employee
    {
        public string sName;
        public double dSalary;
    }
    class Program
    {
        static bool GiveRaise(ref employee e)
        {
            if (e.sName == "ming")
            {
                e.dSalary = Math.Round(e.dSalary + 19999.99, 2);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            employee e = new employee();
            Console.Write("What's your name: ");
            e.sName = Console.ReadLine();
            e.dSalary = 30000;
            if (GiveRaise(ref e))
            {
                Console.WriteLine("Congrats, you got a raise, your new salary is: {0}", e.dSalary);
            }
        }
    }
}