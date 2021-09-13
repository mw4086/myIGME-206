using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q5
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,,] data = new double[630,630,630];
            int i = 0;
            for(double x = -1; x < 1; x += 0.1)
            {
                for(double y = 1; y < 4; y += 0.1)
                {
                    data[i, i, i] = (3 * y * y) + (2 * x) - 1;
                    i++;
                }
            }
            foreach(var item in data)
            {
                Array.ForEach(data, Console.WriteLine);
            }
            Console.ReadLine();
        }
    }
}
