using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace WindowsFormsApp1
{
    public abstract  class User
    {
        protected string firstName;
        protected string lastName;
        protected string tuition;
        protected Boolean isAdmin = false;
        protected Socket sock = null;
        protected string username;
        public User(string username, Socket socket )
        {
            this.username = username;
            sock = socket;
        }
      public User(string username)
      {
         this.username = username;
      }
      public String GetUsername()
        {
            return username;
        }
        public void closeConnection()
        {
            byte[] msg = Encoding.ASCII.GetBytes("close,");
            sock.Send(msg);
            sock.Close();
        }
        public abstract string getInfo();
        
        
        public abstract void getInfoStart();
        
        
    }
}
