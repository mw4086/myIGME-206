using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //missing ;
            int nY;
            int nAnswer;

            //missing ""
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //missing storge val for ReadLine
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nY));//missing "!" as logical error and assigned to the wrong val, the correct onw shold be nY

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            //wrong format
            Console.WriteLine("{0}^{1} = {2}", nX, nY, nAnswer);
        }


        //missing static
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                returnVal = 1;//base case return val sholud be 1
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                nextVal = Power(nBase, nExponent - 1);//wrong operator, changed "+" to "-"

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }
            //missing return
            return returnVal;
        }
    }
}