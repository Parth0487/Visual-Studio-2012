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
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;

namespace book_world
    {
    public partial class book_stock : Form
        {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        
        public book_stock()
            {
            InitializeComponent();
            }

        private void book_stock_Load(object sender, EventArgs e)
            {
            if (con.State == ConnectionState.Open)
            {
            con.Close();
                }
            con.Open();
            fb1();
            }

        public void fb1()
        {
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select book_name,author_name,quantity,available_quantity from book_info";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        dataGridView1.DataSource = dt;
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            string i;
            i = dataGridView1.SelectedCells[0].Value.ToString();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from issue_book where book_name='"+ i.ToString() +"' ";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt1);
            dataGridView2.DataSource = dt1;
            }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
            {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select book_name,author_name,quantity,available_quantity from book_info WHERE book_name like ('%"+ textBox1.Text +"%')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            string i;
            i = dataGridView2.SelectedCells[6].Value.ToString();
            textBox2.Text = i.ToString();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            try
                {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sonubhavsar0487@gmail.com");
                mail.To.Add(textBox2.Text);
                mail.Subject = "BOOK RETURN NOTICE";
                mail.Body = textBox3.Text;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sonubhavsar0487@gmail.com", "sonu1997");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.ToString());
                }
            }

        }
    }
