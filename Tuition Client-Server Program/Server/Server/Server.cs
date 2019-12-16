using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.ServiceModel.Channels;

namespace Server
{
   class Server
   {
      //Startup main. 
      public static int Main(string[] args)
      {
         Listener listener = new Listener();
         listener.Listen();
         return 0;
      }

   }

   //The listener class uses threads to conntect to the client. The Listen class is an infinite accepting
   //loop, waiting for external connections. Menu is the main process for all threads, Login, GetTuition, and
   //SetTuition all take a socket and a set of command strings as a parameter, and then login and settuition will
   //notify the user that a process was done, while settuition will call gettuition to update the client's information.
   //
   public class Listener
   {
      //Loop method, creates and endpoint and listens to it for connections.
      public void Listen()
      {
         IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 1888);
         Socket listenSocket = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
         listenSocket.Bind(iPEndPoint);
         listenSocket.Listen(10);
         Socket handler = listenSocket.Accept();
         Console.WriteLine("Server Online!");
         while (true)
         {
            Thread t = new Thread(() => Menu(handler));
            t.Start();
            handler = listenSocket.Accept(); ;
         }
      }
      //Main method for the threads, reads in a comma-separated value from the client, 
      //and redirects the thread to the command. the thread layouts are as follows:
      // Login: "login,username,password," where login is the word login, and username
      //and password are set by the client. the last comma is to prevent old data from bleeding
      //into new data.
      //GetTuition: "get,username," where get is the word get, and the username is given by the client.
      //SetTuition: "set,username,tuition," where set is the word set, username is the username given by 
      //the client, and tuition is a number given by the client. as of right now, this server supports ints
      // for tuition, but will branch into floats or doubles to make it closer to monetary values.
      //AddUser: "add,
      //RemoveUser: "Remove,username"
      //ListStudents: "lista,"
      //ListTuition: "lists,"
      public void Menu(Socket handler)
      {

         byte[] msg = new byte[1024];
         int bytesRead = handler.Receive(msg);
         string command = Encoding.ASCII.GetString(msg);
         string[] myStrings = command.Split(',');

         while (myStrings[0] != "close")
         {
            if (myStrings[0].Equals("login"))
               Login(myStrings, handler);
            else if (myStrings[0].Equals("get"))
            {
               GetTuition(myStrings, handler);
            }
            else if (myStrings[0].Equals("set"))
            {
               SetTuition(myStrings, handler);
            }
            else if (myStrings[0].Equals("add"))
            {
               AddUser(myStrings, handler);
            }
            else if (myStrings[0].Equals("remove"))
            {
               RemoveUser(myStrings, handler);
            }
            else if (myStrings[0].Equals("lista"))
               ListStudents(handler);
            /*else if (myStrings[0].Equals("lists"))
               ListTuitionHistory(myStrings, handler);*/
            
            bytesRead = handler.Receive(msg);
            command = Encoding.ASCII.GetString(msg);
            myStrings = command.Split(',');
         }
         Console.WriteLine("Session Terminated");
      }


      private void ListTuitionHistory(string[] myStrings, Socket handler)
      {
         throw new NotImplementedException();
      }

      //Remove user removes a user, if found, from the database
      //
      private void RemoveUser(string[] myStrings, Socket handler)
      {
         string[] fileNames = Directory.GetDirectories("database");
         Boolean found = false;
         string name = "database\\" + myStrings[1];
         foreach (string fileName in fileNames)
         {
            if (name.Equals(fileName))
            {
               found = true;
            }
         }
         if (found)
         {
            File.Delete(name + "\\tier.txt");
            File.Delete(name + "\\password.txt");
            File.Delete(name + "\\tuition.txt");
            File.Delete(name + "\\history.txt");
            Directory.Delete(name);
            byte[] msg = Encoding.ASCII.GetBytes("true");
            handler.Send(msg);
         }
         else
         {
            byte[] msg = Encoding.ASCII.GetBytes("false");
            handler.Send(msg);
         }
      }

      //AddUser adds a new use into the database and sets up the required
      //files for the new user, then populates them.
      private void AddUser(string[] myStrings, Socket handler)
      {
         string[] fileNames = Directory.GetDirectories("database");
         string name = "database\\" + myStrings[1];
         Boolean dupe = false;
         foreach (string fileName in fileNames)
         {
            if (name.Equals(fileName))
            {
               dupe = true;
            }
         }
         if (!dupe)
         {
            string path = "database\\" + myStrings[1];
            Directory.CreateDirectory(path);
            string filename = path + "\\tier.txt";
            System.IO.File.AppendAllText(filename, myStrings[2]);
            filename = path + "\\password.txt";
            System.IO.File.AppendAllText(filename, myStrings[3]);
            filename = path + "\\tuition.txt";
            string tuition = myStrings[4] + "," + myStrings[5] + "," + myStrings[6];
            System.IO.File.AppendAllText(filename, tuition);
            filename = path + "\\history.txt";
                System.IO.File.AppendAllText(filename, myStrings[4]);

                byte[] msg = Encoding.ASCII.GetBytes("true");
            handler.Send(msg);
         }
         else
         {
            byte[] msg = Encoding.ASCII.GetBytes("false");
            handler.Send(msg);
         }

      }


