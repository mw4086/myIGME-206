using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE7
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int count = 0;
                using (var reader = File.OpenText(@"C:/Users/wwmms/source/repos/github/myIGME-206/PE7\templates/MadLibsTemplate.txt"))

                    while (reader.ReadLine() != null)
                    {
                        count++;
                    }

                string[] lines = System.IO.File.ReadAllLines(@"C:/Users/wwmms/source/repos/github/myIGME-206/PE7\templates/MadLibsTemplate.txt");

                Console.WriteLine("Please enter your name:");
                string playerName = Console.ReadLine();

                Console.WriteLine(playerName + " please choose story between 1 - " + count);
                int playerchoose = Convert.ToInt32(Console.ReadLine());

                string[] words = lines[playerchoose - 1].Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].StartsWith("{"))
                    {
                        Console.WriteLine("Please enter a " + words[i].Replace("_", " ").Replace("{", "").Replace("}", ""));
                        words[i] = Console.ReadLine();
                    }
                }
                string finalResult = string.Join(" ", words).Replace(" \\n ", Environment.NewLine).Replace(" .", ".");
                Console.WriteLine(finalResult);
                Console.WriteLine("Press Enter to Continue...");
                Console.Read();

                Console.WriteLine("Play Again? Y/N");
                while (true)
                {
                    string playAgain = Console.ReadLine().ToLower();
                    if (playAgain == "y")
                    {
                        Console.Clear();
                        break;
                    }
                    else if (playAgain == "n")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please re-enter the choice.");

                    }
                }
            }
        }
    }
}