using System;
using System.Net;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using Tuition;

namespace TuitonServiceTests
{
    [TestClass]
    public class InvokerTest
    {
        [TestMethod]
        public void TestUndoRedo()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);
            Socket sock = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(remoteEP );
            Admin ad = new Admin("admin", sock);
            Student stu = new Student("text", "text", "text", "text", "11111");
            Invoker undo = new Invoker();

            try
            {
                
                

                undo.Add(stu, ad);
                ad.UpdateTuition("1", stu.GetUsername(), stu.getFirstName(), stu.getLastName());
                undo.Remove(stu, ad);
                undo.Undo();
                undo.Undo();
                if (undo.canUndo () != false)
                    Assert.Fail();
                undo.Redo();
                undo.Redo();
                if (undo.canRedo() != false)
                    Assert.Fail();
                undo.Undo();
                undo.Remove(stu, ad);
                if (undo.canRedo() != false)
                    Assert.Fail();
                ad.closeConnection();
            }
            catch(Exception e)
            {
                Assert.Fail(); 
            }
               

        }
    }
}
