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
    public partial class frmStrands : Form
    {
        private string username;
        Class1 strands = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        public frmStrands(string username)
        {
            InitializeComponent();
            this.username = username;   
        }

        private void frmStrands_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
            btnclose.BackColor = Color.Transparent;
            try
            {
                DataTable dt = strands.GetData("SELECT strandcode, description, datecreated, createdby FROM tblstrands WHERE strandcode <> '" + username + "' ORDER BY strandcode");
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
                DataTable dt = strands.GetData("SELECT strandcode, description, datecreated, createdby FROM tblstrands WHERE strandcode LIKE '%"
                + txtsearch.Text + "%' OR description LIKE '%" + txtsearch.Text + "%' ORDER BY strandcode");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on students load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmStrands_Load(sender, e);
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
            frmNewstrand newStrandform = new frmNewstrand(username);
            newStrandform.StrandAdded += (s, args) => frmStrands_Load(this, EventArgs.Empty); // Refresh the list
            newStrandform.Show();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this strand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    strands.executeSQL("DELETE FROM tblstrands WHERE strandcode = '" + selectedUser + "'");
                    if (strands.rowAffected > 0)
                    {
                        strands.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                    "','" + DateTime.Now.ToShortTimeString() + "','Delete', 'Strands Management', '" + selectedUser + "', '" + username + "')");
                        MessageBox.Show("Student Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh the courses list
                        frmStrands_Load(sender, e);
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
            string editstrandcode = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editdescription = dataGridView1.Rows[row].Cells[1].Value.ToString();
            frmUpdatestrand updatestrandform = new frmUpdatestrand(username, editstrandcode, editdescription);
            updatestrandform.StrandUpdated += (s, args) => frmStrands_Load(this, EventArgs.Empty); // Refresh the list
            updatestrandform.Show();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    