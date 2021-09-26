using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Unit1Test1Q4
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        private static bool timeUp;
        private static string[] questions = { "What if your favorite color?", "What is the answer to life, the universe and everything?", "What is the airspeed velocity of an unladen swallow?" };
        private static string[] answers = { "black", "42", "What do you mean? African or European swallow?" };
        private static int chooseQuestion;
        public static void setTimer()
        {
            timeUp = false;
            aTimer = new System.Timers.Timer(5000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeUp = true;
            Console.WriteLine("Time's up!");
            Console.WriteLine("The answer is: {0}", answers[chooseQuestion]);
            Console.Write("Please press enter.");
        }
        static void Main(string[] args)
        {
            Game();
        }

        static void Game()
        {
            string playerAnswer;
            Console.Write("Choose your question (1-3): ");
            chooseQuestion = Convert.ToInt32(Console.ReadLine()) - 1;


            Console.WriteLine("You have 5 seconds to answer the following question:");
            Console.WriteLine(questions[chooseQuestion]);
            setTimer();
            playerAnswer = Console.ReadLine();
            if (timeUp)
            {
                playerAnswer = "";
            }
            if (playerAnswer == answers[chooseQuestion])
            {
                Console.WriteLine("Well Done!");
                PlayAgain();
            }
            else if (playerAnswer == "")
            {
                Console.WriteLine("The answer is: {0}", answers[chooseQuestion]);
                PlayAgain();
            }
            else
            {
                Console.WriteLine("Wrong! The answer is: {0}", answers[chooseQuestion]);
                PlayAgain();
            }
        }

        static void PlayAgain()
        {
            aTimer.Stop();
            Console.WriteLine("Play again?");
            string playAgain = Console.ReadLine();
            playAgain.ToLower();
            if (playAgain == "yes" || playAgain == "y")
            {
                Game();
            }
            else if (playAgain == "no" || playAgain == "n")
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