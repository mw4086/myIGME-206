using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1Test1Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        static void Game()
        {
            string playerAnswer;
            Console.WriteLine("Choose your question");
            int chooseQuestion = Convert.ToInt32(Console.ReadLine());

            switch (chooseQuestion)
            {
                case 1:
                    Console.WriteLine("What if your favorite color?");
                    playerAnswer = Console.ReadLine();
                    if (playerAnswer == "black")
                    {
                        Console.WriteLine("Well Done!");
                        PlayAgain();
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The Answer is: black");
                        PlayAgain();
                    }
                    break;
                case 2:
                    Console.WriteLine("What is the answer to life, the universe and everything?");
                    playerAnswer = Console.ReadLine();
                    if (playerAnswer == "42")
                    {
                        Console.WriteLine("Well Done!");
                        PlayAgain();
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The Answer is: 42");
                        PlayAgain();
                    }
                    break;
                case 3:
                    Console.WriteLine("What is the airspeed velocity of an unladen swallow?");
                    playerAnswer = Console.ReadLine();
                    if (playerAnswer == "What do you mean? African or European swallow?")
                    {
                        Console.WriteLine("Well Done!");
                        PlayAgain();
                    }
                    else
                    {
                        Console.WriteLine("Wrong! The Answer is: what do you mean? African or European swallow?");
                        PlayAgain();
                    }
                    break;
            }
        }

        static void PlayAgain()
        {
            Console.WriteLine("Play again?");
            string playAgain = Console.ReadLine();
            playAgain.ToLower();
            if(playAgain == "yes" || playAgain == "y")
            {
                Game();
            }
            else if(playAgain == "no" || playAgain == "n")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Please re-enter the correct string");
                PlayAgain();
            }
        }
    }
}
