using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit3TestQ6
{
    class Program
    {
        class Wizard : IComparable<Wizard>
        {
            public string name { get; set; }
            public int age { get; set; }
            public Wizard(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public int CompareTo(Wizard other)
            {
                return this.age - other.age ;
            }
        }

        static void Main()
        {
            List<Wizard> list = new List<Wizard>();
            list.Add(new Wizard("w1", 101));
            list.Add(new Wizard("w2", 102));
            list.Add(new Wizard("w3", 103));
            list.Add(new Wizard("w4", 104));
            list.Add(new Wizard("w5", 105));
            list.Add(new Wizard("w6", 106));
            list.Add(new Wizard("w7", 107));
            list.Add(new Wizard("w8", 108));
            list.Add(new Wizard("w9", 109));
            list.Add(new Wizard("w10", 110));
            list.Sort();
            foreach(Wizard item in list)
            {
                Console.WriteLine("{0}{1}", item.name, item.age);
            }
        }
    }
}
