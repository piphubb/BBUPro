using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBUPro.form.category
{
    public partial class frmCategory : Form
    {
        models.clsCategory objCategory = new models.clsCategory();
        public frmCategory()
        {
            InitializeComponent();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            dgvCategory.DataSource = objCategory.GetDate();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            foreach(Control c in this.Controls)
            {
                if(c.GetType() == typeof(TextBox))
                {
                    c.Text = "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            objCategory.CATEGORYID = int.Parse(txtCategoryId.Text);
            objCategory.CATEGORYNAME = txtCategoryName.Text;
            objCategory.CATEGORYDESC = txtCategoryDesc.Text;

            if (objCategory.Insert())
            {
                dgvCategory.DataSource = objCategory.GetDate();
                MessageBox.Show("Insert Susses");
            }
            else
            {
                MessageBox.Show("Insert fail!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            objCategory.CATEGORYID = int.Parse(txtCategoryId.Text);
            objCategory.CATEGORYNAME = txtCategoryName.Text;
            objCategory.CATEGORYDESC = txtCategoryDesc.Text;

            if (objCategory.Update())
            {
                dgvCategory.DataSource = objCategory.GetDate();
                MessageBox.Show("Update Susses");
            }
            else
            {
                MessageBox.Show("Update fail!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to delete","Delete Category",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                objCategory.CATEGORYID = int.Parse(txtCategoryId.Text);

                if (objCategory.Delete())
                {
                    dgvCategory.DataSource = objCategory.GetDate();
                    MessageBox.Show("Delete Susses");
                }
                else
                {
                    MessageBox.Show("Delete fail!");
                }
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            dgvCategory.DataSource = objCategory.GetDate(txtSearch.Text);
        }

        private void dgvCategory_SelectionChanged(object sender, EventArgs e)
        {
            txtCategoryId.Text = dgvCategory.CurrentRow.Cells["CategoryId"].Value.ToString();
            txtCategoryName.Text = dgvCategory.CurrentRow.Cells["CategoryName"].Value.ToString();
            txtCategoryDesc.Text = dgvCategory.CurrentRow.Cells["CategoryDesc"].Value.ToString();
        }
    }
}
