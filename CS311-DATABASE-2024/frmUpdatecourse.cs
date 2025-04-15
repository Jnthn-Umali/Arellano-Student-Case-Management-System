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
    public partial class frmUpdatecourse : Form
    {
        private string username, editcoursecode, editdescription;
        private int errorCount;
        Class1 updatecourse = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmUpdatecourse(string username, string editcoursecode, string editdescription)
        {
            InitializeComponent();
            this.username = username;
            this.editcoursecode = editcoursecode;
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

        private void frmUpdatecourse_Load(object sender, EventArgs e)
        {
            txtcoursecode.Text = editcoursecode;
            txtdescription.Text = editdescription;
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

        public event EventHandler CourseUpdated;
        private void btnsave_Click_1(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        updatecourse.executeSQL("UPDATE tblcourses SET coursecode = '" + txtcoursecode.Text + "', description = '" + txtdescription.Text.ToUpper() +
                        "' WHERE coursecode = '" + txtcoursecode.Text + "'");
                        if (updatecourse.rowAffected > 0)
                        {
                            updatecourse.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                               "','" + DateTime.Now.ToShortTimeString() + "','Update', 'Courses Management', '" + txtcoursecode.Text + "', '" + username + "')");
                            MessageBox.Show("Course Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Trigger the StudentUpdated event
                            CourseUpdated?.Invoke(this, EventArgs.Empty);

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
    }
}
