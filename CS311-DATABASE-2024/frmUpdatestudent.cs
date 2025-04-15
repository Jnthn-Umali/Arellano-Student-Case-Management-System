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
    public partial class frmUpdatestudent : Form
    {
        private string username, editstudentID, editlastname, editfirstname, editmiddlename, editlevel, editstrandcourse;
        Class1 updatestudent = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private int errorCount;
        public frmUpdatestudent(string username, string editstudentID, string editlastname, string editfirstname, string editmiddlename, string editlevel, string editstrandcourse)
        {
            InitializeComponent();
            this.username = username;
            this.editstudentID = editstudentID;
            this.editlastname = editlastname;
            this.editfirstname = editfirstname;
            this.editmiddlename = editmiddlename;
            this.editlevel = editlevel;
            this.editstrandcourse = editstrandcourse;
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
                if ((selectedLevel == "SENIOR HIGH SCHOOL" || selectedLevel == "COLLEGE") && (cmbstrandcourse.SelectedIndex < 0 || cmbstrandcourse.Items.Contains("No strands found") ||
                cmbstrandcourse.Items.Contains("No courses found")))
                {
                    errorProvider1.SetError(cmbstrandcourse, "Strand/Course is required");
                    errorCount++;
                }
            }
            if ((cmbstrandcourse.Items.Contains("No strands found") || cmbstrandcourse.Items.Contains("No courses found")))
            {
                errorProvider1.SetError(cmbstrandcourse, "Strand/Course is required");
                errorCount++;
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtmiddlename_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtfirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtlastname_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbstrandcourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtstudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private DataTable GetStrands()
        {
            try
            {
                // Only selecting strandcode
                return updatestudent.GetData("SELECT strandcode, description FROM tblstrands");
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
                return updatestudent.GetData("SELECT coursecode, description FROM tblcourses");
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
            cmbstrandcourse.Items.Clear();

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

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtlastname.Clear();
            txtfirstname.Clear();
            txtmiddlename.Clear();
            cmblevel.SelectedIndex = -1;
            cmbstrandcourse.Enabled = false; // Disable the combo box to prevent selection
            cmbstrandcourse.DataSource = null; // Clear the data source
            cmbstrandcourse.Items.Clear(); // Ensure items are cleared
            cmbstrandcourse.SelectedIndex = -1; // Clear selection
            txtlastname.Focus();
        }

        public event EventHandler StudentUpdated;

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();
            if (errorCount == 0)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Get the selected strand or course code
                        string strandCourseCode = (cmbstrandcourse.SelectedIndex < 0) ? "N/A" : cmbstrandcourse.SelectedValue.ToString();

                        // SQL Update query to update the student details in tblstudents
                        updatestudent.executeSQL("UPDATE tblstudents SET lastname = '" + txtlastname.Text + "', firstname = '" + txtfirstname.Text + "', middlename = '" + txtmiddlename.Text +
                        "', level = '" + cmblevel.Text.ToUpper() + "', strandcourse = '" + strandCourseCode.ToUpper() +
                        "' WHERE studentID = '" + txtstudentID.Text + "'");

                        if (updatestudent.rowAffected > 0)
                        {
                            // Log the update action in tbllogs
                            updatestudent.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                               "','" + DateTime.Now.ToShortTimeString() + "','Update', 'Students Management', '" + txtstudentID.Text + "', '" + username + "')");
                            MessageBox.Show("Student Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Trigger the StudentUpdated event
                            StudentUpdated?.Invoke(this, EventArgs.Empty);

                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error updating student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void frmUpdatestudent_Load(object sender, EventArgs e)
        {
            txtstudentID.Text = editstudentID;
            txtlastname.Text = editlastname;
            txtfirstname.Text = editfirstname;
            txtmiddlename.Text = editmiddlename;
            cmblevel.SelectedItem = editlevel;  // Set the level (Elem, JHS, SHS, College)
            cmblevel_SelectedIndexChanged(sender, e);  // Load corresponding strand/course options
            if (cmbstrandcourse.DataSource != null)
            {
                cmbstrandcourse.SelectedValue = editstrandcourse;
            }
        }
    }
}
