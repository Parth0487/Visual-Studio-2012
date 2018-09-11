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
using System.Data.Sql;

namespace book_world
    {
    public partial class add_book : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
              
        public add_book()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e) 
            {
            try
                {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insert", con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into book_info values('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + Convert.ToString(dateTimePicker1.Text) + "'," + textBox5.Text + "," + textBox6.Text + "," + textBox6.Text + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                
                textBox5.Text = "";
                textBox6.Text = "";

                MessageBox.Show("BOOK ADDED SUCCESSFULLY");
                }
            catch (Exception ee)
                {
                MessageBox.Show(ee.Message);
                }
            }
        }
    }
