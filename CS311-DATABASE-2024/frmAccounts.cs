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
    public partial class frmAccounts : Form
    {
        private string username;
        public frmAccounts(string username)
        {
            InitializeComponent();
            this.username = username;
        }
        Class1 accounts = new Class1("127.0.0.1", "cs311c2024", "jonathan", "umali");
        private void frmAccounts_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = accounts.GetData("SELECT username, password, usertype, status, createdby, datecreated FROM tblaccounts WHERE username <> '" + username
                    + "' ORDER BY datecreated DESC"); // Changed to order by datecreated DESC
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
                DataTable dt = accounts.GetData("SELECT username, password, usertype, status, createdby, datecreated FROM tblaccounts WHERE username <> '" + username
                    + "' AND (username LIKE '%" + txtsearch.Text + "%') ORDER BY datecreated DESC"); // Changed to order by datecreated DESC
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on accounts load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            frmAccounts_Load(sender, e);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            frmNewaccount newAccountForm = new frmNewaccount(username);
            newAccountForm.AccountAdded += (s, ev) => frmAccounts_Load(sender, e);
            newAccountForm.Show();
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
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string selectedUser = dataGridView1.Rows[row].Cells[0].Value.ToString();
                try
                {
                    accounts.executeSQL("DELETE FROM tblaccounts WHERE username = '" + selectedUser + "'");
                    if (accounts.rowAffected > 0)
                    {
                        accounts.executeSQL("INSERT INTO tbllogs (datelog, timelog, action, module, ID, performedby) VALUES ('" + DateTime.Now.ToShortDateString() +
                                    "','" + DateTime.Now.ToShortTimeString() + "','Delete', 'Accounts Management', '" + selectedUser + "', '" + username + "')");
                        MessageBox.Show("Account Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresh the account list
                        frmAccounts_Load(sender, e);
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
            string editusername = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string editpassword = dataGridView1.Rows[row].Cells[1].Value.ToString();
            string edittype = dataGridView1.Rows[row].Cells[2].Value.ToString();
            string editstatus = dataGridView1.Rows[row].Cells[3].Value.ToString();

            frmUpdateaccount updateAccountForm = new frmUpdateaccount(username, editusername, editpassword, edittype, editstatus);
            updateAccountForm.AccountUpdated += (s, ev) => frmAccounts_Load(sender, e);
            updateAccountForm.Show();
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
