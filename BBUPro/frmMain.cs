using BBUPro.form.category;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBUPro
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            clsGlobal.con.ConnectionString = "Data Source=orcl; User ID=system; Password=Admin@12345";
            try
            {
                clsGlobal.con.Open();
                MessageBox.Show("Connection Susses");
            }
            catch
            {
                MessageBox.Show("Connection Issue");
            }
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
