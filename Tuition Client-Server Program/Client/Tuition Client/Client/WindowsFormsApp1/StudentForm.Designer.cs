namespace Tuition
{
    partial class StudentForm
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
            this.txtAmountToPay = new System.Windows.Forms.TextBox();
            this.lblAmountToPay = new System.Windows.Forms.Label();
            this.btnPayTuition = new System.Windows.Forms.Button();
            this.btnLogoutAdmin = new System.Windows.Forms.Button();
            this.clmTuitionHistory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstUsers = new System.Windows.Forms.ListView();
            this.labelAmountDue = new System.Windows.Forms.Label();
            this.amountFigure = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAmountToPay
            // 
            this.txtAmountToPay.Location = new System.Drawing.Point(673, 88);
            this.txtAmountToPay.Name = "txtAmountToPay";
            this.txtAmountToPay.Size = new System.Drawing.Size(125, 20);
            this.txtAmountToPay.TabIndex = 39;
            // 
            // lblAmountToPay
            // 
            this.lblAmountToPay.AutoSize = true;
            this.lblAmountToPay.Location = new System.Drawing.Point(588, 91);
            this.lblAmountToPay.Name = "lblAmountToPay";
            this.lblAmountToPay.Size = new System.Drawing.Size(79, 13);
            this.lblAmountToPay.TabIndex = 35;
            this.lblAmountToPay.Text = "Amount to Pay:";
            // 
            // btnPayTuition
            // 
            this.btnPayTuition.Location = new System.Drawing.Point(832, 86);
            this.btnPayTuition.Name = "btnPayTuition";
            this.btnPayTuition.Size = new System.Drawing.Size(100, 23);
            this.btnPayTuition.TabIndex = 23;
            this.btnPayTuition.Text = "Pay";
            this.btnPayTuition.UseVisualStyleBackColor = true;
            this.btnPayTuition.Click += new System.EventHandler(this.btnUpdateAdmin_Click);
            // 
            // btnLogoutAdmin
            // 
            this.btnLogoutAdmin.Location = new System.Drawing.Point(832, 294);
            this.btnLogoutAdmin.Name = "btnLogoutAdmin";
            this.btnLogoutAdmin.Size = new System.Drawing.Size(100, 23);
            this.btnLogoutAdmin.TabIndex = 21;
            this.btnLogoutAdmin.Text = "Logout";
            this.btnLogoutAdmin.UseVisualStyleBackColor = true;
            this.btnLogoutAdmin.Click += new System.EventHandler(this.btnLogoutAdmin_Click);
            // 
            // clmTuitionHistory
            // 
            this.clmTuitionHistory.Text = "Tuition History";
            this.clmTuitionHistory.Width = 200;
            // 
            // lstUsers
            // 
            this.lstUsers.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lstUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmTuitionHistory});
            this.lstUsers.Location = new System.Drawing.Point(36, 19);
            this.lstUsers.MultiSelect = false;
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(546, 298);
            this.lstUsers.TabIndex = 20;
            this.lstUsers.UseCompatibleStateImageBehavior = false;
            this.lstUsers.View = System.Windows.Forms.View.Details;
            // 
            // labelAmountDue
            // 
            this.labelAmountDue.AutoSize = true;
            this.labelAmountDue.Location = new System.Drawing.Point(587, 19);
            this.labelAmountDue.Name = "labelAmountDue";
            this.labelAmountDue.Size = new System.Drawing.Size(66, 13);
            this.labelAmountDue.TabIndex = 40;
            this.labelAmountDue.Text = "Amount Due";
            // 
            // amountFigure
            // 
            this.amountFigure.AutoSize = true;
            this.amountFigure.Location = new System.Drawing.Point(687, 19);
            this.amountFigure.Name = "amountFigure";
            this.amountFigure.Size = new System.Drawing.Size(43, 13);
            this.amountFigure.TabIndex = 41;
            this.amountFigure.Text = "100000";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 461);
            this.Controls.Add(this.amountFigure);
            this.Controls.Add(this.labelAmountDue);
            this.Controls.Add(this.txtAmountToPay);
            this.Controls.Add(this.lblAmountToPay);
            this.Controls.Add(this.btnPayTuition);
            this.Controls.Add(this.btnLogoutAdmin);
            this.Controls.Add(this.lstUsers);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmountToPay;
        private System.Windows.Forms.Label lblAmountToPay;
        private System.Windows.Forms.Button btnPayTuition;
        private System.Windows.Forms.Button btnLogoutAdmin;
        private System.Windows.Forms.ColumnHeader clmTuitionHistory;
        private System.Windows.Forms.ListView lstUsers;
        private System.Windows.Forms.Label labelAmountDue;
        private System.Windows.Forms.Label amountFigure;
    }
}