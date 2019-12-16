using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServerTest
{
    [TestClass]
    public class UnitTest1
    {

        /* Tests login on original connection with a student account, checks to make sure that
          the right values are sent back to the user so the account is not of the incorret level */

        [TestMethod]
        public void LoginWithStudent()
        {

            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);
                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes("login,student,password");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    string[] responseStrs = response.Split(',');
                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("1", responseStrs[0]);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }

            }
            catch (Exception e)
            {

            }


        }
        //tests that a student can update their tuition and then view it.
        [TestMethod]
        public void UpdateTuition()
        {


            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);
                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.ASCII.GetBytes("set,student,10000,John,Student,");
                    int bytesSent = sender.Send(msg);
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("10000.00", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }

            }
            catch (Exception e)
            {

            }


        }
        //tests that a student gets the tuition value associated with their account.
        [TestMethod]
        public void GetTuition()
        {


            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("get,student,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close,");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    int test = int.Parse(response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }

            }
            catch (Exception e)
            {

            }



        }
        /* Tests login on original connection with a admin account, checks to make sure that
          the right values are sent back to the user so the account is not of the incorret level */
        [TestMethod]
        public void LoginWithAdmin()
        {

            //Server.Listener listener = new Server.Listener();
            //listener.BeginListening();
            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("login,admin,password,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close,");
                    bytesSent = sender.Send(msg);

                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("2", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }

        // makes sure that the user cannot login with an incorrect password
        [TestMethod]
        public void LoginWithIncorrectPassword()
        {

            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("login,admin,pass,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close,");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("0", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }
        // Makes sure a user cannot login with an incorrect username
        [TestMethod]
        public void LoginWithIncorrectUsername()
        {


            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("login,asmin,password,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close,");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("0", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }
        // makes sure server can handle no username being sent
        [TestMethod]
        public void LoginWithNoUsernameButPassword()
        {


            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("login,,password,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("0", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Assert.Fail();
            }


        }
        // makes sure the server can handle a login without a password properly
        [TestMethod]
        public void LoginWithNoPassword()
        {

            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("login,admin,,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close,");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("0", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }
        // makes sure that the server can handle no username and password at the same time
        [TestMethod]
        public void LoginWithNoInformation()
        {


            byte[] bytes = new byte[1024];
            try
            {

                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(remoteEP);

                    byte[] msg = Encoding.ASCII.GetBytes("login,,,");
                    int bytesSent = sender.Send(msg);
                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                    String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    // Release the socket.  
                    msg = Encoding.ASCII.GetBytes("close,");
                    bytesSent = sender.Send(msg);
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Assert.AreEqual("0", response);
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }
        [TestMethod]
        /* IMPORTANT! Run DeleteStudent test AFTER running this test, results will not work otherwise.
         * 
         */
        public void AddStudent()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint. Catch any errors.  
            try
            {
                sender.Connect(remoteEP);
                byte[] bytes = new byte[1024];
                byte[] msg = Encoding.ASCII.GetBytes("add,student,1,password,0.00,John,Student,");
                int bytesSent = sender.Send(msg);
                // Receive the response from the remote device.  
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                // Release the socket.  
                msg = Encoding.ASCII.GetBytes("close,");
                bytesSent = sender.Send(msg);
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RemoveStudent()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sender.Connect(remoteEP);
                byte[] bytes = new byte[1024];
                byte[] msg = Encoding.ASCII.GetBytes("remove,student,");
                int bytesSent = sender.Send(msg);
                // Receive the response from the remote device.  
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                // Release the socket.  
                msg = Encoding.ASCII.GetBytes("close,");
                bytesSent = sender.Send(msg);
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

    }
}
