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
    public partial class frmNewcourse : Form
    {
        private string username;
        private int errorCount;
        Class1 newcourse = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmNewcourse(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtcoursecode.Text))
            {
                errorProvider1.SetError(txtcoursecode, "Course code is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtdescription.Text))
            {
                errorProvider1.SetError(txtdescription, "Description is empty");
                errorCount++;
            }
            try
            {
                DataTable dt = newcourse.GetData("SELECT * FROM tblcourses WHERE coursecode = '" + txtcoursecode.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtcoursecode, "Code already in use");
                    errorCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing course ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtcoursecode.Clear();
            txtdescription.Clear();
            txtcoursecode.Focus();
        }

        public event EventHandler CourseAdded;
        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // SQL Insert query to add a student to tblstudents
                        newcourse.executeSQL("INSERT INTO tblcourses (coursecode, description, datecreated, createdby) " +
                            "VALUES ('" + txtcoursecode.Text + "', '" + txtdescription.Text.ToUpper() + "', " + "'" + DateTime.Now.ToShortDateString() + "', '" + username + "')");
                        if (newcourse.rowAffected > 0)
                        {
                            newcourse.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                "','" + DateTime.Now.ToShortTimeString() + "','Add', 'Courses Management', '" + txtcoursecode.Text + "', '" + username + "')");
                            MessageBox.Show("New course added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CourseAdded?.Invoke(this, EventArgs.Empty); // Trigger event
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

        private void frmNewcourse_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
