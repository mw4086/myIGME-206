using System;

namespace Mandelbrot
{
   /// <summary>
   /// This class generates Mandelbrot sets in the console window!
   /// </summary>


	class Class1
	{
      /// <summary>
      /// This is the Main() method for Class1 -
      /// this is where we call the Mandelbrot generator!
      /// </summary>
      /// <param name="args">
      /// The args parameter is used to read in
      /// arguments passed from the console window
      /// </param>

		[STAThread]
		static void Main(string[] args)
		{
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            double minRealCoord, maxRealCoord;
            double minImagCoord, maxImagCoord;

            Console.WriteLine("Please enter the min value of realCoord default is -0.6 ");
            minRealCoord = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the max value of realCoord default is 1.77 ");
            maxRealCoord = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the min value of imagCoord default is -1.2 ");
            minImagCoord = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the max value of imagCoord default is 1.2 ");
            maxImagCoord = Convert.ToDouble(Console.ReadLine());

            for (imagCoord = maxImagCoord; imagCoord >= minImagCoord; imagCoord -= (maxImagCoord - (minImagCoord)) / 48) 
             {
                for (realCoord = minRealCoord; realCoord <= maxRealCoord; realCoord += (maxRealCoord-(minRealCoord))/48)
                {
                   iterations = 0;
                   realTemp = realCoord;
                   imagTemp = imagCoord; 
                   arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                   while ((arg < 4) && (iterations < 40))
                   {
                      realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                         - realCoord;
                      imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                      realTemp = realTemp2;
                      arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                      iterations += 1;
                   }
                   switch (iterations % 4)
                   {
                      case 0:
                         Console.Write(".");
                         break;
                      case 1:
                         Console.Write("o");
                         break;
                      case 2:
                         Console.Write("O");
                         break;
                      case 3:
                         Console.Write("@");
                         break;
                   }
                }
            Console.Write("\n");
         }
            Console.ReadLine();
		}
	}
}
