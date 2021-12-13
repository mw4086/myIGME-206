using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using System.Timers;
using Newtonsoft.Json;

namespace PE21
{
    class Program
    {
        sealed class Player
        {
            private Player() { }
            private static Player instance;
            public static Player Instance
            {
                get
                {
                    return instance ?? (instance = new Player());
                }
            }
            public string player_name;
            public int level;
            public int hp;
            public List<string> inventory = new List<string>();
            public string license_key;
            public void save()
            {
                string json = JsonConvert.SerializeObject(this);
                File.WriteAllText(@"player.json", json);
            }
            public void load()
            {
                string json = File.ReadAllText(@"player.json");
                instance = JsonConvert.DeserializeObject<Player>(json);
            }
            public void print()
            {
                Console.WriteLine("Player Name: {0}", instance.player_name);
                Console.WriteLine("Level: {0}", instance.level);
                Console.WriteLine("HP: {0}", instance.hp);
                Console.WriteLine("Inventory: ");
                foreach (string item in instance.inventory)
                {
                    Console.WriteLine("           {0}", item);
                }
                Console.WriteLine("License Key: {0}", instance.license_key);
            }
        }
        static void Main()
        {
            Player player = Player.Instance;
            player.player_name = "dschuh";
            player.level = 4;
            player.hp = 99;
            player.inventory.Add("spear");
            player.inventory.Add("water bottle");
            player.inventory.Add("hammer");
            //more
            player.license_key = "BFGU99-1454";

            string input = null;
            while (true)
            {
                Console.Write("S for save, L for load, P for print, Q for quit: ");
                input = Console.ReadLine();
                input.ToUpper();
                switch (input)
                {
                    case "S":
                        player.save();
                        break;
                    case "L":
                        player.load();
                        break;
                    case "P":
                        player.print();
                        break;
                    case "Q":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}