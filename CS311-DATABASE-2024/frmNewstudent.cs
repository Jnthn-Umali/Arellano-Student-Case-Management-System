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
    public partial class frmNewstudent : Form
    {
        private string username;
        private int errorCount;
        Class1 newstudent = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmNewstudent(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (string.IsNullOrEmpty(txtstudentID.Text))
            {
                errorProvider1.SetError(txtstudentID, "StudentID is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtlastname.Text))
            {
                errorProvider1.SetError(txtlastname, "last name is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtfirstname.Text))
            {
                errorProvider1.SetError(txtfirstname, "First name is empty");
                errorCount++;
            }

            if (cmblevel.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmblevel, "Select level");
                errorCount++;
            }
            if (cmblevel.SelectedItem != null)
            {
                string selectedLevel = cmblevel.SelectedItem.ToString();
                if ((selectedLevel == "SHS" || selectedLevel == "COLLEGE") &&(cmbstrandcourse.SelectedIndex < 0 ||cmbstrandcourse.Items.Contains("No strands found") ||
                cmbstrandcourse.Items.Contains("No courses found")))
                {
                    errorProvider1.SetError(cmbstrandcourse, "Strand/Course is required");
                    errorCount++;
                }
            }
            try
            {
                DataTable dt = newstudent.GetData("SELECT * FROM tblstudents WHERE studentID = '" + txtstudentID.Text + "'");
                if (dt.Rows.Count > 0)
                {
                    errorProvider1.SetError(txtstudentID, "studentID already in use");
                    errorCount++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on validating existing account ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtstudentID.Clear();
            txtlastname.Clear();
            txtfirstname.Clear();
            txtmiddlename.Clear();
            cmblevel.SelectedIndex = -1;
            cmbstrandcourse.Enabled = false; // Disable the combo box to prevent selection
            cmbstrandcourse.DataSource = null; // Clear the data source
            cmbstrandcourse.Items.Clear(); // Ensure items are cleared
            cmbstrandcourse.SelectedIndex = -1; // Clear selection
            txtstudentID.Focus();
        }

        public event EventHandler StudentAdded;

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to add this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string strandCourseCode = (cmbstrandcourse.SelectedIndex < 0) ? "N/A" : cmbstrandcourse.SelectedValue.ToString();
                        newstudent.executeSQL("INSERT INTO tblstudents (studentID, lastname, firstname, middlename, level, strandcourse, datecreated, createdby) " +
                            "VALUES ('" + txtstudentID.Text + "', '" + txtlastname.Text + "', '" + txtfirstname.Text + "', " +
                            "'" + txtmiddlename.Text + "', '" + cmblevel.Text + "', '" + strandCourseCode.ToUpper() + "', " +
                            "'" + DateTime.Now.ToShortDateString() + "', '" + username + "')");

                        if (newstudent.rowAffected > 0)
                        {
                            newstudent.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                "','" + DateTime.Now.ToShortTimeString() + "','Add', 'Students Management', '" + txtstudentID.Text + "', '" + username + "')");
                            MessageBox.Show("New student added", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            StudentAdded?.Invoke(this, EventArgs.Empty); // Trigger event
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error on save new account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private DataTable GetStrands()
        {
            try
            {
                // Only selecting strandcode
                return newstudent.GetData("SELECT strandcode, description FROM tblstrands");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching strands", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private DataTable GetCourses()
        {
            try
            {
                // Only selecting coursecode
                return newstudent.GetData("SELECT coursecode, description FROM tblcourses");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error fetching courses", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void cmblevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear previous selections and data
            cmbstrandcourse.DataSource = null;  // Clear data source
            cmbstrandcourse.SelectedIndex = -1;  // Clear selection
            cmbstrandcourse.Enabled = false; // Disable the combo box initially

            if (cmblevel.SelectedItem != null)
            {
                string selectedLevel = cmblevel.SelectedItem.ToString();

                if (selectedLevel == "ELEMENTARY" || selectedLevel == "JUNIOR HIGH SCHOOL")
                {
                    // No strand/course for these levels
                    cmbstrandcourse.Enabled = false;  // Ensure it is disabled
                }
                else if (selectedLevel == "SENIOR HIGH SCHOOL")
                {
                    // Enable and populate the strand options (both codes and descriptions) from the database
                    DataTable dtStrands = GetStrands();
                    if (dtStrands != null && dtStrands.Rows.Count > 0 && dtStrands.Columns.Contains("strandcode") && dtStrands.Columns.Contains("description"))
                    {
                        cmbstrandcourse.Enabled = true;
                        cmbstrandcourse.DisplayMember = "description";  // Display stranddescription
                        cmbstrandcourse.ValueMember = "strandcode";  // Store strandcode as value
                        cmbstrandcourse.DataSource = dtStrands;  // Populate with SHS strands
                        cmbstrandcourse.SelectedIndex = -1;  // Clear selection
                    }
                    else
                    {
                        cmbstrandcourse.Enabled = false; // Ensure the combo box is enabled
                        cmbstrandcourse.DataSource = null; // Clear any existing data source
                        cmbstrandcourse.Items.Clear(); // Clear any existing items
                        cmbstrandcourse.Items.Add("No strands found"); // Add the message
                        cmbstrandcourse.SelectedIndex = 0; // Select the message as the only option
                    }
                }
                else if (selectedLevel == "COLLEGE")
                {
                    // Enable and populate the course options (both codes and descriptions) from the database
                    DataTable dtCourses = GetCourses();
                    if (dtCourses != null && dtCourses.Rows.Count > 0 && dtCourses.Columns.Contains("coursecode") && dtCourses.Columns.Contains("description"))
                    {
                        cmbstrandcourse.Enabled = true;
                        cmbstrandcourse.DisplayMember = "description";  // Display coursedescription
                        cmbstrandcourse.ValueMember = "coursecode";  // Store coursecode as value
                        cmbstrandcourse.DataSource = dtCourses;  // Populate with College courses
                        cmbstrandcourse.SelectedIndex = -1;  // Clear selection
                    }
                    else
                    {
                        cmbstrandcourse.Enabled = false; // Ensure the combo box is enabled
                        cmbstrandcourse.DataSource = null; // Clear any existing data source    
                        cmbstrandcourse.Items.Clear(); // Clear any existing items
                        cmbstrandcourse.Items.Add("No courses found"); // Add the message
                        cmbstrandcourse.SelectedIndex = 0; // Select the message as the only option
                    }
                }
            }
        }

        private void frmNewstudent_Load(object sender, EventArgs e)
        {
            cmbstrandcourse.Enabled = false;
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
