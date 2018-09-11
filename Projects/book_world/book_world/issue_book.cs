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

namespace book_world
    {
       
    public partial class issue_book : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");

        public issue_book()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            int i = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from student_info where enrollment_no='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
                {
                MessageBox.Show("Enrollment Does not Exist");
                }
            else
                {

                foreach (DataRow dr in dt.Rows)
                    {
                    textBox2.Text = dr["student_name"].ToString();
                    textBox3.Text = dr["branch"].ToString();
                    textBox4.Text = dr["sem"].ToString();
                    textBox5.Text = dr["contact_no"].ToString();
                    textBox6.Text = dr["email"].ToString();
                    
                    }
                }
            }

        private void issue_book_Load(object sender, EventArgs e)
            {
            if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                dateTimePicker2.Value = DateTime.Today.AddDays(10);

            }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
            {
            int count = 0;

            if (e.KeyCode != Keys.Enter)
                {
                listBox1.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where book_name like ('%"+textBox7.Text+"%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                count = Convert.ToInt32(dt.Rows.Count.ToString());

                if (count > 0)
                {
                listBox1.Visible = true;
                foreach (DataRow dr in dt.Rows)
                {
                listBox1.Items.Add(dr["book_name"].ToString());
                    }


                    }

                }
            }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Down)
            {
            listBox1.Focus();
            listBox1.SelectedIndex = 0;
                }
            }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
            {
            if (e.KeyCode == Keys.Enter)
            {
            textBox7.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
                }
            }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
            {
            textBox7.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
            }

        private void button2_Click(object sender, EventArgs e)
            {
            int b1 = 0;

            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con;
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "select * from book_info where book_name='" + textBox7.Text + "'";
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter sd2 = new SqlDataAdapter(cmd2);
            sd2.Fill(dt2);
            foreach (DataRow dr2 in dt2.Rows)
                {
                
                    {

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into issue_book values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "')";
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.CommandText = "update book_info set available_quantity=available_quantity-1 where book_name='" + textBox7.Text + "' ";
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("BOOK ISSUED");
                    
            
                }
            }

        
        }
    }
    }
