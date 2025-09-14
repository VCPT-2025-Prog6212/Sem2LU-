namespace Health_Fitness_Tracker
{
    partial class Form1
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
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDisplayUser = new System.Windows.Forms.Button();
            this.btnClearForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(54, 342);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.RowHeadersWidth = 62;
            this.dataGridViewUsers.RowTemplate.Height = 28;
            this.dataGridViewUsers.Size = new System.Drawing.Size(714, 168);
            this.dataGridViewUsers.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(127, 38);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(127, 91);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(38, 20);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age";
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Location = new System.Drawing.Point(127, 138);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(59, 20);
            this.lblWeight.TabIndex = 3;
            this.lblWeight.Text = "Weight";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(127, 182);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(56, 20);
            this.lblHeight.TabIndex = 4;
            this.lblHeight.Text = "Height";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(246, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 26);
            this.txtName.TabIndex = 5;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(246, 85);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(207, 26);
            this.txtAge.TabIndex = 6;
            // 
            // txtWeight
            // 
            this.txtWeight.Location = new System.Drawing.Point(246, 135);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(207, 26);
            this.txtWeight.TabIndex = 7;
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(246, 182);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(207, 26);
            this.txtHeight.TabIndex = 8;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(54, 270);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(116, 34);
            this.btnAddUser.TabIndex = 9;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDisplayUser
            // 
            this.btnDisplayUser.Location = new System.Drawing.Point(246, 270);
            this.btnDisplayUser.Name = "btnDisplayUser";
            this.btnDisplayUser.Size = new System.Drawing.Size(115, 34);
            this.btnDisplayUser.TabIndex = 10;
            this.btnDisplayUser.Text = "Display User";
            this.btnDisplayUser.UseVisualStyleBackColor = true;
            this.btnDisplayUser.Click += new System.EventHandler(this.btnDisplayUser_Click);
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(446, 270);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(118, 34);
            this.btnClearForm.TabIndex = 11;
            this.btnClearForm.Text = "Clear Form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 547);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnDisplayUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWeight);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dataGridViewUsers);
            this.Name = "Form1";
            this.Text = "Health & Fitness Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDisplayUser;
        private System.Windows.Forms.Button btnClearForm;
    }
}

