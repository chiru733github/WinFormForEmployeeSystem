using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeWebForm
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-SBDVLFF5\SQLEXPRESS; Initial Catalog=WebForm;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Insertcmd = new SqlCommand("exec Insertdata " + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + comboBox1.Text + "'", conn);
                Insertcmd.ExecuteNonQuery();
                MessageBox.Show("Insert Data SuccessFully");
                GetEmployeeList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Updatecmd = new SqlCommand("exec Update_SP " + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + comboBox1.Text + "'", conn);
                Updatecmd.ExecuteNonQuery();
                MessageBox.Show("Updated Data Successfully");
                GetEmployeeList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Deletecmd = new SqlCommand("exec Delete_SP " + textBox1.Text, conn);
                Deletecmd.ExecuteNonQuery();
                MessageBox.Show("Delete SuccessFully");
                GetEmployeeList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox1.Text = "";
        }

        private void Fetch_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("EXEC FETCH_SP "+textBox1.Text, conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = dataTable;
        }

        void GetEmployeeList()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("EXEC SELECTALL_SP", conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dgv1.AutoGenerateColumns = false;
            dgv1.DataSource = dataTable;
        }    
    }
}
