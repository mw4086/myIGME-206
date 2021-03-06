using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q5
{
    public struct ZFunction
    {

        class Program
        {
            static void Main(string[] args)
            {
                double x = 0;
                double y = 0;
                double z = 0;

                int nX = 0;
                int nY = 0;

                double[,,] zFunc = new double[21, 31, 3];

                for (x = -1; x <= 1; x += 0.1, ++nX)
                {
                    x = Math.Round(x, 1);
                    nY = 0;
                    for (y = 1; y <= 4; y += 0.1, ++nY)
                    {
                        y = Math.Round(y, 1);
                        z = 3 * Math.Pow(y, 2) + 3 * x - 1;
                        z = Math.Round(z, 3);

                        zFunc[nX, nY, 0] = x;
                        zFunc[nX, nY, 1] = y;
                        zFunc[nX, nY, 2] = z;
                    }
                }
                for (int a=0; a < zFunc.GetLength(0); a++)
                {
                    for(int b = 0; b < zFunc.GetLength(1); b++)
                    {
                        Console.WriteLine("x={0} y{1} z{2}", zFunc[a, b, 0], zFunc[a, b, 1], zFunc[a, b, 2]);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
