using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace my_form
    {
    public partial class Form2 : Form
        {
        public Form2()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            try
                {
                SqlConnection sc1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\documents\visual studio 2012\Projects\my_form\my_form\Database1.mdf;Integrated Security=True");
                sc1.Open();
                SqlCommand sc2 = new SqlCommand("select * from student1 where ENROLLMENT='"+textBox4.Text+"'", sc1);
                SqlDataReader dr;
                dr = sc2.ExecuteReader();
                while (dr.Read())
                    {
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox5.Text = dr[4].ToString();
                    textBox6.Text = dr[5].ToString();
                    textBox7.Text = dr[7].ToString();
                    comboBox1.SelectedItem = dr[6].ToString();
                    
                    }


                }
            catch (Exception ep)
                {
                MessageBox.Show(ep.ToString());
                }
            }

        private void BUTTON_Click(object sender, EventArgs e)
            {
            SqlConnection sc1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\documents\visual studio 2012\Projects\my_form\my_form\Database1.mdf;Integrated Security=True");
            sc1.Open();
            SqlCommand sc2 = new SqlCommand("update student1 set FIRST_NAME='" + textBox1.Text + "', MIDDLE_NAME='" + textBox2.Text + "', LAST_NAME='" + textBox3.Text + "', ENROLLMENT='" + textBox4.Text + "', ADDRESS='" + textBox5.Text + "', CONTACT_NO='" + textBox6.Text + "', GENDER='" + comboBox1.SelectedItem.ToString() + "', EMAIL='" + textBox7.Text + "',PIC='" + pictureBox1.Image + "' where ENROLLMENT='"+textBox4.Text+"'", sc1);
            sc2.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated");
            }
        }
    }
