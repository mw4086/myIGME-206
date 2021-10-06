using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE13
{
    class Program
    {
        //2
        public class Class1 : IInterface
        {
            public void aMethod()
            {
                Console.WriteLine("Something from Class1");
            }
        }

        public class Class2 : IInterface
        {
            public void aMethod()
            {
                Console.WriteLine("Something from Class2");
            }
        }

        //3
        public interface IInterface
        {
            void aMethod();
        }
        public static void MyMethod(object myObject)
        {
            IInterface iInterface = (IInterface)myObject;
            iInterface.aMethod();
        }

        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();
            MyMethod(class1);
            MyMethod(class2);
        }
    }
}

