using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS311_DATABASE_2024
{
    public partial class frmMain : Form
    {
        private string username, usertype;

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmlogin Loginform = new frmlogin();
            Loginform.Show();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccounts accountsform = new frmAccounts(username);
            accountsform.MdiParent = this;
            accountsform.Show();
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudents studentsform = new frmStudents(username);
            studentsform.MdiParent = this;
            studentsform.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Username: " + username;
            toolStripStatusLabel2.Text = "User type: " + usertype;
            if (usertype == "ADMINISTRATOR")
            {
                accountsToolStripMenuItem.Visible = true;
                eventsToolStripMenuItem.Visible = true;
                ticketsToolStripMenuItem.Visible = true;
            }
            else if (usertype == "BRANCH ADMINISTRATOR")
            {
                accountsToolStripMenuItem.Visible = false;
                eventsToolStripMenuItem.Visible = true;
                ticketsToolStripMenuItem.Visible = true;
            }
            else
            {
                accountsToolStripMenuItem.Visible = false;
                eventsToolStripMenuItem.Visible = false;
                ticketsToolStripMenuItem.Visible = true;
            }
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCourses coursesform = new frmCourses(username);
            coursesform.MdiParent = this;
            coursesform.Show();
        }

        private void strandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStrands strandsform = new frmStrands(username);
            strandsform.MdiParent = this;
            strandsform.Show();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmViolations violationsform = new frmViolations(username);
            violationsform.MdiParent = this;
            violationsform.Show();
        }

        private void casesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCases casesform  = new frmCases(username);
            casesform.MdiParent = this;
            casesform.Show();
        }

        public frmMain(string username, string usertype)
        {
            InitializeComponent();
            this.username = username;
            this.usertype = usertype;
        }
    }
}
