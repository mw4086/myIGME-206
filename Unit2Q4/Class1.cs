using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2Q4
{
    class Program
    {
        public static void Main()
        {
            Tardis objTardis = new Tardis();
            PhoneBooth objPhoneBooth = new PhoneBooth();
        }
        static void usePhoone(object obj)
        {
            PhoneInterface PI = (PhoneInterface)obj;
            PI.MakeCall();
            PI.HangUp();
            if(obj is PhoneBooth)
            {
                PhoneBooth pobj = (PhoneBooth)obj;
                pobj.OpenDoor();
            }
            else if(obj is Tardis)
            {
                Tardis tobj = (Tardis)obj;
                tobj.TimeTravel();
            }
        }
    }
    public class Tardis : RotaryPhone
    {
        private bool sonicScrewdriver;
        private byte whichDrWho;
        private string femaleSideKick;
        public double exteriorSurfaceArea;
        public double interiorVolume;

        public static bool operator == (Tardis a, Tardis b)
        {
            return a.whichDrWho == b.whichDrWho ? true : false;
        }
        public static bool operator !=(Tardis a, Tardis b)
        {
            return a.whichDrWho != b.whichDrWho ? true : false;
        }
        public static bool operator <(Tardis a, Tardis b)
        {
            if(a.whichDrWho == 10 && b.whichDrWho != 10)
            {
                return false;
            }
            else if (a.whichDrWho != 10 && b.whichDrWho == 10)
            {
                return true;
            }
            else
            {
                return a.whichDrWho < b.whichDrWho ? true : false;
            }
        }

        public static bool operator >(Tardis a, Tardis b)
        {
            if (a.whichDrWho == 10 && b.whichDrWho != 10)
            {
                return true;
            }
            else if (a.whichDrWho != 10 && b.whichDrWho == 10)
            {
                return false;
            }
            else
            {
                return a.whichDrWho > b.whichDrWho ? true : false;
            }
        }

        public static bool operator <=(Tardis a, Tardis b)
        {
            if (a.whichDrWho == 10)
            {
                if(b.whichDrWho != 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (b.whichDrWho == 10)
            {
                if(a.whichDrWho != 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return a.whichDrWho <= b.whichDrWho ? true : false;
            }
        }

        public static bool operator >=(Tardis a, Tardis b)
        {
            if (a.whichDrWho == 10)
            {
                if (b.whichDrWho != 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (b.whichDrWho == 10)
            {
                if (a.whichDrWho != 10)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return a.whichDrWho >= b.whichDrWho ? true : false;
            }
        }


        public byte WhichDrWho { get; }
        public string FemaleSideKick { get; }
        public void TimeTravel()
        {

        }
    }

    public class RotaryPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }
        public void MakeCall()
        {

        }
        public void HangUp()
        {

        }
        public override void Connect()
        {
         }
        public override void Disconnect()
        {
         }
    }

    public abstract class Phone
    {
        private string phoneNumber;
        public string address;

        public string PhoneNumber;
        public abstract void Connect();
        public abstract void Disconnect();
    }

    public class PhoneBooth : PushButtonPhone
    {
        private bool superMan;
        public double costPerCall;
        public bool phoneBook;

        public void OpenDoor()
        {

        }

        public void CloseDoor()
        {

        }
    }

    public class PushButtonPhone : Phone, PhoneInterface
    {
        public void Answer()
        {

        }

        public void MakeCall()
        {

        }

        public void HangUp()
        {

        }

        public override void Connect()
        {

        }

        public override void Disconnect()
        {

        }
    }
    public interface PhoneInterface
    {
        void Answer();

        void MakeCall();
        void HangUp();
    }

}
