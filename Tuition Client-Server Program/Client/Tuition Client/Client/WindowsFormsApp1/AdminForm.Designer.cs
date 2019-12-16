namespace WindowsFormsApp1
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstUsers = new System.Windows.Forms.ListView();
            this.clmUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmLastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTuition = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLogoutAdmin = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbFliteredItem = new System.Windows.Forms.ComboBox();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.txtFilterVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblTuitionDue = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.txtTuition = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUpdateTuition = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmUsername,
            this.clmFirstName,
            this.clmLastName,
            this.clmTuition});
            this.lstUsers.Location = new System.Drawing.Point(12, 26);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(546, 285);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            // 
            // clmUsername
            // 
            this.clmUsername.Text = "Username";
            this.clmUsername.Width = 120;
            // 
            // clmFirstName
            // 
            this.clmFirstName.Text = "First Name";
            this.clmFirstName.Width = 120;
            // 
            // clmLastName
            // 
            this.clmLastName.Text = "Last Name";
            this.clmLastName.Width = 120;
            // 
            // clmTuition
            // 
            this.clmTuition.Text = "Tuition Due";
            this.clmTuition.Width = 100;
            // 
            // btnLogoutAdmin
            // 
            this.btnLogoutAdmin.Location = new System.Drawing.Point(814, 288);
            this.btnLogoutAdmin.Name = "btnLogoutAdmin";
            this.btnLogoutAdmin.Size = new System.Drawing.Size(100, 23);
            this.btnLogoutAdmin.TabIndex = 1;
            this.btnLogoutAdmin.Text = "Logout";
            this.btnLogoutAdmin.UseVisualStyleBackColor = true;
            this.btnLogoutAdmin.Click += new System.EventHandler(this.btnLogoutAdmin_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(814, 218);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 23);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove Student";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(814, 89);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh List";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnUpdateAdmin_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(814, 155);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Add Student";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbFliteredItem
            // 
            this.cmbFliteredItem.FormattingEnabled = true;
            this.cmbFliteredItem.Items.AddRange(new object[] {
            "Username",
            "First Name",
            "Last Name",
            "Tuition Due"});
            this.cmbFliteredItem.Location = new System.Drawing.Point(12, 346);
            this.cmbFliteredItem.Name = "cmbFliteredItem";
            this.cmbFliteredItem.Size = new System.Drawing.Size(121, 21);
            this.cmbFliteredItem.TabIndex = 5;
            this.cmbFliteredItem.SelectedIndexChanged += new System.EventHandler(this.cmbFliteredItem_SelectedIndexChanged);
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.Enabled = false;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Items.AddRange(new object[] {
            "=",
            "<",
            "<=",
            ">",
            ">="});
            this.cmbFilterType.Location = new System.Drawing.Point(219, 346);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(121, 21);
            this.cmbFilterType.TabIndex = 6;
            // 
            // txtFilterVal
            // 
            this.txtFilterVal.Location = new System.Drawing.Point(437, 346);
            this.txtFilterVal.Name = "txtFilterVal";
            this.txtFilterVal.Size = new System.Drawing.Size(121, 20);
            this.txtFilterVal.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filter Column";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "By";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(437, 392);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(121, 23);
            this.btnFilter.TabIndex = 10;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(12, 392);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(576, 94);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Username:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(576, 224);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 13;
            this.lblFirstName.Text = "First Name:";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(576, 294);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 14;
            this.lblLastName.Text = "Last Name:";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTuitionDue
            // 
            this.lblTuitionDue.AutoSize = true;
            this.lblTuitionDue.Location = new System.Drawing.Point(576, 26);
            this.lblTuitionDue.Name = "lblTuitionDue";
            this.lblTuitionDue.Size = new System.Drawing.Size(65, 13);
            this.lblTuitionDue.TabIndex = 15;
            this.lblTuitionDue.Text = "Tuition Due:";
            this.lblTuitionDue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(658, 89);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(125, 20);
            this.txtUsername.TabIndex = 1;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(658, 221);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(125, 20);
            this.txtFirstName.TabIndex = 3;
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(658, 291);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(125, 20);
            this.txtLastname.TabIndex = 4;
            // 
            // txtTuition
            // 
            this.txtTuition.Location = new System.Drawing.Point(658, 26);
            this.txtTuition.Name = "txtTuition";
            this.txtTuition.Size = new System.Drawing.Size(125, 20);
            this.txtTuition.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(576, 158);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(658, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(125, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(658, 392);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(125, 23);
            this.btnUndo.TabIndex = 22;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Enabled = false;
            this.btnRedo.Location = new System.Drawing.Point(814, 392);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(100, 23);
            this.btnRedo.TabIndex = 23;
            this.btnRedo.Text = "Redo";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnUpdateTuition
            // 
            this.btnUpdateTuition.Location = new System.Drawing.Point(814, 26);
            this.btnUpdateTuition.Name = "btnUpdateTuition";
            this.btnUpdateTuition.Size = new System.Drawing.Size(100, 23);
            this.btnUpdateTuition.TabIndex = 24;
            this.btnUpdateTuition.Text = "Update Tuition";
            this.btnUpdateTuition.UseVisualStyleBackColor = true;
            this.btnUpdateTuition.Click += new System.EventHandler(this.btnUpdateTuition_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Value";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 461);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUpdateTuition);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtTuition);
            this.Controls.Add(this.txtLastname);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblTuitionDue);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilterVal);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.cmbFliteredItem);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnLogoutAdmin);
            this.Controls.Add(this.lstUsers);
            this.Name = "UserForm";
            this.Text = "Tuition Management System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.ColumnHeader clmUsername;
        private System.Windows.Forms.ColumnHeader clmFirstName;
        private System.Windows.Forms.ColumnHeader clmLastName;
        private System.Windows.Forms.ColumnHeader clmTuition;
        private System.Windows.Forms.Button btnLogoutAdmin;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbFliteredItem;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.TextBox txtFilterVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblTuitionDue;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.TextBox txtTuition;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUpdateTuition;
        private System.Windows.Forms.Label label3;
    }
}

