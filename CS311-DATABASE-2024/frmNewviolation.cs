using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticket_management;

namespace CS311_DATABASE_2024
{
    public partial class frmNewviolation : Form
    {
        private string username;
        private int errorCount;
        Class1 newviolation = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmNewviolation(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtvcode.Text))
            {
                errorProvider1.SetError(txtvcode, "Code is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Description is empty");
                errorCount++;
            }
            if (cmbtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbtype, "Select violation type");
                errorCount++;
            }
            try
            {
                DataTable dt = newviolation.GetData("SELECT * FROM tblviolations WHERE vcode = '" + txtvcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtvcode, "Code already in use");
                    errorCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing violation ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtvcode.Clear();
            txtdescription.Clear();
            cmbtype.SelectedIndex = -1;
            txtvcode.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newviolation.executeSQL("INSERT INTO tblviolations (vcode, description, vtype, status, createdby, datecreated) VALUES ('" + txtvcode.Text
                           + "', '" + txtdescription.Text + "','" + cmbtype.Text.ToUpper() + "', 'ACTIVE','" + username + "','" + DateTime.Now.ToShortDateString() + "')");
                        if (newviolation.rowAffected > 0)
                        {
                            newviolation.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                "','" + DateTime.Now.ToShortTimeString() + "','Add', 'Violations Management', '" + txtvcode.Text + "', '" + username + "')");
                            MessageBox.Show("New account added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on save  new account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
