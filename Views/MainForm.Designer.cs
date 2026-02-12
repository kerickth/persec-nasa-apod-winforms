namespace NasaApod_App
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnLoad = new Button();
            cboYear = new ComboBox();
            cboMonth = new ComboBox();
            lvApod = new ListView();
            colDate = new ColumnHeader();
            colTitle = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label3 = new Label();
            statusStrip1 = new StatusStrip();
            lb_rows = new ToolStripStatusLabel();
            tabPage2 = new TabPage();
            panelAbout = new Panel();
            textBox1 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            lb_About_developer = new Label();
            lb_About_title = new Label();
            lblVersion = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            statusStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            panelAbout.SuspendLayout();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(301, 88);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(94, 29);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Send API";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // cboYear
            // 
            cboYear.Font = new Font("Segoe UI", 10.2F);
            cboYear.FormattingEnabled = true;
            cboYear.Location = new Point(126, 46);
            cboYear.Name = "cboYear";
            cboYear.Size = new Size(151, 31);
            cboYear.TabIndex = 1;
            cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;
            // 
            // cboMonth
            // 
            cboMonth.Font = new Font("Segoe UI", 10.2F);
            cboMonth.FormattingEnabled = true;
            cboMonth.Location = new Point(126, 87);
            cboMonth.Name = "cboMonth";
            cboMonth.Size = new Size(151, 31);
            cboMonth.TabIndex = 2;
            // 
            // lvApod
            // 
            lvApod.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvApod.Columns.AddRange(new ColumnHeader[] { colDate, colTitle });
            lvApod.Location = new Point(18, 136);
            lvApod.Name = "lvApod";
            lvApod.Size = new Size(640, 181);
            lvApod.TabIndex = 3;
            lvApod.UseCompatibleStateImageBehavior = false;
            lvApod.View = View.List;
            lvApod.SelectedIndexChanged += lvApod_SelectedIndexChanged;
            lvApod.MouseDoubleClick += lvApod_MouseDoubleClick;
            // 
            // colDate
            // 
            colDate.Text = "Date";
            // 
            // colTitle
            // 
            colTitle.Text = "Title";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label1.Location = new Point(48, 54);
            label1.Name = "label1";
            label1.Size = new Size(49, 23);
            label1.TabIndex = 4;
            label1.Text = "Year:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            label2.Location = new Point(48, 95);
            label2.Name = "label2";
            label2.Size = new Size(68, 23);
            label2.TabIndex = 5;
            label2.Text = "Month:";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(686, 399);
            tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(statusStrip1);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(lvApod);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(btnLoad);
            tabPage1.Controls.Add(cboMonth);
            tabPage1.Controls.Add(cboYear);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(678, 366);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 5);
            label3.Name = "label3";
            label3.Size = new Size(259, 38);
            label3.TabIndex = 7;
            label3.Text = "Photo of The Days";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lb_rows });
            statusStrip1.Location = new Point(3, 337);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(672, 26);
            statusStrip1.TabIndex = 6;
            statusStrip1.Text = "statusStrip1";
            // 
            // lb_rows
            // 
            lb_rows.Name = "lb_rows";
            lb_rows.Size = new Size(60, 20);
            lb_rows.Text = "00 rows";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panelAbout);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(678, 366);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "About";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelAbout
            // 
            panelAbout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panelAbout.AutoScroll = true;
            panelAbout.Controls.Add(textBox1);
            panelAbout.Controls.Add(label7);
            panelAbout.Controls.Add(label6);
            panelAbout.Controls.Add(label5);
            panelAbout.Controls.Add(label4);
            panelAbout.Controls.Add(lb_About_developer);
            panelAbout.Controls.Add(lb_About_title);
            panelAbout.Controls.Add(lblVersion);
            panelAbout.Location = new Point(6, 6);
            panelAbout.Name = "panelAbout";
            panelAbout.Size = new Size(642, 354);
            panelAbout.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ControlLightLight;
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(59, 157);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(509, 76);
            textBox1.TabIndex = 7;
            textBox1.Text = "This application demonstrates how to consume\r\nNASA's APOD API using a WinForms architecturee\r\nwith separation of concerns (Controller / View / Model).";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(59, 134);
            label7.Name = "label7";
            label7.Size = new Size(89, 20);
            label7.TabIndex = 6;
            label7.Text = "Description";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(65, 269);
            label6.Name = "label6";
            label6.Size = new Size(202, 80);
            label6.TabIndex = 5;
            label6.Text = "- .NET 8 WinForms\r\n- HttpClient\r\n- NASA APOD API\r\n- Configuration-base settings";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(59, 248);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 4;
            label5.Text = "Technologies";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(59, 98);
            label4.Name = "label4";
            label4.Size = new Size(85, 20);
            label4.TabIndex = 3;
            label4.Text = "Developer:";
            // 
            // lb_About_developer
            // 
            lb_About_developer.AutoSize = true;
            lb_About_developer.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lb_About_developer.Location = new Point(150, 96);
            lb_About_developer.Name = "lb_About_developer";
            lb_About_developer.Size = new Size(207, 23);
            lb_About_developer.TabIndex = 2;
            lb_About_developer.Text = "Kasidecha Kulkajornpanth";
            // 
            // lb_About_title
            // 
            lb_About_title.AutoSize = true;
            lb_About_title.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_About_title.Location = new Point(150, 12);
            lb_About_title.Name = "lb_About_title";
            lb_About_title.Size = new Size(298, 41);
            lb_About_title.TabIndex = 1;
            lb_About_title.Text = "XXXXXXXXXXXXXX";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblVersion.Location = new Point(247, 53);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(110, 23);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Version: 0.0.0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 423);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "API NASA Apod API";
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panelAbout.ResumeLayout(false);
            panelAbout.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private ComboBox cboYear;
        private ComboBox cboMonth;
        private ListView lvApod;
        private Label label1;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label3;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lb_rows;
        private TabPage tabPage2;
        private ColumnHeader colDate;
        private ColumnHeader colTitle;
        private Panel panelAbout;
        private Label lblVersion;
        private TextBox textBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lb_About_developer;
        private Label lb_About_title;
    }
}
