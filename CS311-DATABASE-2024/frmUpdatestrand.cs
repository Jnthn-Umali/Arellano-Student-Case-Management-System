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
    public partial class frmUpdatestrand : Form
    {
        private string username, editstrandcode, editdescription;
        private int errorCount;
        Class1 updatestrand = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmUpdatestrand(string username, string editstrandcode, string editdescription)
        {
            InitializeComponent();
            this.username = username;
            this.editstrandcode = editstrandcode;
            this.editdescription = editdescription;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Description is empty");
                errorCount++;
            }
        }
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            txtdescription.Clear();
            txtdescription.Focus();
        }
        public event EventHandler StrandUpdated;
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatestrand.executeSQL("UPDATE tblstrands SET strandcode = '" + txtstrandcode.Text + "', description = '" + txtdescription.Text.ToUpper() +
                        "' WHERE strandcode = '" + txtstrandcode.Text + "'");
                        if (updatestrand.rowAffected > 0)
                        {
                            updatestrand.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                               "','" + DateTime.Now.ToShortTimeString() + "','Update', 'Strands Management', '" + txtstrandcode.Text + "', '" + username + "')");
                            MessageBox.Show("Strand Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Trigger the StudentUpdated event
                            StrandUpdated?.Invoke(this, EventArgs.Empty);

                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on save  update course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void frmUpdatestrand_Load(object sender, EventArgs e)
        {
            txtstrandcode.Text = editstrandcode;
            txtdescription.Text = editdescription;
        }
    }
}
