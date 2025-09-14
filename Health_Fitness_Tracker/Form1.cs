using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Fitness_Tracker
{
    public partial class Form1 : Form
    {
        private List<User> users;
        public Form1()
        {
            InitializeComponent();
            users = new List<User>();
            InitializeDataGridView();

        }
        private void InitializeDataGridView()
        {
            // Ensure that the DataGridView does not add columns automatically
            dataGridViewUsers.AutoGenerateColumns = false;

            // Add columns to the DataGridView only once
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", DataPropertyName = "Name" });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Age", HeaderText = "Age", DataPropertyName = "Age" });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Weight", HeaderText = "Weight", DataPropertyName = "Weight" });
            dataGridViewUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Height", HeaderText = "Height", DataPropertyName = "Height" });
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int age = int.Parse(txtAge.Text);
            double weight = double.Parse(txtWeight.Text);
            double height = double.Parse(txtHeight.Text);

            User user = new User(name, age, weight, height);

            users.Add(user);
            UpdateDataGridView();
            ClearForm();
        }
        private void UpdateDataGridView()
        {
            // Binding the list of users to the DataGridView
            dataGridViewUsers.DataSource = null;
            dataGridViewUsers.DataSource = users;
        }
        private void btnDisplayUser_Click(object sender, EventArgs e) {
            if (users.Count > 0)
            {
                UpdateDataGridView();
            }
            else
            {
                MessageBox.Show("No data available to display.", "No Data");
            }
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtAge.Clear();
            txtWeight.Clear();
            txtHeight.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
