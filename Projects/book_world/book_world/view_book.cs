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
    public partial class view_book : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        
        public view_book()
            {
            InitializeComponent();
            }

        private void view_book_Load(object sender, EventArgs e)
            {
            display();
            }

        private void button1_Click(object sender, EventArgs e)
            {
                 try
                {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where book_name like '%"+textBox1.Text+"%'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                con.Close();
                }
            catch (Exception ee2)
            { MessageBox.Show(ee2.Message); }
            }

        private void button2_Click(object sender, EventArgs e)
            {
            int i = 0;
                 try
                {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where author_name like '%"+textBox2.Text+"%'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                dataGridView1.DataSource = dt;

                con.Close();
                }
            catch (Exception ee2)
            { MessageBox.Show(ee2.Message); }
            }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
                try
                {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where book_name like '%"+textBox1.Text+"%'";
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

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
            {
            try
                {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where author_name like '%"+ textBox2.Text +"%'";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
                {/*
                panel3.Visible = true;
            int i;
            i=Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            
            try
                {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book_info where id="+i+"";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                    {
                    textBox3.Text = dr["book_name"].ToString();
                    textBox4.Text = dr["author_name"].ToString();
                    textBox5.Text = dr["publication_name"].ToString();
                    dateTimePicker1.Text = dr["purchase_date"].ToString();
                    textBox7.Text = dr["price"].ToString();
                    textBox8.Text = dr["quantity"].ToString();
                    }

                con.Close();
                }
            catch (Exception ee2)
                {
                MessageBox.Show(ee2.Message);
                }
*/
            }

        private void button3_Click(object sender, EventArgs e)
            {
            try
                {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book_info set book_name='" + textBox3.Text + "', author_name='" + textBox4.Text + "',publication_name='" + textBox5.Text + "',purchase_date='" + Convert.ToString(dateTimePicker1.Text) + "',price=" + textBox7.Text + ",quantity=" + textBox8.Text + " where id ='"+textBox6.Text+"'";
                cmd.ExecuteNonQuery();
                con.Close();
                display();
                MessageBox.Show("Record Updated Successfully");
                panel3.Visible = false;
                }
            catch (Exception ee2)
                {
                MessageBox.Show(ee2.Message);
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
            cmd.CommandText = "select * from book_info";
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

        private void textBox2_KeyUp_1(object sender, KeyEventArgs e)
            {

            }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
            panel3.Visible = true;
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            }

        


        }
     }
        
    
