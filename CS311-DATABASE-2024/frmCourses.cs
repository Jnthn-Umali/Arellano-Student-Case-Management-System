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
    public partial class frmCourses : Form
    {
        private string username;
        public frmCourses(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        Class1 courses = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");

        private void frmCourses_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            btnclose.BackColor = Color.Transparent;
            try
            {
                DataTable dt = courses.GetData("SELECT coursecode, description, datecreated, createdby FROM tblcourses WHERE coursecode <> '" + username + "' ORDER BY coursecode");
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
                DataTable dt = courses.GetData("SELECT coursecode, description, datecreated, createdby FROM tblcourses WHERE coursecode LIKE '%"
                + txtsearch.Text + "%' OR description LIKE '%" + txtsearch.Text  + "%' ORDER BY coursecode");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmCourses_Load(sender, e);
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
            frmNewcourse newCourseform = new frmNewcourse(username);
            newCourseform.CourseAdded += (s, args) => frmCourses_Load(this, EventArgs.Empty); // Refresh the list
            newCourseform.Show();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this course?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    courses.executeSQL("DELETE FROM tblcourses WHERE coursecode = '" + selectedUser + "'");
                    if (courses.rowAffected > 0)
                    {
                        courses.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                    "','" + DateTime.Now.ToShortTimeString() + "','Delete', 'Courses Management', '" + selectedUser + "', '" + username + "')");
                        MessageBox.Show("Student Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh the courses list
                        frmCourses_Load(sender, e);
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
            string editcoursecode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            frmUpdatecourse updatecourseform = new frmUpdatecourse(username, editcoursecode, editdescription);
            updatecourseform.CourseUpdated += (s, args) => frmCourses_Load(this, EventArgs.Empty); // Refresh the list
            updatecourseform.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