      //lists all users with a tier of 1 in the database. used for getting student
      //objects, prints off one by one until the directory is fully read, then sends
      //finish to end to sending.
      private void ListStudents(Socket handler)
      {
         string[] fileNames = Directory.GetDirectories("database");
         foreach (string fileName in fileNames)
         {
            string path = fileName + "\\tier.txt";
            string[] tier = System.IO.File.ReadAllLines(path);
            if (tier[0].Equals("1"))
            {
               byte[] temp = new byte[1024];
               int garbage = handler.Receive(temp);
               path = fileName + "\\tuition.txt";
               string[] names = fileName.Split('\\');
               string[] info = System.IO.File.ReadAllLines(path);
               string mess = names[1] + "," + info[0];
               byte[] send = Encoding.ASCII.GetBytes(mess);
               handler.Send(send);

            }

         }
         byte[] bytes = new byte[1024];
         int bytesRec = handler.Receive(bytes);
         byte[] msg = Encoding.ASCII.GetBytes("finish");
         handler.Send(msg);
      }

      //SetTuition takes the command strings from the Menu method and
      //the connection socket as parameters. The username in the command
      //strings is used as the file directory name to get the tuition.txt
      //file path, and the file is overwritten with the new tuition
      private void SetTuition(string[] myStrings, Socket handler)
      {
         string path = "database\\" + myStrings[1] + "\\tuition.txt";
         float temp = float.Parse(myStrings[2]);
         System.IO.File.WriteAllText(path, myStrings[2] + "," + myStrings[3] + "," + myStrings[4]);
         path = "database\\" + myStrings[1] + "\\history.txt";
         string[] history = System.IO.File.ReadAllLines(path);
         System.IO.File.WriteAllText(path, myStrings[2] + "," + history[0]);
      }

      //GetTuition takes the command strings from the Menu method and
      //the connection socket as parameters. It will open the tuition.txt
      //file chosen by the client, and send the information over the handler
      //socket.
      private void GetTuition(string[] myStrings, Socket handler)
      {
         string path = "database\\" + myStrings[1] + "\\tuition.txt";
         string[] tuition = System.IO.File.ReadAllLines(path);
         byte[] msg = Encoding.ASCII.GetBytes(tuition[0]);
         handler.Send(msg);
      }

      //Login takes the command strings and the connection socket from the
      //Menu method and tests the usernames with the directories in
      // \database. If a match is found with the username, the server 
      //will compare the password to the password.txt file in the 
      //corresponding directory, else it will send a 0 to the client.
      //if the password matches, the socket will send a 1 or 2, based on
      //tier.txt in the same directory.
      private void Login(string[] myStrings, Socket socket)
      {
         string username = myStrings[1];
         string password = myStrings[2].Trim('\0');
         string[] fileNames = Directory.GetDirectories("database");
         foreach (string fileName in fileNames)
         {
            string[] names = fileName.Split('\\');
            if (username.Equals(names[1]))
            {
               string path = fileName;
               path = path + "\\password.txt";
               string[] filePassword = System.IO.File.ReadAllLines(path);
               if (password.Equals(filePassword[0]))
               {
                  path = fileName + "\\tier.txt";
                  string[] tier = System.IO.File.ReadAllLines(path);
                  Console.WriteLine("Login successful: " + username);
                  if (tier[0] == "1")
                  {
                     path = fileName + "\\tuition.txt";

                     string[] info = System.IO.File.ReadAllLines(path);
                     byte[] send = Encoding.ASCII.GetBytes(tier[0] + "," + info[0]);
                     socket.Send(send);
                  }
                  else
                  {
                     byte[] send = Encoding.ASCII.GetBytes(tier[0]);
                     socket.Send(send);
                  }
                  return;
               }
               else
               {
                  Console.WriteLine("Login failed: " + username);
                  byte[] send = Encoding.ASCII.GetBytes("0");
                  socket.Send(send);
                  return;
               }
            }
         }
         byte[] msg = Encoding.ASCII.GetBytes("0");
         socket.Send(msg);
      }
   }


}
