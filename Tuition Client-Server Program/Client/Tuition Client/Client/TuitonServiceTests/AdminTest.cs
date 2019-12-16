using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

namespace TuitonServiceTests
{
    [TestClass]
    class AdminTest
    {
        [TestMethod]
        public void TestListStudents()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);
            Socket sock = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(remoteEP);
            Admin ad = new Admin("admin", sock);
            string temp = ad.GetUsername();
            try
            {

                ad.getInfoStart();
                String message = ad.getInfo();
                while (!message.Equals("finish"))
                {

                    string[] info = message.Split(',');
                    float f = float.Parse(info[1]);
                    message = ad.getInfo();
                }
            }
            catch(Exception e)
            {
                Assert.Fail();
            }
        }
    }
    
}
