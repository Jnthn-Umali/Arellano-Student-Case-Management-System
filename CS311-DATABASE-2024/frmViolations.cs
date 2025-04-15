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
    public partial class frmViolations : Form
    {
        Class1 violations = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private string username;
        public frmViolations(string username)
        {
            InitializeComponent();
            this.username = username; 
        }

        private void frmViolations_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = violations.GetData("SELECT vcode, description, vtype, status, createdby, datecreated FROM tblviolations WHERE vcode <> '" + username
                    + "' ORDER BY vcode");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on accounts load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = violations.GetData("SELECT vcode, description, vtype, status, datecreated, createdby " +"FROM tblviolations WHERE vcode LIKE '%" 
                    + txtsearch.Text + "%' OR vtype LIKE '%" + txtsearch.Text + "%' OR description LIKE '%" + txtsearch.Text + "%' ORDER BY vcode");

                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmViolations_Load(sender, e);
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

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this violation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    violations.executeSQL("DELETE FROM tblviolations WHERE vcode = '" + selectedUser + "'");
                    if (violations.rowAffected > 0)
                    {
                        violations.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                    "','" + DateTime.Now.ToShortTimeString() + "','Delete', 'Violations Management', '" + selectedUser + "', '" + username + "')");
                        MessageBox.Show("Violation Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error on Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewviolation newViolationform = new frmNewviolation(username);
            newViolationform.Show();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string editvcode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string editvtype = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editstatus = dataGridView1.Rows[row].Cells[3].Value.ToString();
            frmUpdateviolation updateviolationtfrm = new frmUpdateviolation(username, editvcode, editdescription, editvtype,editstatus);
            updateviolationtfrm.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
