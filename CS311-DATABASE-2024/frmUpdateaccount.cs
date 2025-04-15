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
    public partial class frmUpdateaccount : Form
    {
        private string username, editusername, editpassword, edittype, editstatus;

        Class1 updateaccount = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private int errorCount;

        private void frmUpdateaccount_Load(object sender, EventArgs e)
        {
            txtusername.Text = editusername;
            txtpassword.Text = editpassword;
            cmbtype.SelectedItem = edittype;  // Set the level 
            cmbstatus.SelectedItem = editstatus;
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtpassword.Clear();
            cmbtype.SelectedIndex = -1;
            cmbstatus.SelectedIndex = -1;
            txtpassword.Focus();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmUpdateaccount(string username, string editusername, string editpassword, string edittype, string editstatus)
        {
            InitializeComponent();
            this.username = username;
            this.editusername = editusername;
            this.editpassword = editpassword;
            this.edittype = edittype;
            this.editstatus = editstatus;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
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
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Select status");
                errorCount++;
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

        public event EventHandler AccountUpdated;

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updateaccount.executeSQL("UPDATE tblaccounts SET password = '" + txtpassword.Text + "', usertype = '" + cmbtype.Text.ToUpper() +
                                                 "', status = '" + cmbstatus.Text.ToUpper() + "' WHERE username = '" + txtusername.Text + "'");
                        if (updateaccount.rowAffected > 0)
                        {
                            updateaccount.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                                     "','" + DateTime.Now.ToShortTimeString() + "','Update', 'Accounts Management', '" + txtusername.Text + "', '" + username + "')");
                            MessageBox.Show("Account Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Trigger the AccountUpdated event
                            AccountUpdated?.Invoke(this, EventArgs.Empty);

                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on save update account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





    }
}
