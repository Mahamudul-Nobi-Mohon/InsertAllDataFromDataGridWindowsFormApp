using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace InsertAllDataFromDataGridWindowsFormApp
{
           
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-QR81GF5\SQLEXPRESS;Initial Catalog=Sample_30-11-2016;Integrated Security=True");
        string Gender;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSaveToDatabase_Click(object sender, EventArgs e)
        {
            int count=0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into Employees (FirstName,LastName,Gender,Salary) values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "')", con);
                count = cmd.ExecuteNonQuery();
               con.Close();
               
              
            }
            if (count > 0)
            {
                MessageBox.Show("Inserted Sucessfully");
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBoxFirstName.Text, textBoxLastName.Text,Gender, textBoxSalary.Text);
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
            ClearAllTextbox();
        }

        private void ClearAllTextbox()
        {
            textBoxSalary.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "FeMale";
        }

        private void buttonRemoveRows_Click(object sender, EventArgs e)
        {
             //int count=0;
             //for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
             //{
                 dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            // }
        }
    }
}
