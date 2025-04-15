using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticket_management;

namespace CS311_DATABASE_2024
{
    public partial class frmUpdateviolation : Form
    {
        private string username, editvcode, editdescription, editvtype, editstatus;
        private int errorCount;
        public frmUpdateviolation(string username, string editvcode, string editdescription, string editvtype, string editstatus)
        {
            InitializeComponent();
            this.username = username;
            this.editvcode = editvcode;
            this.editdescription = editdescription;
            this.editvtype = editvtype;
            this.editstatus = editstatus;
        }

        Class1 updateviolation = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Description is empty");
                errorCount++;
            }
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Select usertype");
                errorCount++;
            }
            if (cmbstatus.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbstatus, "Select status");
                errorCount++;
            }
            if (cmbtype.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbtype, "Select violation type");
                errorCount++;
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtdescription.Clear();
            cmbstatus.SelectedIndex = -1;
            cmbtype.SelectedIndex = -1;
            txtdescription.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updateviolation.executeSQL("UPDATE tblviolations SET description = '" + txtdescription.Text + "',vtype = '" + cmbtype.Text.ToUpper() + "', status = '" +
                           cmbstatus.Text.ToUpper() + "'WHERE vcode ='" + txtvcode.Text + "'");
                        if (updateviolation.rowAffected > 0)
                        {
                            updateviolation.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                               "','" + DateTime.Now.ToShortTimeString() + "','Update', 'Violations Management', '" + txtvcode.Text + "', '" + username + "')");
                            MessageBox.Show("Account Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on save  update violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void frmUpdateviolation_Load(object sender, EventArgs e)
        {
            txtvcode.Text = editvcode;
            txtdescription.Text = editdescription;
            cmbtype.SelectedItem = editvtype;
            cmbstatus.SelectedItem = editstatus;  // Set the level 
        }
    }
}
