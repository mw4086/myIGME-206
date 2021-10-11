using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE16
{
    public class Class1
    {
        public interface IMood
        {
            string Mood { get; }
        }

        public class Waiter:IMood
        {
            public string name;
            public string Mood
            {
                get
                {
                    return "Mad";
                }
            }
            public void ServeCustomer(HotDrink cup)
            {

            }
        }

        public class Customer : IMood
        {
            public string name;
            public string creditCardNumber;
            public string Mood
            {
                get
                {
                    return "Peace";
                }
            }
            public HotDrink HotDrink { get; set; }
        }

        public abstract class HotDrink
        {
            public bool instant;
            public bool milk;
            private byte sugar;
            public string size;
            public Customer customer;
            public string brand;

            public virtual void AddSugar(byte amount)
            {
                ++amount;
            }
            public abstract void Steam();

            public HotDrink(string brand)
            {
                this.brand = brand;
            }

            public HotDrink() { }
        }

        public class CupOfCoffee:HotDrink,ITakeOrder
        {
            public string beanType;
            public override void Steam()
            {

            }
            public void TakeOrder()
            {

            }

            //(brand:string):base(brand)
            public CupOfCoffee(string brand)
            {
                base.brand = brand;
            }
        }

        public interface ITakeOrder
        {
            void TakeOrder();
        }

        public class CupOfTea : HotDrink, ITakeOrder
        {
            public string leafType;

            public override void Steam()
            {

            }
            public void TakeOrder()
            {

            }
            public CupOfTea(bool customerlsWealthy)
            {

            }
        }

        public class CupOfCocoa : HotDrink, ITakeOrder
        {
            public static int numCups;
            public bool mashmallows;
            private string source;

            public string Source
            {
                set
                {
                    this.source = value;
                }
            }

            public override void Steam()
            {

            }

            public override void AddSugar(byte amount)
            {

            }
            
            public void TakeOrder()
            {

            }

            public CupOfCocoa()
            {
                this.mashmallows = false;
            }


            public CupOfCocoa(bool mashmallows)
            {
                this.brand = "Expensive Organic Brand";
                this.mashmallows = mashmallows;
            }
        }
    }
}
