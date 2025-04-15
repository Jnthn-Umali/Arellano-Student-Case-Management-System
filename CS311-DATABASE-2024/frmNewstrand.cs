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
    public partial class frmNewstrand : Form
    {
        private string username;
        private int errorCount;
        Class1 newcourse = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmNewstrand(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtstrandcode.Text))
            {
                errorProvider1.SetError(txtstrandcode, "Course code is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Description is empty");
                errorCount++;
            }
            try
            {
                DataTable dt = newcourse.GetData("SELECT * FROM tblstrands WHERE strandcode = '" + txtstrandcode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtstrandcode, "Code already in use");
                    errorCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing strand ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public event EventHandler StrandAdded;
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // SQL Insert query to add a student to tblstudents
                        newcourse.executeSQL("INSERT INTO tblstrands (strandcode, description, datecreated, createdby) " +
                            "VALUES ('" + txtstrandcode.Text + "', '" + txtdescription.Text.ToUpper() + "', " + "'" + DateTime.Now.ToShortDateString() + "', '" + username + "')");
                        if (newcourse.rowAffected > 0)
                        {
                            newcourse.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                "','" + DateTime.Now.ToShortTimeString() + "','Add', 'Strands Management', '" + txtstrandcode.Text + "', '" + username + "')");
                            MessageBox.Show("New course added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StrandAdded?.Invoke(this, EventArgs.Empty); // Trigger event
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

        private void btnclear_Click_1(object sender, EventArgs e)
        {

            txtstrandcode.Clear();
            txtdescription.Clear();
            txtstrandcode.Focus();
        }
    }
}
