using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12Q3
{
    class MyClass
    {

            private string myString;
            public virtual string GetString()
        {
            return myString;
        }
        class MyDerivedClass : MyClass
        {
            public override string GetString()
            {
                return base.GetString() + " (output from derived class)";
            }
        }
        class Program
        {
            public static void Main()
            {
                MyDerivedClass myDerivedClass = new MyDerivedClass();
                Console.WriteLine(myDerivedClass.GetString());
            }
        }
    }
}
