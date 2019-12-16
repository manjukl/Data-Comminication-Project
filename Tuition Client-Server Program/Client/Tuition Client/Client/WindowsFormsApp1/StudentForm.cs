/* The StudentForm class is a form that maintains the Student's tuition information. 
   There are two main uses for this form: to see payment history/admin edits and 
   pay the tuition due. Will return to the LoginForm upon closure.
   
   Params: One Student class object and a reference to the LoginForm that created
   this object.
*/
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
using WindowsFormsApp1;
using System.Threading;

namespace Tuition
{
    public partial class StudentForm : Form
    {
        private PaymentForm form;
        private LoginForm mainform;
        private Student student;
        // Constructor, Instanciates the student using the class and the form to return to
        public StudentForm(LoginForm login, Student stu)
        {
            InitializeComponent();
            mainform = login;
            student = stu;
        }

        
        /* This method is invoked when the "Pay" button is clicked, will pull up
         * a PaymentForm instance and show it, disabling other controls until
         * the PaymentForm is finished with it's functions or closed.
         */
        private void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            
            //pay
            try
            {
                form = new PaymentForm(this);
                txtAmountToPay.Enabled = false;
                btnLogoutAdmin.Enabled = false;
                btnPayTuition.Enabled = false;
                form.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        //Executed upon the form first loading, calls refresh
        private void StudentForm_Load(object sender, EventArgs e)
        {
            refresh();
        }
        /* Refresh populates the lstUsers listview with instances,
         * which are the payment history records for the user. 
         * 
         */
        private void refresh()
        {
            lstUsers.Items.Clear();
            amountFigure.Text = student.getTuition();
            txtAmountToPay.Clear();
            this.Validate();
        }
        /* Pay is called by the PaymentForm class, and will either tell the
         * current student class to execute the method to update the server or
         * do nothing. will reenable the controls disabled by the pay button click method
         */
        public void Pay(Boolean valid)
        {
            if (valid)
            {
                float amountToPay = float.Parse(txtAmountToPay.Text);
                float amount = float.Parse(amountFigure.Text);

                float newAmount = amount - amountToPay;
                String temp = newAmount.ToString();

                amountFigure.Text = temp;
                txtAmountToPay.Clear();
                
                student.setTuition(temp);
                Thread.Sleep(100);
            }
            txtAmountToPay.Enabled = true;
            btnLogoutAdmin.Enabled = true;
            btnPayTuition.Enabled = true;
            refresh();
        }

        public string getTuition()
        {
            return student.getTuition();
        }
        //Logout closes this form
        private void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //When this form is closing in any way, it will show the main form and close
        //The server connection.
        private void StudentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            student.closeConnection();
            mainform.Show();
        }
    }
}
