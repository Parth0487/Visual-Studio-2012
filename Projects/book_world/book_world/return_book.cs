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
    public partial class return_book : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");

        public return_book()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            dataGridView1.Visible = true;
            fg(textBox1.Text);
            }

        private void return_book_Load(object sender, EventArgs e)
            {
            if (con.State == ConnectionState.Open)
            {
            con.Close();
                }
            
            con.Open();
            }

        public void fg(string enrollment)
            {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book where enrollment_no='" + enrollment.ToString() + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            panel2.Visible = true;
                label8.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                label5.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from issue_book where enrollment_no='" + textBox1.Text + "' ";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    {
                    dateTimePicker1.Value = Convert.ToDateTime(dr["return_date"].ToString());
                    }
                dr.Close();
                            
            TimeSpan diff = dateTimePicker2.Value.Date - dateTimePicker1.Value.Date;
            int a = Convert.ToInt32(diff.TotalDays);
                if (a > 0)
                    pen.Text = Convert.ToString(a * 3);
                else
                    pen.Text = "0";
            }

        private void button2_Click(object sender, EventArgs e)
            {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from issue_book where id="+label8.Text+"";
            cmd.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "update book_info set available_quantity=available_quantity+1 where book_name='"+label3.Text+"'";
            cmd1.ExecuteNonQuery();

            MessageBox.Show("BOOK RETURNED SUCCESSFULLY");
            fg(textBox1.Text);
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }
        }
    }
