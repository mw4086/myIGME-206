using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerNumber = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
            int count = 0;

            Console.WriteLine("Guess the number! (0-100)");

            while(playerNumber != randomNumber && count <= 8)
            {
                playerNumber = Convert.ToInt32(Console.ReadLine());

                if(playerNumber < randomNumber)
                {
                    Console.WriteLine("No! The number I am thinking of is higher than " +playerNumber);
                    ++count;
                }

                else if (playerNumber > randomNumber)
                {
                    Console.WriteLine("No! The number I am thinking of is lower than " + playerNumber);
                    ++count;
                }
                else
                {
                    Console.WriteLine("Please enter the correct number!");
                }
            }

            if (playerNumber == randomNumber)
            {
                Console.Clear();
                Console.WriteLine("Yes! You get the correct number!");
                Console.WriteLine("You used " + count + " rounds!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You lose! the correct number is " + randomNumber);
                Console.ReadLine();
            }

        }
    }
}
