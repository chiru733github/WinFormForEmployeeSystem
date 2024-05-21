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

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Updatecmd = new SqlCommand("Update Employee_Table set EmployeeName='"+textBox2.Text+"',Address='"+textBox3.Text+"',Salary="+textBox4.Text+",Role='"+comboBox1.Text+"' where EmployeeId="+textBox1.Text,conn);
                Updatecmd.ExecuteNonQuery();
                MessageBox.Show("Update Data Successfully");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally 
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Insertcmd = new SqlCommand("Insert into Employee_Table values("+textBox1.Text+",'"+textBox2.Text+"','"+textBox3.Text+"',"+textBox4.Text+",'"+comboBox1.Text+"')",conn);
                Insertcmd.ExecuteNonQuery();
                MessageBox.Show("Insert Data SuccessFully");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand Deletecmd = new SqlCommand("Delete from Employee_Table where EmployeeId="+textBox1.Text, conn);
                Deletecmd.ExecuteNonQuery();
                MessageBox.Show("Delete SuccessFully");
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

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text= comboBox1.Text ="";
        }
    }
}
