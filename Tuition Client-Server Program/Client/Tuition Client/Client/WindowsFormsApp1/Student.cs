using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public class Student : User
    {
      private string password;
        public Student(string fName, string lName, string username, string tuition, Socket sock) : base(username, sock)
        {
            //this.name = name;
            this.username = username;
            this.firstName = fName;
            this.lastName = lName;
            this.tuition = tuition;
            
        }
      public Student(string fName, string lName, string username, string tuition) : base(username)
      {
         //this.name = name;
         this.username = username;
         this.firstName = fName;
         this.lastName = lName;
         this.tuition = tuition;

      }
      public Student(string fName, string lName, string username, string password, string tuition) : base(username)
      {
         //this.name = name;
         this.username = username;
         this.firstName = fName;
         this.lastName = lName;
         this.tuition = tuition;
         this.password = password;

      }
      public string getFirstName()
      {
         return firstName;
      }
      public string getLastName()
      {
         return lastName;
      }
      public string getStudentInfo()
      {
         return username + "," + firstName  + "," + lastName  + "," + tuition;
      }
      public string getPassword()
      {
         return password;
      }
      public string getTuition()
      {
         return tuition;
      }
      public override string getInfo()
        {
            byte[] send = Encoding.ASCII.GetBytes("go");
            sock.Send(send);
            byte[] bytes = new byte[1024];
            int bytesRec = sock.Receive(bytes);
            string msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
            return msg;
        }
        public override void getInfoStart()
        {
            string msg = "lists," + username + ",";
            byte[] send = Encoding.ASCII.GetBytes(msg);
            sock.Send(send);
        }
        public void setTuition(string tui)
        {
            string msg = "set," + username + "," + tui + "," + firstName  + "," + lastName  + ",";
            byte[] send = Encoding.ASCII.GetBytes(msg);
            sock.Send(send);
        }
    }
    

}
