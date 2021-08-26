using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteColorAndNumber
{
    // Class: Program
    // Author: Mingshen Wu
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: None
    static class Program
    {
        static void PrintMyColor(ref string sColorString)
        {
            sColorString += " is your favorite color";
            Console.WriteLine(sColorString);
        }

        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        // Output hteir favorite color (in limited text colors) their favorite number of times
        // Restrictions: None
        static void Main(string[] args)
        {
            // strings to hold their favorite color
            // compile-time error: missing semi-colon
            //string color = null
            string sColor = null;
            string sNumber = null;

            string sDavesColor = null;
            string sTomsColor = null;

            sDavesColor = "red";
            sTomsColor = "Blue";
            sDavesColor = sTomsColor;
            sTomsColor = "purple";

            {
                int localInt = 0;

            }

            // int to hold their favorite number
            int favNum = 0;

            // flag to indicate if they entered a valid number string
            bool bValid = false;

            // loop counter
            int i = 0;

            // prompt for favorite color
            // demonstrate including the tab special character.
            // "\n" is the newline character, which is added to the end of the string for the 
            Console.Write("Enter your favorite color: \t");

            // read their favorite color from the keyboard
            // and store it in color
            // logic error
            //sNumber = Console.ReadLine();
            sColor = Console.ReadLine();

            PrintMyColor(ref sColor);

            // prompt for favorite number
            Console.Write("Enter your favorite number: \t");
            sNumber = Console.ReadLine();

            // this causes a run-time error with non-numeric string
            // favNum = Convert.ToInt32(sNumber);

            while (!bValid)
            {
                try
                {
                    favNum = Convert.ToInt32(sNumber);
                    bValid = true;
                }
                catch
                {
                    // and "catch" any run-time exception that might occur from the "try" code block
                    // guide the user what kind of data we are expecting
                    Console.WriteLine("Please enter an integer.");


                    // flage that they have not entered valid data yet, so that we stay in the loop
                    bValid = false;
                }
            }
            

            switch (sColor.ToLower())
            {
                //set the text color to red
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                //set the text color to blue
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                //set the text color to green
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                // if none of the above cases are met, then invert the text color (black on white)
                default:
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
            }

            for (i = 0; i<favNum; ++i)
            {
                // using $"" causes string interpolation such that the {} within the string are compile
                // in this case we add "!" to the color
                Console.WriteLine($"Yourfavorite color is {sColor + "!"}");

                //Two other ways to generate the same output:

                //1. simple string concatenation (note that you do not use $ or {});
                // console. writeline("your favorite color is " + color + "!");

                // 2. string replacement using {} (but not $);
                // console. writeline("your favorite color is {0}{1}", color, "!");
            }

            /* the above for () loop can be rewritten as a while() loop as follows:
            // initialize the counter outside of the loop
            i = 0;
            // while i< the number of times to write the output
            while (i<favNum)
            {
            //write the output
            console. writeline($"Your favorite color is {color + "!"}");

            //increment the counter
            ++i;
            */
        }
    }
}
