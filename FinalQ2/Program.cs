using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using System.Timers;

namespace PE21
{
    class Program
    {
        private static System.Timers.Timer aTimer;
        //ice-0,liquid-1,gas-2
        private static int[] rs = { 0, 1, 2, 0, 1, 2, 0, 1 };
        private static int time = 0;
        private static int move = 0;
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
        static int[,] AjMatrix = new int[,]
        {
                 /*A B C D E F G H*/
            /*A*/{-1,1,5,-1,-1,-1,-1,-1},
            /*B*/{-1,-1,-1,1,-1,7,-1,-1},
            /*C*/{-1,-1,-1,0,2,-1,-1,-1},
            /*D*/{-1,1,0,-1,-1,-1,-1,-1},
            /*E*/{-1,-1,2,-1,-1,-1,2,-1},
            /*F*/{-1,-1,-1,-1,-1,-1,-1,4},
            /*G*/{-1,-1,-1,-1,2,1,-1,-1},
            /*H*/{-1,-1,-1,-1,-1,-1,-1,-1}

        };

        class AdjList
        {
            LinkedList<Tuple<int, int>>[] adjList;
            public AdjList(int ver)
            {
                adjList = new LinkedList<Tuple<int, int>>[ver];
                for (int i = 0; i < adjList.Length; ++i)
                {
                    adjList[i] = new LinkedList<Tuple<int, int>>();
                }
            }
            public void addEnd(int start, int end, int weight)
            {
                adjList[start].AddLast(new Tuple<int, int>(end, weight));
            }
            public int getNumber()
            {
                return adjList.Length;
            }
            public LinkedList<Tuple<int, int>> this[int i]
            {
                get
                {
                    LinkedList<Tuple<int, int>> edge = new LinkedList<Tuple<int, int>>(adjList[i]);
                    return edge;
                }
            }
            public void printList()
            {
                int i = 0;
                foreach (LinkedList<Tuple<int, int>> list in adjList)
                {
                    foreach (Tuple<int, int> edge in list)
                    {
                        Console.Write("{0} -> ", i);
                        Console.WriteLine(edge.Item1 + "(" + edge.Item2 + ")");
                    }
                    ++i;
                }
            }
        }

