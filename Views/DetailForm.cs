using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NasaApod_App.Models;
using Microsoft.Web.WebView2.WinForms;

namespace NasaApod_App.Views
{
    public partial class DetailForm : Form
    {
        public DetailForm()
        {
            InitializeComponent();

            pictureBox1.LoadCompleted += PictureBox1_LoadCompleted;
        }

        public void LoadData(ApodItem item)
        {
            // 1️⃣ เคลียร์ข้อมูลเดิมทันที
            ClearPreviousData();

            // 2️⃣ ใส่ข้อมูล text (เร็ว)
            lblTitle.Text = item.Title;
            txtExplanation.Text = item.Explanation;

            // 3️⃣ ตรวจว่าเป็น image ไหม
            if (item.Media_Type == "image")
            {
                ShowLoading("Loading image...");
                LoadImage(item.Url);
            }
            else if (item.Media_Type == "video")
            {
                ShowLoading("Loading video...");
                LoadVideo(item.Url);
            }
            else
            {
                ShowError("Unsupported media type.");
            }
            
        }

        // ---------- Image ----------
        private void LoadImage(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                ShowError("Image URL not found.");
                return;
            }

            pictureBox1.Visible = true;

            try
            {
                pictureBox1.LoadAsync(url);
            }
            catch
            {
                ShowError("Unable to load image.");
            }
        }

        private void PictureBox1_LoadCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            lblLoading.Visible = false;

            if (e.Error != null || e.Cancelled)
            {
                ShowError("Failed to load image.");
            }
        }

        // ---------- Video ----------
        private async void LoadVideo(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                ShowError("Video URL not found.");
                return;
            }

            pictureBox1.Visible = false;
            webView21.Visible = true;

            await webView21.EnsureCoreWebView2Async();

            string finalUrl = url;

            if (url.Contains("youtube.com/watch"))
            {
                var uri = new Uri(url);
                var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
                var videoId = query["v"];

                if (!string.IsNullOrEmpty(videoId))
                {
                    finalUrl = $"https://www.youtube-nocookie.com/embed/{videoId}";
                }
            }
            else if (url.Contains("youtube.com/embed"))
            {
                finalUrl = url.Replace("youtube.com", "youtube-nocookie.com");
            }

            finalUrl += "?rel=0&modestbranding=1";

            webView21.CoreWebView2.Navigate(finalUrl);

            lblLoading.Visible = false;
        }


        // ---------- UI States ----------
        private void ClearPreviousData()
        {
            pictureBox1.Image = null;
            pictureBox1.Visible = false;

            webView21.Visible = false;
            if (webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate("about:blank");
            }

            lblLoading.Visible = false;
        }

        private void ShowLoading(string message)
        {
            lblLoading.Text = message;
            lblLoading.Visible = true;
        }

        private void ShowError(string message)
        {
            lblLoading.Text = message;
            lblLoading.Visible = true;
            pictureBox1.Visible = false;
            webView21.Visible = false;
        }

    }

}
