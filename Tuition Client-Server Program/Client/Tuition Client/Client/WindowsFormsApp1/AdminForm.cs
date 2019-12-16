using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tuition;

namespace WindowsFormsApp1
{

    public partial class UserForm : Form
    {

        List<Student> studentList;
        private Invoker undoRedo;
        public delegate void loadUser(User user);
        public loadUser loadUserInfo;
        private LoginForm login = new LoginForm();
        Admin loggedIn;
        LoginForm mainForm;
        public UserForm(LoginForm form, Admin admin)
        {
            mainForm = form;
            InitializeComponent();
            loggedIn = admin;
            undoRedo = new Invoker();
            studentList = new List<Student>();
            cmbFilterType.SelectedIndex = 0;
            cmbFliteredItem.SelectedIndex = 0;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            loggedIn.closeConnection();
            loggedIn = null;
            lstUsers.Clear();
            mainForm.Show();
            mainForm.BringToFront();
        }




        private void UserForm_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student stu = new Student(txtFirstName.Text, txtLastname.Text, txtUsername.Text, txtTuition.Text);
            AddStudent add = new AddStudent(stu, loggedIn);
            undoRedo.Add(stu, loggedIn );
            add.Execute();
            refresh();
            txtFirstName.Text = "";
            txtLastname.Text = "";
            txtPassword.Text = "";
            txtTuition.Text = "";
            txtUsername.Text = "";
            if (btnUndo.Enabled == false)
                btnUndo.Enabled = true;
        }
        private void AddStudent(string username, string password, string fName, string lName, string tuition)
        {
            Boolean added = loggedIn.AddStudent(username, password, "1", fName, lName, tuition);
            if (added)
            {
                refresh();
            }
        }
        private void AddStudentRedo(string username, string password, string fName, string lName, string tuition)
        {
            Boolean added = loggedIn.AddStudent(username, password, "1", fName, lName, tuition);
            refresh();
        }

        private void btnUpdateAdmin_Click(object sender, EventArgs e)
        {
            refresh();

        }
        private void refresh()
        {
            lstUsers.Items.Clear();
            studentList.Clear();
            loggedIn.getInfoStart();

            String message = loggedIn.getInfo();
            while (!message.Equals("finish"))
            {

                string[] info = message.Split(',');
                studentList.Add(new Student(info[2], info[3], info[0], info[1]));
                string[] row = { info[0], info[2], info[3], info[1] };
                message = loggedIn.getInfo();
                var listViewItem = new ListViewItem(row);
                lstUsers.Items.Add(listViewItem);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Student stu;
            for (int i = 0; i < studentList.Count; i++)
            {
                if (txtUsername.Text.Equals(studentList[i].GetUsername()))
                {
                    stu = studentList[i];
                    undoRedo.Remove(stu, loggedIn);
                    refresh();
                    break;
                }
            }
        }


        
        private void button2_Click_1(object sender, EventArgs e)
        {
            undoRedo.Redo();
            refresh();
            if (!undoRedo.canRedo())
                btnRedo.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            undoRedo.Undo();
            refresh();
            if (!undoRedo.canUndo())
                btnUndo.Enabled = false;
        }

        private void btnLogoutAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (!txtFilterVal.Text.Equals(""))
            {
                if (btnReset.Enabled == false)
                {
                    btnReset.Enabled = true;
                }
                else
                {
                    string item = cmbFliteredItem.SelectedIndex.ToString();
                    string type = cmbFilterType.SelectedIndex.ToString();

                }

            }
            Filter();
        }

        private void Filter()
        {
            lstUsers.Items.Clear();
            if (!txtFilterVal.Text.Equals(""))
            {
                string temp;
                for (int i = 0; i < studentList.Count; i++)
                {
                    Boolean match = true;
                    string str;
                    if (cmbFliteredItem.SelectedIndex == 0)
                    {
                        str = studentList[i].GetUsername();
                        if (txtFilterVal.Text.Length <= str.Length)
                        {
                            for (int j = 0; j < txtFilterVal.Text.Length; j++)
                                if (!str[j].Equals(txtFilterVal.Text[j]))
                                    match = false;
                        }
                        else
                            match = false;

                    }
                    else if (cmbFliteredItem.SelectedIndex == 1)
                    {
                        str = studentList[i].getFirstName();
                        if (txtFilterVal.Text.Length <= str.Length)
                        {
                            for (int j = 0; j < txtFilterVal.Text.Length; j++)
                                if (!str[j].Equals(txtFilterVal.Text[j]))
                                    match = false;
                        }
                        else
                            match = false;
                    }
                    else if (cmbFliteredItem.SelectedIndex == 2)
                    {
                        str = studentList[i].getLastName();
                        if (txtFilterVal.Text.Length <= str.Length)
                        {
                            for (int j = 0; j < txtFilterVal.Text.Length; j++)
                                if (!str[j].Equals(txtFilterVal.Text[j]))
                                    match = false;
                        }
                        else
                            match = false;
                    }
                    else if (cmbFliteredItem.SelectedIndex == 3)
                    {
                        try
                        {
                            float tuition = float.Parse(studentList[i].getTuition());
                            float filtered = float.Parse(txtFilterVal.Text);
                            if (cmbFilterType.SelectedIndex == 0)
                            {
                                if (!(tuition == filtered))
                                    match = false;
                            }
                            else if (cmbFilterType.SelectedIndex == 1)
                            {
                                if (!(filtered > tuition))
                                    match = false;
                            }
                            else if (cmbFilterType.SelectedIndex == 2)
                            {
                                if (!(filtered >= tuition))
                                    match = false;
                            }
                            else if (cmbFilterType.SelectedIndex == 3)
                            {
                                if (!(filtered < tuition))
                                    match = false;
                            }
                            else if (cmbFilterType.SelectedIndex == 4)
                            {
                                if (!(filtered <= tuition))
                                    match = false;
                            }
                        }
                        catch (Exception e)
                        {
                            match = false;
                        }

                    }
                    if (match)
                    {
                        temp = studentList[i].getStudentInfo();
                        string[] info = temp.Split(',');
                        string[] row = { info[0], info[1], info[2], info[3] };
                        var listViewItem = new ListViewItem(row);
                        lstUsers.Items.Add(listViewItem);
                    }
                }
            }
            else
            {
                string temp;
                for (int i = 0; i < studentList.Count; i++)
                {
                    temp = studentList[i].getStudentInfo();
                    string[] info = temp.Split(',');
                    string[] row = { info[0], info[1], info[2], info[3] };
                    var listViewItem = new ListViewItem(row);
                    lstUsers.Items.Add(listViewItem);
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            btnReset.Enabled = false;
            cmbFliteredItem.SelectedIndex = 0;
            cmbFilterType.SelectedIndex = 0;
            txtFilterVal.Text = "";
            Filter();
        }

        private void btnUpdateTuition_Click(object sender, EventArgs e)
        {
            loggedIn.UpdateTuition(txtTuition.Text, txtUsername.Text, txtFirstName.Text, txtLastname.Text);
            refresh();


        }

        private void cmbFliteredItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFliteredItem.SelectedIndex == 3)
            {
                cmbFilterType.Enabled = true;
            }
            else
            {
                cmbFilterType.Enabled = false;
                cmbFilterType.SelectedIndex = 0;
            }
        }

        
    }
}
