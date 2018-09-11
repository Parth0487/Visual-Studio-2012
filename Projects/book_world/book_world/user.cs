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
    public partial class user : Form
        {

        public user()
            {
            InitializeComponent();
            }

        private void aDDNEWBOOKToolStripMenuItem_Click(object sender, EventArgs e)
            {
            add_book ab = new add_book();
            ab.Show();
            }

        private void aVAILABLEBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
            {
            view_book vb = new view_book();
            vb.Show();
            }

        private void aDDSTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
            {
            student_info si = new student_info();
            si.Show();
            }

        private void vIEWSTUDENTINFOToolStripMenuItem_Click(object sender, EventArgs e)
            {
            view_student_info vi = new view_student_info();
            vi.Show();
            }

        private void iSSUEBOOKToolStripMenuItem_Click(object sender, EventArgs e)
            {
            issue_book ib = new issue_book();
            ib.Show();
            }

        private void rETURNBOOKToolStripMenuItem_Click(object sender, EventArgs e)
            {
            return_book rb = new return_book();
            rb.Show();
            }

        private void bOOKSTOCKToolStripMenuItem_Click(object sender, EventArgs e)
            {
            book_stock bs = new book_stock();
            bs.Show();
            }

        

       
        }
    }
