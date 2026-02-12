using NasaApod_App.Controllers;
using NasaApod_App.Exceptions;
using NasaApod_App.Models;
using NasaApod_App.Views;

namespace NasaApod_App
{
    public partial class MainForm : Form
    {
        private ApodController? _controller;
        private DetailForm? _detailForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!TryLoadConfig(out int startYear, out int endYear))
            {
                Close();
                return;
            }

            InitializeController();
            InitializeUI(startYear, endYear);
            CenterAboutPanel();
        }
        private bool TryLoadConfig(out int startYear, out int endYear)
        {
            startYear = 1995;
            endYear = DateTime.Now.Year;

            string? baseUrl = Program.Configuration["NasaApi:BaseUrl"];
            string? apiKey = Program.Configuration["NasaApi:ApiKey"];
            string? start = Program.Configuration["NasaApi:ApodStartYear"];

            if (!string.IsNullOrWhiteSpace(start))
                int.TryParse(start, out startYear);

            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show(
                    "Missing NASA API configuration",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }

            return true;
        }
        private void InitializeController()
        {
            var baseUrl = Program.Configuration["NasaApi:BaseUrl"];
            var apiKey = Program.Configuration["NasaApi:ApiKey"];

            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl!)
            };

            _controller = new ApodController(httpClient, apiKey!);
        }

        private void InitializeUI(int startYear, int endYear)
        {
            cboYear.Items.Clear();
            for (int year = endYear; year >= startYear; year--)
                cboYear.Items.Add(year);

            cboYear.SelectedItem = DateTime.Now.Year;
            cboYear.DropDownStyle = ComboBoxStyle.DropDownList;

            cboMonth.DisplayMember = "Text";
            cboMonth.ValueMember = "Value";
            cboMonth.DropDownStyle = ComboBoxStyle.DropDownList;

            cboYear.SelectedIndexChanged += cboYear_SelectedIndexChanged;

            LoadMonthsForSelectedYear();

            lb_rows.Text = "";
        }

        private void LoadMonthsForSelectedYear()
        {
            if (cboYear.SelectedItem == null) return;

            int selectedYear = (int)cboYear.SelectedItem;
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            cboMonth.Items.Clear();

            int maxMonth = selectedYear == currentYear
                ? currentMonth - 1
                : 12;

            // กัน edge case: เดือนปัจจุบัน = มกราคม
            if (maxMonth < 1)
                maxMonth = 1;

            for (int month = 1; month <= maxMonth; month++)
            {
                cboMonth.Items.Add(new MonthItem
                {
                    Value = month,
                    Text = new DateTime(2000, month, 1).ToString("MMMM")
                });
            }

            cboMonth.SelectedIndex = cboMonth.Items.Count - 1;
        }


        private async void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                btnLoad.Enabled = false;
                lvApod.Items.Clear();
                lvApod.Enabled = false;
                lb_rows.Text = "Loading data from NASA API...";

                if (cboYear.SelectedItem == null || !int.TryParse(cboYear.SelectedItem.ToString(), out int year))
                {
                    MessageBox.Show("Please select a year.");
                    return;
                }
                if (cboMonth.SelectedItem == null)
                {
                    MessageBox.Show("Please select a month.");
                    return;
                }

                dynamic monthItem = cboMonth.SelectedItem;
                if (monthItem == null)
                {
                    MessageBox.Show("Please select a month.");
                    return;
                }
                int month = monthItem.Value;

                if (_controller is null)
                {
                    MessageBox.Show("Controller not initialized.");
                    return;
                }

                var items = (await _controller.LoadMonthlyAsync(year, month))
                            .OrderByDescending(x => x.Date)
                            .ToList();

                lb_rows.Text = items.Any()
                    ? $"Loaded {items.Count} rows."
                    : "No data found.";

                lvApod.BeginUpdate();
                lvApod.Clear();
                lvApod.View = View.Details;
                lvApod.FullRowSelect = true;

                if (!items.Any())
                {
                    lvApod.EndUpdate();
                    return;
                }


                SetupListViewColumns(typeof(ApodItem));
                foreach (var item in items)
                {
                    var row = CreateListViewItem(item);
                    lvApod.Items.Add(row);
                }
                lvApod.EndUpdate();
            }
            catch (ApiKeyInvalidException)
            {
                MessageBox.Show(
                    "API Key ไม่สามารถใช้งานได้\nกรุณาตรวจสอบ API Key ใน config",
                    "Authentication Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show(
                    "ไม่สามารถเชื่อมต่อ NASA API ได้",
                    "Network Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnLoad.Enabled = true;
                lvApod.Enabled = true;
            }
        }
        private void SetupListViewColumns(Type modelType)
        {
            lvApod.Columns.Clear();

            var properties = modelType.GetProperties();

            foreach (var prop in properties)
            {
                lvApod.Columns.Add(prop.Name, 150);
            }
        }

        private ListViewItem CreateListViewItem(ApodItem item)
        {
            var properties = typeof(ApodItem).GetProperties();

            var values = properties
                .Select(p => p.GetValue(item)?.ToString() ?? string.Empty)
                .ToArray();

            var row = new ListViewItem(values);
            row.Tag = item;
            return row;
        }

        private void lvApod_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvApod.SelectedItems.Count == 0) return;
            if (lvApod.SelectedItems[0].Tag is not ApodItem item) return;

            if (_detailForm == null || _detailForm.IsDisposed)
            {
                _detailForm = new DetailForm();
                _detailForm.Show();
            }

            _detailForm.LoadData(item);
            _detailForm.Activate();
        }

        private void lvApod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvApod.SelectedItems.Count == 0) return;
            if (_detailForm == null || _detailForm.IsDisposed) return;

            var item = (ApodItem)lvApod.SelectedItems[0].Tag;
            _detailForm.LoadData(item);
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMonthsForSelectedYear();
        }
        private void CenterAboutPanel()
        {
            panelAbout.Left = (this.ClientSize.Width - panelAbout.Width) / 2;
            panelAbout.Top = (this.ClientSize.Height - panelAbout.Height) / 2;

            lblVersion.Text = $"Version: {Application.ProductVersion}";
            lb_About_developer.Text = "Kasidecha Kulkajornpanth";
            lb_About_title.Text = "NASA APOD Desktop Client";
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            CenterAboutPanel();
        }
    }
}
