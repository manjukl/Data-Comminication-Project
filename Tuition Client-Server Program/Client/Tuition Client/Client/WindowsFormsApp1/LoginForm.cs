using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Tuition;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        private UserForm form;
        private const int STARTLOCKOUT = 30000;
        private int lockout = 0;
        private int lockoutCount = 0;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            byte[] bytes = new byte[1024];
            byte[] msg;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1888);
            Socket sock = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sock.Connect(remoteEP);
                // Encode the data string into a byte array.  
                msg = Encoding.ASCII.GetBytes("login," + username + "," + password);
                int bytesSent = sock.Send(msg);
                // Receive the response from the remote device.  
                int bytesRec = sock.Receive(bytes);
                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
                String response = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                string[] responseStrs = response.Split(',');

                if (responseStrs[0].Equals("1"))
                {
                    StudentForm stu = new StudentForm(this, new Student(responseStrs[2], responseStrs[3], username, responseStrs[1], sock));
                    this.Hide();
                    stu.Show();
                }
                else if (response.Equals("2"))
                {

                    UserForm adm = new UserForm(this, new Admin(username, sock));
                    adm.Show();
                    this.Hide();
                }
                else
                {
                    msg = Encoding.ASCII.GetBytes("close");
                    bytesSent = sock.Send(msg);
                    sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                    MessageBox.Show("Invalid username or password entered");
                    form = null;
                    if (lockout < 5)
                        lockout++;
                    else
                        LockForm();
                }
                if (form != null)
                {
                    form.Show();
                    this.Hide();
                    lockout = 0;
                    lockoutCount = 0;
                }
                txtPassword.Clear();
                txtUsername.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Create a TCP/IP  socket.  

            /*
             * This is the socket creation method.
             * 
             
             Semantics to login: "login," + username from textbox + "," + password from textbox + ","
             Server will send a 0, 1 or 2 on sending a login request.

            Semantics to set tuition: "set," + username + "," + new amount + ","
            semantics to get tuition: "get," + username +,"
            semantics to list students: "list,"

             replace the if and else if to correspond to these messages being sent, as the password
             is not being checked clientside anymore! The else can stay the way it is, just the first two parts
             
             The user class now has a socket object in it, use that object to store the socket created here and
             it will be used in the classes 
             if 0 is recieved use 
             msg = Encoding.ASCII.GetBytes("close");
             bytesSent = sender.Send(msg);
             sender.Shutdown(SocketShutdown.Both);
             sender.Close();
             
            use that above method WHENEVER a socket is closing or the server WILL CRASH!
            Please do not crash the server!

            Keep in mind the server is a SEPARATE PROJECT, meaning it will have to use another visual studio
            window with it as the specified server, this must be done to connect to the server.


             */
        }

        private void LockForm()
        {
            if (lockoutCount == 0)
            {
                MessageBox.Show("Exceeded maximum login attempts, please wait 30 seconds to try again.");
                tmrLock.Interval = STARTLOCKOUT;
            }
            else if (lockoutCount == 1)
            {
                MessageBox.Show("Exceeded maximum login attempts, please wait one minute to try again.");
                tmrLock.Interval = STARTLOCKOUT * 2;
                lockoutCount++;
            }
            else if (lockoutCount == 2)
            {
                MessageBox.Show("Exceeded maximum login attempts, please wait five minutes to try again.");
                tmrLock.Interval = STARTLOCKOUT * 10;
                lockoutCount++;
            }
            btnLogin.Enabled = false;
            tmrLock.Enabled = true;
        }

        private void tmrLock_Tick(object sender, EventArgs e)
        {
            if (btnLogin.Enabled == false)
            {
                btnLogin.Enabled = true;
                tmrLock.Enabled = false;
            }
        }


    }
}
