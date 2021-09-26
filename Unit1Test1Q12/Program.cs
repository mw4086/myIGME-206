using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Test1Q12
{
    class Program
    {
        static bool GiveRaise(string name, ref double salary)
        {
            if (name == "ming")
            {
                salary = Math.Round(salary + 19999.99, 2);
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;
            Console.Write("What's your name: ");
            sName = Console.ReadLine();
            if (GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congrats, you got a raise, your new salary is: {0}", dSalary);
            }
        }
    }
}