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
    public partial class login : Form
        {
        int count = 0;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        public login()
            {
            InitializeComponent();
            }

       

        private void button1_Click(object sender, EventArgs e)
            {
                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText="select * from Table1 where user_name='"+textBox1.Text+"' and password='"+textBox2.Text+"' ";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count == 0)
                    {
                    MessageBox.Show("username or password does not match");
                    }
                else 
                    {
                    this.Hide();
                    user u1 = new user();
                    u1.Show();
                    }

            }

        private void login_Load(object sender, EventArgs e)
            {
            if (con.State == ConnectionState.Open)
                {
                con.Close();
                }
            con.Open();
            }

        private void panel1_Paint(object sender, PaintEventArgs e)
            {
            textBox1.Text = "parth";
            textBox2.Text = "parth";
            }
        }
    }
