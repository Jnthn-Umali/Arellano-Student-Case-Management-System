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
    public partial class frmUpdatecase : Form
    {
        private string username, caseID, studentID, lastname, firstname, middlename, level, strandcourse, vcode, description, vcount, status, action, schoolyear, concernlevel;
        private string disiplinaryaction;

        Class1 updatecase = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private int errorCount;
        public frmUpdatecase(string username, string caseID,string studentID,string lastname,string firstname, string middlename, string level, 
            string strandcourse, string vcode,string description,string vcount,string status, string action, string schoolyear, string concernlevel, string disiplinaryaction)
        {
            InitializeComponent();
            this.username = username;
            this.caseID = caseID;
            this.studentID = studentID;
            this.lastname = lastname;
            this.firstname = firstname;
            this.middlename = middlename;
            this.level = level;
            this.strandcourse = strandcourse;
            this.vcode = vcode;
            this.description = description;
            this.vcount = vcount;
            this.status = status;
            this.action = action;
            this.schoolyear = schoolyear;
            this.concernlevel = concernlevel;
            this.disiplinaryaction = disiplinaryaction;
            this.Load += frmUpdatecase_Load;  // Subscribing to the Load event
        }
        private void validateForm()
        {
            errorProvider1.Clear();
            errorCount = 0;
            if (cmbstatus.SelectedItem != null && cmbstatus.SelectedItem.ToString().ToUpper() == "RESOLVED" && string.IsNullOrEmpty(txtaction.Text))
            {
                errorProvider1.SetError(txtaction, "Action is required for resolved cases.");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtsy.Text))
            {
                errorProvider1.SetError(txtsy, "School year is empty");
                errorCount++;
            }
            if (cmbconcern.SelectedIndex < 0)
            {
                errorProvider1.SetError(cmbconcern, "Concern level is empty");
                errorCount++;
            }
            if (string.IsNullOrEmpty(txtdisiplinary.Text))
            {
                errorProvider1.SetError(txtdisiplinary, "Disciplinary actions is empty");
                errorCount++;
            }
        }

        private void cmbstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if cmbstatus is selected and has a valid value
            if (cmbstatus.SelectedItem != null)
            {
                // Check if the selected value is "ONGOING" or "RESOLVED"
                if (cmbstatus.SelectedItem.ToString().ToUpper() == "ONGOING")
                {
                    txtaction.Enabled = false;  // Disable txtaction if status is "ONGOING"
                    txtaction.Clear();  // Optionally clear the action text
                }
                else
                {
                    txtaction.Enabled = true;  // Enable txtaction for other statuses
                }
            }
        }

        private void frmUpdatecase_Load(object sender, EventArgs e)
        {
            LoadViolationIDs();

            // Set the status value
            txtcaseid.Text = caseID;
            txtstudentid.Text = studentID;
            txtlastname.Text = lastname;
            txtfirstname.Text = firstname;
            txtmiddlename.Text = middlename;
            txtlevel.Text = level;
            txtstrandcourse.Text = strandcourse;

            cmbviolationid.SelectedItem = vcode;

            txtviolationdescription.Text = description;
            cmbviolationcount.SelectedItem = vcount;
            cmbstatus.SelectedItem = status;

            // Set the action text value
            txtaction.Text = action;
            txtsy.Text = schoolyear;
            cmbconcern.SelectedItem = concernlevel;
            txtdisiplinary.Text = disiplinaryaction;

            // Disable txtaction if the status is "ONGOING"
            if (status.ToUpper() == "ONGOING")
            {
                txtaction.Enabled = false;
                txtaction.Clear();  // Optionally clear the action text
            }
            else
            {
                txtaction.Enabled = true;
            }
        }
        private void LoadViolationIDs()
        {
            // Clear existing items
            cmbviolationid.Items.Clear();

            // Fetch violation IDs from the database
            string query = "SELECT vcode FROM tblviolations";  // Adjust the query if needed
            DataTable violationData = updatecase.GetData(query);

            // Populate ComboBox with violation IDs
            foreach (DataRow row in violationData.Rows)
            {
                cmbviolationid.Items.Add(row["vcode"].ToString());
            }

            // Optionally select the first item or leave it blank
            // cmbviolationid.SelectedIndex = -1; // Uncomment if you want to leave it unselected initially
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cmbstatus.SelectedIndex = -1;
            txtaction.Clear();
        }

        public event EventHandler CaseUpdated;

        private void btnsave_Click(object sender, EventArgs e)
        {
            validateForm();  // Validate form before saving

            if (errorCount == 0)  // Only proceed if there are no validation errors
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this case?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        // Update the case in the database using the provided status, action, school year, concern level, and disciplinary action
                        updatecase.executeSQL("UPDATE tblcases SET status = '" + cmbstatus.Text.ToUpper() + "', action = '" + txtaction.Text.ToUpper()
                            + "', schoolyear = '" + txtsy.Text + "', concernlevel = '" + cmbconcern.Text + "', disiplinaryaction = '" + txtdisiplinary.Text
                            + "' WHERE caseID = '" + caseID + "'");


                        // Check if the update was successful
                        if (updatecase.rowAffected > 0)
                        {
                            // Log the update action into the tbllogs table
                            updatecase.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) " +
                                "VALUES ('" + DateTime.Now.ToShortDateString() + "', '" + DateTime.Now.ToShortTimeString() + "', 'Update', 'Case Management', '" + caseID + "', '" + username + "')");

                            MessageBox.Show("Case Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Trigger the CaseUpdated event
                            CaseUpdated?.Invoke(this, EventArgs.Empty);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No changes were made to the case.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error updating case", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
