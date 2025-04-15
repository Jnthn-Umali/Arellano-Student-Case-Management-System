    using System;
    using System.Data;
    using System.Windows.Forms;
    using ticket_management;

namespace CS311_DATABASE_2024
{
    public partial class frmCases : Form
    {
        Class1 cases = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private string username;

        public frmCases(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        private void LoadStudentInformation(string studentNumber)
        {
            // Fetch the student information
            DataTable studentData = GetStudentData(studentNumber);
            if (studentData.Rows.Count > 0)
            {
                // Populate the student information in the form's textboxes
                DataRow row = studentData.Rows[0];
                txtfirstname.Text = row["firstname"].ToString();
                txtlastname.Text = row["lastname"].ToString();
                txtmiddlename.Text = row["middlename"].ToString();
                txtlevel.Text = row["level"].ToString();
                txtstrandcourse.Text = row["strandcourse"].ToString();
            }
        }
        private void LoadStudentCases(string studentNumber)
        {
            if (!string.IsNullOrEmpty(studentNumber))
            {
                LoadStudentInformation(studentNumber);
                string query = "SELECT caseID, vcode, status, vcount, action,  schoolyear , concernlevel, disiplinaryaction, createdby, " +
                    "datecreated FROM tblcases WHERE studentID = '" + studentNumber + "'";
                DataTable caseData = cases.GetData(query);

                DataTable resultData = new DataTable();
                resultData.Columns.Add("caseID");
                resultData.Columns.Add("vcode");
                resultData.Columns.Add("description");
                resultData.Columns.Add("vtype");
                resultData.Columns.Add("vcount");
                resultData.Columns.Add("status");
                resultData.Columns.Add("action");
                resultData.Columns.Add("schoolyear");
                resultData.Columns.Add("concernlevel");
                resultData.Columns.Add("disiplinaryaction");
                resultData.Columns.Add("date");

                foreach (DataRow row in caseData.Rows)
                {
                    string vcode = row["vcode"].ToString();
                    string violationQuery = "SELECT description, vtype FROM tblviolations WHERE vcode = '" + vcode + "'";
                    DataTable violationData = cases.GetData(violationQuery);

                    string description = violationData.Rows.Count > 0 ? violationData.Rows[0]["description"].ToString() : string.Empty;
                    string vtype = violationData.Rows.Count > 0 ? violationData.Rows[0]["vtype"].ToString() : string.Empty;

                    resultData.Rows.Add(row["caseID"], vcode, description, vtype, row["vcount"], row["status"], row["action"],
                        row["schoolyear"], row["concernlevel"], row["disiplinaryaction"], row["datecreated"]);
                }

                dataGridView1.DataSource = resultData;
            }
        }


        private void ClearStudentInformation()
        {
            txtfirstname.Clear();
            txtlastname.Clear();
            txtmiddlename.Clear();
            txtlevel.Clear();
            txtstrandcourse.Clear();
            txtsearch.Clear();
            dataGridView1.DataSource = null;  // Clear the DataGridView
        }

        private DataTable GetStudentData(string studentNumber)
        {
            string query = "SELECT lastname, firstname, middlename, level, strandcourse FROM tblstudents WHERE studentID = '" + studentNumber + "'";
            return cases.GetData(query);
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string studentNumber = txtsearch.Text.Trim();

            if (!string.IsNullOrEmpty(studentNumber))
            {
                // Clear the DataGridView before loading data for the searched student
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();

              LoadStudentCases(studentNumber);
            }
            else
            {
                MessageBox.Show("Please enter a student number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmCases_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            // Clear the student information textboxes
            ClearStudentInformation();

            // Optionally, you can also clear the search textbox
            txtsearch.Clear();
        }

        private int row;
        private void btnadd_Click(object sender, EventArgs e)
        {
            // Ensure that a student is searched and student information is populated
            if (!string.IsNullOrEmpty(txtsearch.Text) &&
                !string.IsNullOrEmpty(txtlastname.Text) &&
                !string.IsNullOrEmpty(txtfirstname.Text) &&
                dataGridView1.Rows.Count > 0) // Check if there are rows in the DataGridView
            {
                string studentID = txtsearch.Text.Trim();
                string lastname = txtlastname.Text.Trim();
                string firstname = txtfirstname.Text.Trim();
                string middlename = txtmiddlename.Text.Trim();
                string level = txtlevel.Text.Trim();
                string strandcourse = txtstrandcourse.Text.Trim();

                // Pass DataGridView reference to frmNewcase
                frmNewcase newCaseForm = new frmNewcase(username, studentID, lastname, firstname, middlename, level, strandcourse, dataGridView1);
                newCaseForm.CaseAdded += (s, args) => LoadStudentCases(txtsearch.Text); // Refresh the list
                newCaseForm.Show();
            }
            else
            {
                MessageBox.Show("Please search for a student and ensure the student information is populated before adding a case.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Check if the clicked cell is a valid data cell (not the header)
                if (e.RowIndex >= 0)
                {
                    row = e.RowIndex; // Store the row index of the clicked cell
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while selecting the student: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Ensure that a student is searched first
            if (!string.IsNullOrEmpty(txtsearch.Text))
            {
                // Ensure that a student is searched first
                if (!string.IsNullOrEmpty(txtsearch.Text))
                {
                    // Check if the student information fields are populated
                    if (!string.IsNullOrEmpty(txtlastname.Text) && !string.IsNullOrEmpty(txtfirstname.Text))
                    {
                        // Check if there are any rows in the DataGridView
                        if (dataGridView1.CurrentRow != null) // Check if a case is selected
                        {
                            string caseID = dataGridView1.CurrentRow.Cells["caseID"].Value.ToString();
                            string studentID = txtsearch.Text.Trim();
                            string lastname = txtlastname.Text.Trim();
                            string firstname = txtfirstname.Text.Trim();
                            string middlename = txtmiddlename.Text.Trim();
                            string level = txtlevel.Text.Trim();
                            string strandcourse = txtstrandcourse.Text.Trim();
                            string vcode = dataGridView1.CurrentRow.Cells["vcode"].Value.ToString();
                            string description = dataGridView1.CurrentRow.Cells["description"].Value.ToString();
                            string vcount = dataGridView1.CurrentRow.Cells["vcount"].Value.ToString();
                            string status = dataGridView1.CurrentRow.Cells["status"].Value.ToString();
                            string action = dataGridView1.CurrentRow.Cells["action"].Value.ToString();
                            string schoolyear = dataGridView1.CurrentRow.Cells["schoolyear"].Value.ToString();
                            string concernlevel = dataGridView1.CurrentRow.Cells["concernlevel"].Value.ToString();
                            string disiplinaryaction = dataGridView1.CurrentRow.Cells["disiplinaryaction"].Value.ToString();

                            // Pass DataGridView reference to frmUpdatecase
                            frmUpdatecase updateCaseForm = new frmUpdatecase(username, caseID, studentID, lastname, firstname, 
                                middlename, level, strandcourse, vcode, description, vcount, status, action, schoolyear, concernlevel,disiplinaryaction);
                            updateCaseForm.CaseUpdated += (s, args) => LoadStudentCases(txtsearch.Text);  // Refresh the list
                            updateCaseForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("No cases available for this student.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please ensure the student information is populated before updating a case.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please search for a student before updating a case.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}