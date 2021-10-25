using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace test
{
    public class Example
    {
        public static void Main()
        {
            SortedList<string, DateTime> friendBirthdays = new SortedList<string, DateTime>();
            string pattern = "MM-dd-yyyy";
            foreach (var item in friendBirthdays)
            {
                Console.WriteLine("Name: {0}, Birthdays:{1}", item.Key,item.Value.ToString("MM/dd/yyyy"));
            }

            string[] dateValues = { "30-12-2011", "12-30-2011",
                              "30-12-11", "12-30-11" };
            string pattern = "MM-dd-yyyy";
            DateTime parsedDate;
            Console.WriteLine("");

            foreach (var dateValue in dateValues)
            {
                if (DateTime.TryParseExact(dateValue, pattern, null,
                                          DateTimeStyles.None, out parsedDate))
                    Console.WriteLine("Converted '{0}' to {1:d}.",
                                      dateValue, parsedDate);
                else
                    Console.WriteLine("Unable to convert '{0}' to a date and time.",
                                      dateValue);
            }
            Console.ReadLine();
        }
    }
}

using System;

namespace StructToClass
{
    public class Friend
    {
        public string name;
        public string greeting;
        public DateTime birthdate;
        public string address;
    }

    class Program
    {

        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy = new Friend();

            // create my friend Charlie Sheen
            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            //enemy = friend;

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");
        }
    }
}