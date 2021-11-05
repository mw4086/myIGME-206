using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE21
{
    class Program
    {
        static int[,] mGraph = new int[,]
        {
                   /*A*/ /*B*/ /*C*/ /*D*/ /*E*/ /*F*/ /*G*/ /*H*/
            /*A*/{ 0, 2, -1, -1, -1, -1, -1, -1},
            /*B*/{-1, -1, 2, 3, -1, -1, -1, -1 },
            /*C*/{-1, 2, -1, -1, -1, -1, -1, 20 },
            /*D*/{-1, 3, 5, -1, 2, 4, -1, -1 },
            /*E*/{-1, -1, -1, -1, -1, 3, -1, -1 },
            /*F*/{-1, -1, -1, -1, -1, -1, 1, -1 },
            /*G*/{-1, -1, -1, -1, 0, -1, -1, 2 },
            /*H*/{-1, -1, -1, -1, -1, -1, -1,-1 }
        };

        static char[,] dGraph = new char[,]
        {
                /*N*/ /*E*/ /*S*/ /*W*/
            /*A*/{'A','A',' ',' ' },
            /*B*/{' ','D','C',' ' },
            /*C*/{'B',' ','H',' ' },
            /*D*/{'E','F','C','B' },
            /*E*/{' ',' ','F',' ' },
            /*F*/{' ','G',' ',' ' },
            /*G*/{'E',' ','H',' ' },
            /*H*/{' ',' ',' ',' ' }
        };
    }
}
