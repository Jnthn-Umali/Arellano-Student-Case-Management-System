namespace CS311_DATABASE_2024
{
    partial class frmUpdatecase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.txtaction = new System.Windows.Forms.TextBox();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbviolationcount = new System.Windows.Forms.ComboBox();
            this.txtviolationdescription = new System.Windows.Forms.TextBox();
            this.cmbviolationid = new System.Windows.Forms.ComboBox();
            this.txtstrandcourse = new System.Windows.Forms.TextBox();
            this.txtlevel = new System.Windows.Forms.TextBox();
            this.txtmiddlename = new System.Windows.Forms.TextBox();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.txtstudentid = new System.Windows.Forms.TextBox();
            this.txtcaseid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtdisiplinary = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbconcern = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtsy = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 294);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 332);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Action:";
            // 
            // cmbstatus
            // 
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Items.AddRange(new object[] {
            "ONGOING",
            "RESOLVED"});
            this.cmbstatus.Location = new System.Drawing.Point(326, 291);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(153, 21);
            this.cmbstatus.TabIndex = 2;
            this.cmbstatus.SelectedIndexChanged += new System.EventHandler(this.cmbstatus_SelectedIndexChanged);
            // 
            // txtaction
            // 
            this.txtaction.Location = new System.Drawing.Point(326, 329);
            this.txtaction.Multiline = true;
            this.txtaction.Name = "txtaction";
            this.txtaction.Size = new System.Drawing.Size(153, 57);
            this.txtaction.TabIndex = 3;
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.Lime;
            this.btnclear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnclear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclear.Location = new System.Drawing.Point(358, 433);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(94, 44);
            this.btnclear.TabIndex = 62;
            this.btnclear.Text = "&Clear";
            this.btnclear.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Aqua;
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(129, 432);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(94, 44);
            this.btnsave.TabIndex = 61;
            this.btnsave.Text = "&Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Lime;
            this.pictureBox2.BackgroundImage = global::CS311_DATABASE_2024.Properties.Resources.clear1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(397, 440);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 30);
            this.pictureBox2.TabIndex = 64;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Aqua;
            this.pictureBox1.BackgroundImage = global::CS311_DATABASE_2024.Properties.Resources.save2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(166, 440);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 30);
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cmbviolationcount
            // 
            this.cmbviolationcount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbviolationcount.Enabled = false;
            this.cmbviolationcount.FormattingEnabled = true;
            this.cmbviolationcount.Items.AddRange(new object[] {
            "FIRST OFFENSE",
            "SECOND OFFENSE",
            "REPEAT OFFENSE"});
            this.cmbviolationcount.Location = new System.Drawing.Point(123, 387);
            this.cmbviolationcount.Name = "cmbviolationcount";
            this.cmbviolationcount.Size = new System.Drawing.Size(127, 21);
            this.cmbviolationcount.TabIndex = 84;
            // 
            // txtviolationdescription
            // 
            this.txtviolationdescription.Enabled = false;
            this.txtviolationdescription.Location = new System.Drawing.Point(123, 356);
            this.txtviolationdescription.Name = "txtviolationdescription";
            this.txtviolationdescription.Size = new System.Drawing.Size(127, 20);
            this.txtviolationdescription.TabIndex = 83;
            // 
            // cmbviolationid
            // 
            this.cmbviolationid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmbviolationid.Enabled = false;
            this.cmbviolationid.FormattingEnabled = true;
            this.cmbviolationid.Location = new System.Drawing.Point(123, 317);
            this.cmbviolationid.Name = "cmbviolationid";
            this.cmbviolationid.Size = new System.Drawing.Size(127, 21);
            this.cmbviolationid.TabIndex = 82;
            // 
            // txtstrandcourse
            // 
            this.txtstrandcourse.Enabled = false;
            this.txtstrandcourse.Location = new System.Drawing.Point(123, 281);
            this.txtstrandcourse.Name = "txtstrandcourse";
            this.txtstrandcourse.Size = new System.Drawing.Size(127, 20);
            this.txtstrandcourse.TabIndex = 81;
            // 
            // txtlevel
            // 
            this.txtlevel.Enabled = false;
            this.txtlevel.Location = new System.Drawing.Point(123, 239);
            this.txtlevel.Name = "txtlevel";
            this.txtlevel.Size = new System.Drawing.Size(127, 20);
            this.txtlevel.TabIndex = 80;
            // 
            // txtmiddlename
            // 
            this.txtmiddlename.Enabled = false;
            this.txtmiddlename.Location = new System.Drawing.Point(123, 200);
            this.txtmiddlename.Name = "txtmiddlename";
            this.txtmiddlename.Size = new System.Drawing.Size(127, 20);
            this.txtmiddlename.TabIndex = 79;
            // 
            // txtfirstname
            // 
            this.txtfirstname.Enabled = false;
            this.txtfirstname.Location = new System.Drawing.Point(123, 161);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(127, 20);
            this.txtfirstname.TabIndex = 78;
            // 
            // txtlastname
            // 
            this.txtlastname.Enabled = false;
            this.txtlastname.Location = new System.Drawing.Point(123, 113);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(127, 20);
            this.txtlastname.TabIndex = 77;
            // 
            // txtstudentid
            // 
            this.txtstudentid.Enabled = false;
            this.txtstudentid.Location = new System.Drawing.Point(123, 73);
            this.txtstudentid.Name = "txtstudentid";
            this.txtstudentid.Size = new System.Drawing.Size(127, 20);
            this.txtstudentid.TabIndex = 76;
            // 
            // txtcaseid
            // 
            this.txtcaseid.Enabled = false;
            this.txtcaseid.Location = new System.Drawing.Point(123, 30);
            this.txtcaseid.Name = "txtcaseid";
            this.txtcaseid.Size = new System.Drawing.Size(127, 20);
            this.txtcaseid.TabIndex = 75;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Violation Count:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 73;
            this.label9.Text = "Violation Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(53, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 72;
            this.label8.Text = "Violation ID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 284);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 71;
            this.label7.Text = "Strand/Course:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(81, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "Middle name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "First name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Last name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 66;
            this.label11.Text = "Student ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(69, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 65;
            this.label12.Text = "Case ID:";
            // 
            // txtdisiplinary
            // 
            this.txtdisiplinary.Location = new System.Drawing.Point(286, 138);
            this.txtdisiplinary.Multiline = true;
            this.txtdisiplinary.Name = "txtdisiplinary";
            this.txtdisiplinary.Size = new System.Drawing.Size(209, 136);
            this.txtdisiplinary.TabIndex = 90;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(283, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(157, 13);
            this.label13.TabIndex = 89;
            this.label13.Text = "Procedure for Disiplinary Action:";
            // 
            // cmbconcern
            // 
            this.cmbconcern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbconcern.FormattingEnabled = true;
            this.cmbconcern.Items.AddRange(new object[] {
            "Prespect of Discipline",
            "Branch OSA",
            "Dean of Student Affairs",
            "Council of Discipline"});
            this.cmbconcern.Location = new System.Drawing.Point(368, 74);
            this.cmbconcern.Name = "cmbconcern";
            this.cmbconcern.Size = new System.Drawing.Size(127, 21);
            this.cmbconcern.TabIndex = 88;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 87;
            this.label14.Text = "Concern Level:";
            // 
            // txtsy
            // 
            this.txtsy.Location = new System.Drawing.Point(368, 39);
            this.txtsy.Name = "txtsy";
            this.txtsy.Size = new System.Drawing.Size(127, 20);
            this.txtsy.TabIndex = 86;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(296, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "School year:";
            // 
            // frmUpdatecase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 504);
            this.Controls.Add(this.txtdisiplinary);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbconcern);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtsy);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbviolationcount);
            this.Controls.Add(this.txtviolationdescription);
            this.Controls.Add(this.cmbviolationid);
            this.Controls.Add(this.txtstrandcourse);
            this.Controls.Add(this.txtlevel);
            this.Controls.Add(this.txtmiddlename);
            this.Controls.Add(this.txtfirstname);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.txtstudentid);
            this.Controls.Add(this.txtcaseid);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtaction);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnsave);
            this.Name = "frmUpdatecase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUpdatecase";
            this.Load += new System.EventHandler(this.frmUpdatecase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.TextBox txtaction;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmbviolationcount;
        private System.Windows.Forms.TextBox txtviolationdescription;
        private System.Windows.Forms.ComboBox cmbviolationid;
        private System.Windows.Forms.TextBox txtstrandcourse;
        private System.Windows.Forms.TextBox txtlevel;
        private System.Windows.Forms.TextBox txtmiddlename;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.TextBox txtstudentid;
        private System.Windows.Forms.TextBox txtcaseid;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtdisiplinary;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbconcern;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtsy;
        private System.Windows.Forms.Label label15;
    }
}