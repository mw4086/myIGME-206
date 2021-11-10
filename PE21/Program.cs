using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Web;

namespace PE21
{
    class Program
    {
        class Trivia
        {
            public int response_code;
            public List<TriviaResult> results;
        }

        class TriviaResult
        {
            public string category;
            public string type;
            public string difficulty;
            public string question;
            public string correct_answer;
            public List<string> incorrect_answers;
        }
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

        static int[,] dGraph = new int[,]
        {
         
                /*N*/ /*E*/ /*S*/ /*W*/
            /*A 0*/{0,0,1,-1},
            /*B 1*/{-1,3,2,-1},
            /*C 2*/{1,-1,7,-1},
            /*D 3*/{4,5,2,1},
            /*E 4*/{-1,-1,5,-1},
            /*F 5*/{-1,6,-1,-1},
            /*G 6*/{4,-1,7,-1},
            /*H 7*/{-1,-1,-1,-1}
        };
        static void Main()
        {
            // A-H, 0-7
            int loc = 0;
            int hp = 1;
            int dmg = 0;
            string player_select = null;
            Random r = new Random();

            string[] events = { "ant byte you", "your nail fall off" };
            string[] des = { "Bright Church", "Dark Dungeon", "Rainy Forest", "Small Village", "Wizard's House", "Elf's House", "Empire Base", "Water Spring" };
            while (loc != 7)
            {
                Console.WriteLine("You have entered {0}.", des[loc]);
                Console.WriteLine(events[r.Next(0, events.Length)]);
                dmg = r.Next(1,5);
                Console.WriteLine("You took {0} damage.", dmg);
                hp = Math.Max(1, hp - dmg);
                Console.WriteLine("You now have {0} hp.", hp);
                ExitDes(loc, hp);
                Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                player_select = Console.ReadLine();
                player_select.ToUpper();
                while (player_select != null)
                {
                    switch (player_select)
                    {
                        case "N":
                            if (checkExit(loc, hp, 0))
                            {
                                hp -= mGraph[loc, dGraph[loc, 0]];
                                loc = dGraph[loc, 0];
                                player_select = null;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Select");
                                Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                                player_select = Console.ReadLine();
                                break;
                            }
                            break;
                        case "E":
                            if (checkExit(loc, hp, 1))
                            {
                                hp -= mGraph[loc, dGraph[loc, 1]];
                                loc = dGraph[loc, 1];
                                player_select = null;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Select");
                                Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                                player_select = Console.ReadLine();
                                break;
                            }
                            break;
                        case "S":
                            if (checkExit(loc, hp, 2))
                            {
                                hp -= mGraph[loc, dGraph[loc, 2]];
                                loc = dGraph[loc, 2];
                                player_select = null;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Select");
                                Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                                player_select = Console.ReadLine();
                                break;
                            }
                            break;
                        case "W":
                            if (checkExit(loc, hp, 3))
                            {
                                hp -= mGraph[loc, dGraph[loc, 3]];
                                loc = dGraph[loc, 3];
                                player_select = null;
                            }
                            else
                            {
                                Console.WriteLine("Invalid Select");
                                Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                                player_select = Console.ReadLine();
                                break;
                            }
                            break;
                        case "HP":
                            hp += wager();
                            if (hp < 0)
                            {
                                Console.WriteLine("You Dead");
                                Console.ReadLine();
                                Environment.Exit(0);
                                break;
                            }
                            Console.WriteLine("You now have {0} hp.", hp);
                            ExitDes(loc, hp);
                            Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                            player_select = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid Select");
                            Console.Write("What do you wanna do? (N,E,S,W to select an exit or HP to wager): ");
                            player_select = Console.ReadLine();
                            break;
                    }
                }
            }
            Console.WriteLine("You Win");
            Console.ReadLine();
        }
        static void ExitDes(int loc, int hp)
        {
            string[] exit = { "North", "East", "South", "West" };
            if (hp - 1 > 0)
            {
                Console.Write("The exit at ");
                for (int j = 0; j < 4; j++)
                {
                    if (checkExit(loc, hp, j))
                    {
                        Console.Write("{0} ", exit[j]);
                    }
                }
                Console.Write("is available.");
                Console.WriteLine();
            }
        }
        static bool checkExit(int loc, int hp, int d)
        {
            return dGraph[loc, d] > -1 && hp - 1 > mGraph[loc, dGraph[loc, d]];
        }
        static int wager()
        {
            int r = 0;
            string p;
            Console.Write("How many HP do you wanna wager: ");
            p = Console.ReadLine();
            try
            {
                r = int.Parse(p);
            }
            catch { }
            string url = null;
            string s = null;
            List<String> C = new List<string>();

            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader reader;

            url = "https://opentdb.com/api.php?amount=10";

            request = (HttpWebRequest)WebRequest.Create(url);
            response = (HttpWebResponse)request.GetResponse();
            reader = new StreamReader(response.GetResponseStream());
            s = reader.ReadToEnd();
            reader.Close();

            Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

            trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
            trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
            for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
            {
                trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                C.Add(trivia.results[0].incorrect_answers[i]);
            }

            String Q, A, CA;
            int iA = -1;
            Random random = new Random();

            Q = trivia.results[0].question;
            CA = trivia.results[0].correct_answer;
            C.Insert(random.Next(0,C.Count),trivia.results[0].correct_answer);
            Console.WriteLine(Q);
            for(int i = 0; i < C.Count; i++)
            {
                Console.WriteLine("{0}:{1}", i, C[i]);
            }
            Console.WriteLine("Please select an answer: ");
            A = Console.ReadLine();
            try
            {
                iA = int.Parse(A);
            }
            catch { }
            if (C[iA] != CA)
            {
                Console.WriteLine("Wrong answer!");
                r = -r;
            }
            else
            {
                Console.WriteLine("Correct");
            }
            return r;
        }
    }
}