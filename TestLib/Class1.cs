using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    public abstract class ComputerUser
    {
        public string UserName;
        public abstract void showPermission();
        public virtual void showUsername()
        {
            Console.WriteLine("User Name: {0}", UserName);
        }
        private string permission;
        public string Permission
        {
            get
            {
                return permission;
            }
            set
            {
                permission = value;
            }
        }
    }
    public interface IComputerUser
    {
        void showPermission();
    }
    public interface IStudent
    {
        void showStudentID();
    }

    public class Student : ComputerUser, IComputerUser,IStudent
    {
        public string studentID;
        public Student(string userName,string ID)
        {
            this.studentID = ID;
            this.UserName = userName;
            Permission = "User Permission";
        }
        public override void showPermission()
        {
            Console.WriteLine(Permission);
        }

        public void showStudentID()
        {
            Console.WriteLine("ID:{0}", studentID);
        }
    }
    public class Admin : ComputerUser, IComputerUser
    {
        public Admin(string userName)
        {
            this.UserName = userName;
            Permission = "Adminiastrator Permission";
        }
        public override void showUsername()
        {
            Console.WriteLine("ADMIN: {0}", this.UserName);
        }
        public override void showPermission()
        {
            Console.WriteLine("!!!{0}!!!", Permission);
        }
    }
}