using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wu_HelloWorld
{
    // Class: Program
    // Author: Ming Wu
    // Purpose: Console Read/Write and Exception-handling exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Prompt the user for their favorite color and number
        //          Output their favorite color (in limited text colors) their favorite number of times
        // Restrictions: None
        static void Main(string[] args)
        {
            // int to hold their favorite number
            int favNumber = 0; 

            // Show text of Hello Mingshen Wu
            Console.WriteLine("Hello Mingshen Wu!");

            //Ask player the favorite number
            Console.WriteLine("What is your favorite number?");

            //Read the input from the player keyboard and convert to int, then save in favNumber.
            favNumber = Convert.ToInt32(Console.ReadLine()) ;

            // Ask player fi they enter the number is correct from the number that save in favNumber
            Console.WriteLine("You enter the number " + favNumber + "as your favorite number! I love it!");
        }
    }
}
