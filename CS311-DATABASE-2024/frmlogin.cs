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
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        Class1 login = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private int errorCount;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            //validation
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                errorProvider1.SetError(txtusername, "Username is empty");
            }
            if (string.IsNullOrEmpty(txtpassword.Text))
            {
                errorProvider1.SetError(txtpassword, "Password is empty");
            }
            //count errors
            errorCount = 0;
            foreach (Control c in errorProvider1.ContainerControl.Controls)
            {
                if (!(string.IsNullOrEmpty(errorProvider1.GetError(c))))
                {
                    errorCount++;
                }
            }
            //process and output
            if (errorCount == 0)
            {
                try
                {
                    DataTable dt = login.GetData("SELECT * FROM tblaccounts WHERE username = '" + txtusername.Text + "' AND password = '" + txtpassword.Text + "' AND status = 'ACTIVE'");
                    if (dt.Rows.Count > 0)
                    {
                        frmMain mainform = new frmMain (txtusername.Text, dt.Rows[0].Field<string>("usertype"));
                        mainform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect account information or account is inactive ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnreset_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            txtusername.Focus();
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnlogin_Click(sender, e);
            }
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;  // Assuming you have a label named label1
            label2.BackColor = Color.Transparent;  // Repeat for any other labels
            cbshow.BackColor = Color.Transparent;
            btnclose.BackColor = Color.Transparent;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
