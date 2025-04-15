using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticket_management;

namespace CS311_DATABASE_2024
{
    public partial class frmNewaccount : Form
    {
        private string username;
        private int errorCount;
        Class1 newaccount = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmNewaccount(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Username is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Password is empty");
                errorCount++;
            }
            else if (txtpassword.TextLength < 6)
            {
                errorProvider1.SetError(txtpassword, "Password must be atleast 6 characters");
                errorCount++;
            }
            if (cmbtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbtype, "Select usertype");
                errorCount++;
            }
            try
            {
                DataTable dt = newaccount.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtusername, "Username already in use");
                    errorCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing account ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public event EventHandler AccountAdded;

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        newaccount.executeSQL("INSERT INTO tblaccounts (username, password, usertype, status, createdby, datecreated) VALUES ('" + txtusername.Text
                            + "', '" + txtpassword.Text + "','" + cmbtype.Text.ToUpper() + "', 'ACTIVE','" + username + "','" + DateTime.Now.ToShortDateString()
                            + "')");
                        if (newaccount.rowAffected > 0)
                        {
                            newaccount.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                "','" + DateTime.Now.ToShortTimeString() + "','Add', 'Accounts Management', '" + txtusername.Text + "', '" + username + "')");
                            MessageBox.Show("New account added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Trigger the AccountAdded event
                            AccountAdded?.Invoke(this, EventArgs.Empty);

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

        private void cbshow_CheckedChanged(object sender, EventArgs e)
        {
            if (cbshow.Checked == true)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpassword.Clear();
            cbshow.Checked = false;
            cmbtype.SelectedIndex = -1;
            txtusername.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewaccount_Load(object sender, EventArgs e)
        {
        }
    }
}
