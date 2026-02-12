using Microsoft.Web.WebView2.WinForms;

namespace NasaApod_App.Views
{
    partial class DetailForm
    {
        private Label lblTitle;
        // เพิ่ม field
        private Label lblLoading;
        private PictureBox pictureBox1;
        private TextBox txtExplanation;
        private WebView2 webView21;

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pictureBox1 = new PictureBox();
            txtExplanation = new TextBox();
            lblLoading = new Label();
            webView21 = new WebView2();

            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(560, 30);
            lblTitle.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(12, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(569, 295);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblLoading
            // 
            lblLoading.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(12, 170); // ปรับตำแหน่งให้อยู่กลาง pictureBox1
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(569, 23);
            lblLoading.TabIndex = 3;
            lblLoading.Text = "Loading image...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            lblLoading.Visible = false;
            // 
            // txtExplanation
            // 
            txtExplanation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtExplanation.Location = new Point(12, 352);
            txtExplanation.Multiline = true;
            txtExplanation.Name = "txtExplanation";
            txtExplanation.ReadOnly = true;
            txtExplanation.ScrollBars = ScrollBars.Vertical;
            txtExplanation.Size = new Size(569, 118);
            txtExplanation.TabIndex = 2;
            //
            // webView21
            //
            webView21.Location = new Point(12, 45);
            webView21.Name = "webView21";
            webView21.Size = new Size(569, 295);
            webView21.TabIndex = 4;
            webView21.Visible = false;
            // 
            // DetailForm
            // 
            ClientSize = new Size(599, 490);
            Controls.Add(lblTitle);
            Controls.Add(pictureBox1);
            Controls.Add(lblLoading);
            Controls.Add(webView21);
            Controls.Add(txtExplanation);
            Name = "DetailForm";
            Text = "APOD Detail";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
            
        }
    }
}