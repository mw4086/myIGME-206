using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        struct order
        {
            public string itemName;
            public int unitCount;
            public double unitCost;
            public double totalPrice()
            {
                return this.unitCost * this.unitCount;
            }
            public string another()
            {
                double t = totalPrice();
                return "Order Information: " + this.unitCount.ToString() + " " + this.itemName.ToString() + " itmes at $" + this.unitCost + " each, total cost $" + t.ToString();
            }
        }
        static void Main(string[] args)
        {
            order order1 = new order();
            order1.itemName = "PH";
            order1.unitCost = 10;
            order1.unitCount = 11;
            Console.WriteLine(order1.another());
            Console.ReadLine();
        }
    }
}