        static void ExitDes(LinkedList<Tuple<int, int>> list, int hp)
        {
            if (hp - 1 > 0)
            {
                List<int> e = getExit(list, hp);
                if (e.Count > 0)
                {
                    Console.Write("The exit towards ");
                    PrintExit(e);
                    Console.Write("is available.");
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("Your HP too low, no exit avaialbe");
        }
        static void PrintExit(List<int> e)
        {
            char[] s = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
            foreach (int i in e)
            {
                Console.Write("{0} ", s[i]);
            }
        }
        static List<int> getExit(LinkedList<Tuple<int, int>> list, int hp)
        {
            List<int> r = new List<int>();
            foreach (Tuple<int, int> i in list)
            {
                if (i.Item2 < hp)
                {
                    r.Add(i.Item1);
                }
            }
            return r;
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
            return r;
        }
        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += onTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void onTimedEvent(Object source, ElapsedEventArgs e)
        {
            changeRoomState();
            time++;
        }
        private static void changeRoomState()
        {
            for (int i = 0; i < rs.Length; i++)
            {
                if (rs[i] == 2)
                {
                    rs[i] = 0;
                }
                else
                {
                    rs[i]++;
                }
            }
        }
        private static void changePlayerState(ref int ps, ref int hp)
        {
            //ice-0,liquid-1,gas-2
            hp--;
            string input;
            switch (ps)
            {
                case 0:
                    ps = 1;
                    break;
                case 1:
                    do
                    {
                        Console.Write("Do you wanna change to ice or gas? ");
                        input = Console.ReadLine();
                        input.ToLower();
                        switch (input)
                        {
                            case "ice":
                                ps = 0;
                                input = null;
                                break;
                            case "gas":
                                ps = 2;
                                input = null;
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                    } while (input != null);
                    break;
                case 2:
                    ps = 1;
                    break;
                default:
                    break;
            }
            Console.WriteLine("Your state now is {0}", GetState(ps));
        }
        private static string GetState(int s)
        {
            switch (s)
            {
                case 0:
                    return "ice";
                case 1:
                    return "liquid";
                case 2:
                    return "gas";
                default:
                    return "invalid state";
            }
        }
        private static int RoomToInt(string s)
        {
            switch (s)
            {
                case "A":
                    return 0;
                case "B":
                    return 1;
                case "C":
                    return 2;
                case "D":
                    return 3;
                case "E":
                    return 4;
                case "F":
                    return 5;
                case "G":
                    return 6;
                case "H":
                    return 7;
                default:
                    return -1;
            }
        }
        static void Main()
        {
            AdjList adjList = new AdjList(8);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (AjMatrix[i, j] > -1)
                    {
                        adjList.addEnd(i, j, AjMatrix[i, j]);
                    }
                }
            }
            // A-H, 0-7
            int loc = 0;
            int hp = 5;
            int dmg = 0;
            int ps = 0;
            string player_select = null;
            string q = "What do you wanna do? (select an exit or HP to wager or S to change State(cost 1hp)): ";
            Random r = new Random();
            List<int> e;


            string[] events = { "ant byte you", "your nail fall off" };
            string[] des = { "Bright Church", "Dark Dungeon", "Rainy Forest", "Small Village", "Wizard's House", "Elf's House", "Empire Base", "Water Spring" };
            Console.WriteLine("There is 8 room.The initial state of each node is:");
            Console.WriteLine("A = ice, B = liquid, C = gas, D = ice, E = liquid, F = gas, G = ice, H = liquid");
            Console.WriteLine("every second, each node transitions between ice, liquid and gas, such that it changes from ice -> liquid -> gas -> liquid -> ice -> liquid -> etc.  Imagine the rooms are constantly heating and freezing.");
            SetTimer();
            while (loc != 7)
            {
                Console.WriteLine("You have entered {0}.", des[loc]);
                Console.WriteLine(events[r.Next(0, events.Length)]);
                dmg = r.Next(1, 5);
                Console.WriteLine("You took {0} damage.", dmg);
                hp = Math.Max(1, hp - dmg);
                Console.WriteLine("You now have {0} hp.", hp);
                Console.WriteLine("Your state is {0}", GetState(ps));
                ExitDes(adjList[loc], hp);
                Console.Write(q);
                player_select = Console.ReadLine();
                player_select.ToUpper();
                while (player_select != null)
                {
                    switch (player_select)
                    {
                        case "A":  case "B":  case "C":  case"D":  case"E":  case"F":  case"G":  case"H": 
                            e = getExit(adjList[loc], hp);
                            int roomselect = RoomToInt(player_select);
                            if (e.Contains(roomselect))
                            {
                                if (rs[roomselect] == ps)
                                {
                                    hp -= AjMatrix[loc, roomselect];
                                    loc = roomselect;
                                    move++;
                                    player_select = null;
                                }
                                else
                                {
                                    Console.WriteLine("Room state not match");
                                    Console.Write(q);
                                    player_select = Console.ReadLine();
                                }
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
                            ExitDes(adjList[loc], hp);
                            Console.Write(q);
                            player_select = Console.ReadLine();
                            break;
                        case "S":
                            changePlayerState(ref ps, ref hp);
                            Console.Write(q);
                            player_select = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid Select");
                            Console.Write(q);
                            player_select = Console.ReadLine();
                            break;
                    }
                }
                while (player_select != null)
                {
                }
                if (hp < 0)
                {
                    Console.WriteLine("You Dead");
                    break;
                }
            }
            Console.WriteLine("You win! You took {0} moves and {1}s", move, time);
        }
    }
}