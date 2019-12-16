using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
   public class Admin : User
   {
        /**
        This admin constructor initializes isAdmin to true so the admin class can
        have access to the server
        @param name of admin and sock
        */
        public Admin(string name, Socket sock) : base(name, sock)
        {
         
         isAdmin = true;
        }

        /**
        This method gets the info from the server that is stored in bytes
        and converts it to sting
        */
        public override string getInfo()
        {
         byte[] send = Encoding.ASCII.GetBytes("go");
         sock.Send(send);
         byte[] bytes = new byte[1024];
         int bytesRec = sock.Receive(bytes);
         string msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
         return msg;
        }

        /**
        This method converts the string messade to byte that the server can understand
        */
        public override void getInfoStart()
        {
         string msg = "lista,";
         byte[] send = Encoding.ASCII.GetBytes(msg);
         sock.Send(send);
        }

        /**
        This method removes student by taking the username entered and removing it.
        Returns true when deleted and false if it does not.
        @param username of student
        */
        public Boolean RemoveStudent(string username)
        {
         string msg = "remove," + username + ",";
         byte[] send = Encoding.ASCII.GetBytes(msg);
         sock.Send(send);
         byte[] bytes = new byte[1024];
         int bytesRec = sock.Receive(bytes);
         msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
         if (msg.Equals("true"))
            return true;
         else
            return false;

        }

        /**
        This method adds student to the server by taking the username, password, 
        tire which is usually 1 for student, first and last name and tuition.This
        would return true if student is sucessfully added and false if not.
        @param student's ussername, password, tier, fist name, last name and tuition.
        */
        public Boolean AddStudent(string username, string password, string tier, string fName, string lName, string tuition)
        {
         string msg = "add," + username + "," + tier + "," + password + "," + tuition + "," + fName + "," + lName + ",";
         byte[] send = Encoding.ASCII.GetBytes(msg);
         sock.Send(send);
         byte[] bytes = new byte[1024];
         int bytesRec = sock.Receive(bytes);
         msg = Encoding.ASCII.GetString(bytes, 0, bytesRec);
         if (msg.Equals("true"))
            return true;
         else
            return false;
        }

        /**
        This method updates the tuition on the server
        @param student's tuition, username, first name, last name
        */
        public void UpdateTuition(string tuition, string username, string fname, string lname)
        {
         string msg = "set," + username + "," + tuition + "," + fname + "," + lname + ",";
         byte[] send = Encoding.ASCII.GetBytes(msg);
         sock.Send(send);
        }
   }


}
