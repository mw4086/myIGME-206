using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    public abstract class Pet
    {
        private string name;
        public int age;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public Pet() { }

        public Pet(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual void Eat()
        {

        }
        public virtual void Play()
        {

        }
        public virtual void GotoVet()
        {

        }
    }

    public class Cat : Pet, ICat
    {
        public Cat() { }
        public override void Eat()
        {
            Console.WriteLine("{0}: wants to {1}", Name, "Eat something");
        }
        public override void Play()
        {
            Console.WriteLine("{0}: wants to {1}", Name, "Play something");
        }
        public void Purr()
        {
            Console.WriteLine("{0}: Meow(^・ω・^ )", Name);
        }
        public void Scratch()
        {
            Console.WriteLine("{0}: [PH]scratch", Name);
        }
        public override void GotoVet()
        {
            Console.WriteLine("{0}: not felling well", Name);
        }
    }

    public class Dog : Pet, IDog
    {
        public string license;
        public Dog(string szLicense, string szName, int nAge)
        {
            this.license = szLicense;
            base.Name = szName;
            base.age = nAge;
        }
        public override void Eat()
        {
            Console.WriteLine("{0}: wants to {1}", Name, "Eat something");
        }
        public override void Play()
        {
            Console.WriteLine("{0}: wants to {1}", Name, "Play something");
        }
        public void Bark()
        {
            Console.WriteLine("{0}: [PH]Bark_sound_here", Name);
        }
        public void NeedWalk()
        {
            Console.WriteLine("{0}: wants to walk", Name);
        }
        public override void GotoVet()
        {
            Console.WriteLine("{0}: not felling well", Name);
        }
    }

    public interface IDog
    {
        void Eat();
        void Play();
        void Bark();
        void NeedWalk();
        void GotoVet();
    }
    public interface ICat
    {
        void Eat();
        void Play();
        void Scratch();
        void Purr();
    }



    class Pets
    {
        public List<Pet> petList = new List<Pet>();

        public void Remove(Pet pet)
        {
            if (pet != null)
            {
                petList.Remove(pet);
            }
        }

        public void RemoveAt(int petEl)
        {
            petList.RemoveAt(petEl);
        }

        public int Count
        {
            get
            {
                return petList.Count;
            }
        }

        public void Add(Pet pet)
        {
            petList.Add(pet);
        }

        public Pet this[int nPetEl]
        {
            get
            {
                Pet returnVal;
                try
                {
                    returnVal = (Pet)petList[nPetEl];
                }
                catch
                {
                    returnVal = null;
                }
                return (returnVal);
            }
            set
            {
                if (nPetEl < petList.Count)
                {
                    petList[nPetEl] = value;
                }
                else
                {
                    petList.Add(value);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();
            Random rand = new Random();
            for (int i = 0; i < 50; i++)
            {
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("You bought a dog!");
                        Console.Write("Dog's Name => ");
                        string name = Console.ReadLine();

                        int iAge = 0;
                        do
                        {
                            Console.Write("Age => ");
                            string sAge = Console.ReadLine();
                            if (sAge.Length > 0)
                            {
                                if (int.TryParse(sAge, out iAge))
                                { break; }
                            }
                            else { break; }
                        } while (true);

                        Console.Write("License => ");
                        string ID = Console.ReadLine();

                        Dog new_dog = new Dog(ID, name, iAge);
                        pets.Add(new_dog);
                    }
                    else
                    {
                        Console.Write("You bought a cat!");
                        Console.Write("Cat's Name => ");
                        string name = Console.ReadLine();

                        Console.Write("Age => ");
                        int iAge = 0;
                        do
                        {
                            string sAge = Console.ReadLine();
                            if (sAge.Length > 0)
                            {
                                if (int.TryParse(sAge, out iAge))
                                { break; }
                            }
                            else { break; }
                        } while (true);


                        Cat new_cat = new Cat();
                        new_cat.age = iAge;
                        new_cat.Name = name;
                        pets.Add(new_cat);
                    }
                }
                else
                {
                    int rPet = rand.Next(0, pets.Count);
                    int rAct;
                    if (rPet != 0)
                    {
                        thisPet = pets[rPet];
                        if (thisPet.GetType() == typeof(Dog))
                        {
                            dog = (Dog)thisPet;
                            //iDog = new IDog();
                            rAct = rand.Next(1, 5);
                            switch (rAct)
                            {
                                case 1:
                                    dog.Eat();
                                    break;
                                case 2:
                                    dog.Play();
                                    break;
                                case 3:
                                    dog.Bark();
                                    break;
                                case 4:
                                    dog.NeedWalk();
                                    break;
                                case 5:
                                    dog.GotoVet();
                                    break;
                            }
                        }
                        else if (thisPet.GetType() == typeof(Cat))
                        {
                            //iCat = new ICat();
                            cat = (Cat)thisPet;

                            rAct = rand.Next(1, 4);
                            switch (rAct)
                            {
                                case 1:
                                    cat.Eat();
                                    break;
                                case 2:
                                    cat.Play();
                                    break;
                                case 3:
                                    cat.Scratch();
                                    break;
                                case 4:
                                    cat.Purr();
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
