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
    public partial class view_student_info : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");

        public view_student_info()
            {
            InitializeComponent();
            }

        private void view_student_info_Load(object sender, EventArgs e)
            {
            display();
            }



        private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
            try
                {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where student_name like('%" + textBox1.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                }
            catch (Exception ee2)
                {
                MessageBox.Show(ee2.Message);
                }
            }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
            {
            try
                {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where enrollment_no like('%" + textBox2.Text + "%')";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                }
            catch (Exception ee2)
                {
                MessageBox.Show(ee2.Message);
                }
            }

        private void button1_Click(object sender, EventArgs e)
            {
           
            try
                {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student_info set student_name='" + textBox3.Text + "', enrollment_no='" + textBox4.Text + "',branch='" + comboBox1.SelectedItem.ToString() + "',sem='" + comboBox2.SelectedItem.ToString() + "',contact_no='" + textBox5.Text + "',email='" + textBox6.Text + "' where id=" + textBox7.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Record Updated Successfully");
                
                }
            catch (Exception ee2)
                {
                MessageBox.Show(ee2.Message);
                }
            }

        

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                {
                panel1.Visible = true;
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                }
                
               
            }
        public void display()
            {
            try
                {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
                }
            catch (Exception ee2)
                {
                MessageBox.Show(ee2.Message);
                }
            }

        }
    }