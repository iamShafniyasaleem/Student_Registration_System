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

namespace User_Registration
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-44S91MQ\\MSSQLSERVER01;Initial Catalog=userDetails;Integrated Security=True");

        private void button4_Click(object sender, EventArgs e)
        {
            string g = "";
            if (radioButton1.Checked)
            {
                g = radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                g = radioButton2.Text;
            }

            con.Open();
            SqlCommand command = new SqlCommand("insert into userTable1 values ('" + combo.Text + "','" + Name1.Text + "', getdate(),'" + g + "','" + textBox1.Text + "') ", con);
            command.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted!");
            con.Close();
            BindData();
        }
        void BindData()
        {
            SqlCommand command = new SqlCommand("select * from userTable1", con);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string g = "";
            if (radioButton1.Checked)
            {
                g = radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                g = radioButton2.Text;
            }
            con.Open();
            SqlCommand command = new SqlCommand("update userTable1 set Surname= '" +Name1.Text+"',Date_of_Birth= '"+DateTime.Parse(dateTimePicker1.Text)+"', Status='" + g + "' where NIC_Number='"+ textBox1.Text + "'", con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully updated!");
            BindData();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                
                    con.Open();
                    SqlCommand command = new SqlCommand("delete userTable1 where NIC_Number= '" + textBox1.Text + "'", con);
                    command.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully!");
                    BindData();
                
            }
            else
            {
                MessageBox.Show("Ooops!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)

        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
              {
                  foreach (Control control in controls)
                  {
                      if (control is TextBox)
                      {
                          (control as TextBox).Clear();
                      }
                      else
                      {
                          func(control.Controls);
                      }
                  }
              };
            func(Controls);
        }
    }
}
