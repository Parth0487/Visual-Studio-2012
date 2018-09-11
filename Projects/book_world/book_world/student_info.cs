using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace book_world
    {
    public partial class student_info : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
       
            
        public student_info()
            {
            InitializeComponent();
            }

        

        private void button2_Click(object sender, EventArgs e)
            {
            String s = @"^[0-9]$";
            bool hi = Regex.IsMatch(textBox3.Text, s);
            if (!hi)
                {
                MessageBox.Show("Please enter valid mobile num.");
                }
            else
                {
                try
                    {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_insert", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into student_info values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "') ";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully");
                    }
                catch (Exception ee)
                    {
                    MessageBox.Show(ee.Message);
                    }
                }
            }
        }
    }
