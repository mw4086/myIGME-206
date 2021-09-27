using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace Traffic
{
    class Program
    {
        public static void AddPassenger(IPassengerCarrier obj)
        {
                obj.LoadPassenger();
                Console.WriteLine(obj.ToString());
        }
    }
}
