using System;
using System.IO;
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

namespace my_form
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }


        private void BUTTON_Click(object sender, EventArgs e)
            {
            save();
            }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
            }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
            {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            comboBox1.Text = "";

            }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
            {
            save();
            }
        void save()
            {
            if (textBox1.Text == "")
                {
                MessageBox.Show("Please enter First Name");
                }

            else if (textBox2.Text == "")
                {
                MessageBox.Show("Please enter Middle Name");
                }
            else if (textBox3.Text == "")
                {
                MessageBox.Show("Please enter Last Name");
                }
            else if (textBox4.Text == "")
                {
                MessageBox.Show("Please enter your Enrollment");
                }
            else if (textBox5.Text == "")
                {
                MessageBox.Show("Please enter Address");
                }
            if (textBox6.Text == "")
                {
                MessageBox.Show("Please enter Contact No");
                }
            if (comboBox1.Text == "")
                {
                MessageBox.Show("Please Select Your Gender");
                }
            if (textBox7.Text == "")
                {
                MessageBox.Show("Please enter your Email");
                }
            try
                {
                SqlConnection sc1 = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\PARTH\documents\visual studio 2012\Projects\my_form\my_form\Database1.mdf;Integrated Security=True");
                sc1.Open();
                SqlCommand sc2 = new SqlCommand("Insert into student1(FIRST_NAME, MIDDLE_NAME, LAST_NAME, ENROLLMENT, ADDRESS, CONTACT_NO, GENDER, EMAIL,PIC) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + textBox7.Text + "','"+pictureBox1.Image+"')", sc1);
                sc2.ExecuteNonQuery();
                MessageBox.Show("Saved HAHA");
                }
            catch (Exception ep)
                {
                MessageBox.Show(ep.ToString());
                }


            }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
            {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                Application.Exit();
                }

            }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
            {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            openFileDialog1.Filter = "image|*.jpeg;*.jpg;*.png;*.bmp;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                }
            }

        
        }
    }
