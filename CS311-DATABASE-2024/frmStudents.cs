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
    public partial class frmStudents : Form
    {
        private string username;
        public frmStudents(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        Class1 students = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");

        private void frmStudents_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            btnclose.BackColor = Color.Transparent;
            try
            {
                DataTable dt = students.GetData("SELECT studentID, lastname, firstname, middlename, level, strandcourse, datecreated, createdby FROM tblstudents WHERE studentID <> '" + 
                    username
                    + "' ORDER BY studentID");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = students.GetData("SELECT studentID, lastname, firstname, middlename, level, strandcourse, datecreated, createdby FROM tblstudents WHERE studentID LIKE '%"
                + txtsearch.Text + "%' OR lastname LIKE '%" + txtsearch.Text + "%' OR strandcourse LIKE '%" + txtsearch.Text + "%' ORDER BY studentID");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmStudents_Load(sender, e);
        }
        private int row;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                row = (int)e.RowIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on datagrid cellclick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewstudent newStudentform = new frmNewstudent(username);
            newStudentform.StudentAdded += (s, args) => frmStudents_Load(this, EventArgs.Empty); // Refresh the list
            newStudentform.Show();
        }


        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this student?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    students.executeSQL("DELETE FROM tblstudents WHERE studentID = '" + selectedUser + "'");
                    if (students.rowAffected > 0)
                    {
                        students.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                    "','" + DateTime.Now.ToShortTimeString() + "','Delete', 'Students Management', '" + selectedUser + "', '" + username + "')");
                        MessageBox.Show("Student Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the student list
                        frmStudents_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string editstudentID = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editlastname = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editfirstname = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editmiddlename = dataGridView1.Rows[row].Cells[3].Value.ToString();
            string editlevel = dataGridView1.Rows[row].Cells[4].Value.ToString();
            string editstrandcourse = dataGridView1.Rows[row].Cells[5].Value.ToString();
            frmUpdatestudent updatestudentfrm = new frmUpdatestudent(username,editstudentID, editlastname, editfirstname, editmiddlename, editlevel, editstrandcourse);
            updatestudentfrm.StudentUpdated += (s, args) => frmStudents_Load(this, EventArgs.Empty); // Refresh the list
            updatestudentfrm.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
