using SeproxyTools;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace AdflySe
{
    public partial class ProgramForm : Form
    {
        IWebDriver Driver;
        Seproxy seproxy = new Seproxy();
        bool serverConnect = false;
        bool adflyConnect = false;
        public ProgramForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramForm));
            this.inputServerAddress = new System.Windows.Forms.TextBox();
            this.btnServerConnect = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnServerDisconnect = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.inputAdflyAddress = new System.Windows.Forms.TextBox();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.textStatusServer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.SuspendLayout();
            // 
            // inputServerAddress
            // 
            this.inputServerAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.inputServerAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputServerAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputServerAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.inputServerAddress.Location = new System.Drawing.Point(203, 251);
            this.inputServerAddress.Multiline = true;
            this.inputServerAddress.Name = "inputServerAddress";
            this.inputServerAddress.PlaceholderText = "http://120.12.11:8080";
            this.inputServerAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inputServerAddress.Size = new System.Drawing.Size(366, 33);
            this.inputServerAddress.TabIndex = 1;
            // 
            // btnServerConnect
            // 
            this.btnServerConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(109)))), ((int)(((byte)(224)))));
            this.btnServerConnect.FlatAppearance.BorderSize = 0;
            this.btnServerConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerConnect.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServerConnect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnServerConnect.Location = new System.Drawing.Point(203, 300);
            this.btnServerConnect.Name = "btnServerConnect";
            this.btnServerConnect.Size = new System.Drawing.Size(148, 33);
            this.btnServerConnect.TabIndex = 2;
            this.btnServerConnect.TabStop = false;
            this.btnServerConnect.Text = "Connect";
            this.btnServerConnect.UseVisualStyleBackColor = false;
            this.btnServerConnect.Click += new System.EventHandler(this.ConnectServerBtnClickHandler);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnStop.Location = new System.Drawing.Point(421, 419);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(148, 31);
            this.btnStop.TabIndex = 3;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClickHandler);
            // 
            // btnServerDisconnect
            // 
            this.btnServerDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.btnServerDisconnect.Enabled = false;
            this.btnServerDisconnect.FlatAppearance.BorderSize = 0;
            this.btnServerDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerDisconnect.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServerDisconnect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.btnServerDisconnect.Location = new System.Drawing.Point(421, 300);
            this.btnServerDisconnect.Name = "btnServerDisconnect";
            this.btnServerDisconnect.Size = new System.Drawing.Size(148, 33);
            this.btnServerDisconnect.TabIndex = 4;
            this.btnServerDisconnect.TabStop = false;
            this.btnServerDisconnect.Text = "Disconnect";
            this.btnServerDisconnect.UseVisualStyleBackColor = false;
            this.btnServerDisconnect.UseWaitCursor = true;
            this.btnServerDisconnect.Click += new System.EventHandler(this.DisconnectServerBtnClickHandler);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(109)))), ((int)(((byte)(224)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStart.Location = new System.Drawing.Point(203, 418);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(148, 32);
            this.btnStart.TabIndex = 5;
            this.btnStart.TabStop = false;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.BtnStartClickHandler);
            // 
            // inputAdflyAddress
            // 
            this.inputAdflyAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.inputAdflyAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputAdflyAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputAdflyAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.inputAdflyAddress.Location = new System.Drawing.Point(203, 370);
            this.inputAdflyAddress.Multiline = true;
            this.inputAdflyAddress.Name = "inputAdflyAddress";
            this.inputAdflyAddress.PlaceholderText = "http://ad.fly/link";
            this.inputAdflyAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inputAdflyAddress.Size = new System.Drawing.Size(366, 33);
            this.inputAdflyAddress.TabIndex = 1;
            // 
            // logoPic
            // 
            this.logoPic.BackColor = System.Drawing.Color.Transparent;
            this.logoPic.Image = ((System.Drawing.Image)(resources.GetObject("logoPic.Image")));
            this.logoPic.Location = new System.Drawing.Point(251, 47);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(248, 143);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 6;
            this.logoPic.TabStop = false;
            // 
            // textStatusServer
            // 
            this.textStatusServer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textStatusServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textStatusServer.Location = new System.Drawing.Point(0, 212);
            this.textStatusServer.Name = "textStatusServer";
            this.textStatusServer.Size = new System.Drawing.Size(786, 18);
            this.textStatusServer.TabIndex = 7;
            this.textStatusServer.Text = "Server status: not connected";
            this.textStatusServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgramForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(786, 509);
            this.Controls.Add(this.textStatusServer);
            this.Controls.Add(this.logoPic);
            this.Controls.Add(this.inputAdflyAddress);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnServerDisconnect);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnServerConnect);
            this.Controls.Add(this.inputServerAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ProgramForm";
            this.Load += new System.EventHandler(this.ProgramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void ConnectServerBtnClickHandler(object sender, System.EventArgs e)
        {
            string seAdressInInput = inputServerAddress.Text;

            if (serverConnect == false && seAdressInInput != "")
            {
                if (seproxy.SetServerAddress(seAdressInInput))
                {
                    seproxy.Connect();
                    serverConnect = true;
                    DisableButton(btnServerConnect);
                    EnableButton(btnServerDisconnect);

                    SetTextStatusServer("connected", Regex.Replace(seAdressInInput, "http://", String.Empty));
                }
                else
                {
                    ShowError("Unable to connect to server");
                }
            } 
        }

        private void DisconnectServerBtnClickHandler(object sender, System.EventArgs e)
        {
            if (serverConnect == true)
            {
                seproxy.Disconnect();
                SetTextStatusServer("disconected");
                serverConnect = false;
                DisableButton(btnServerDisconnect);
                EnableButton(btnServerConnect);

                adflyConnect = false;
                DisableButton(btnStop);
                EnableButton(btnStart);
            }
        }

        [Obsolete]
        private void BtnStartClickHandler(object sender, System.EventArgs e)
        {
            string adflyAddress = inputAdflyAddress.Text;

            if (IsURL(adflyAddress) && serverConnect == true && adflyConnect == false)
            {
                adflyConnect = true;
                Task task = new Task(() => {
                    NewAdflyCheat(adflyAddress);
                });

                task.Start();
                DisableButton(btnStart);
                EnableButton(btnStop);
            }
        }

        private void BtnStopClickHandler(object sender, System.EventArgs e)
        {

            if (serverConnect == true && adflyConnect == true)
            {

                Driver.Quit();
                adflyConnect = false;
                DisableButton(btnStop);
                EnableButton(btnStart);
            }
        }
        private void DisableButton (Button button)
        {
            button.Enabled = false;
            button.BackColor = Color.FromArgb(90, 90, 90);
        }

        private void EnableButton(Button button)
        {
            button.Enabled = true;
            button.BackColor = Color.FromArgb(20, 109, 224);
            button.ForeColor = Color.FromArgb(255, 255, 255);
        }

       private void NewAdflyCheat (string adflyAddress)
        {
            if (adflyConnect)
            {
                Driver = getNewWebDriver();

                Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                try
                {
                    Driver.Navigate().GoToUrl(adflyAddress);

                    WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                    wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("mwButton")));

                    Wait(3000, () => {
                        string url = Driver.FindElement(By.ClassName("mwButton")).GetAttribute("href");
                        Driver.Navigate().GoToUrl(url);

                        Wait(3000, () => {
                            Driver.Quit();
                        });
                    });

                    seproxy.GetNewProxy(() => {
                        NewAdflyCheat(adflyAddress);
                    });

                }
                catch (Exception)
                {
                    Driver.Quit();
                    NewAdflyCheat(adflyAddress);

                }
            }
        }

        private void SetTextStatusServer (string status, string serverAdress = "")
        {
            switch (status)
            {
                case "connected":
                    textStatusServer.Text = "Server status: connected to " + serverAdress;
                    textStatusServer.ForeColor = Color.FromArgb(255, 204, 7);
                    break;
                case "disconected":
                    textStatusServer.Text = "Server status: disconected";
                    textStatusServer.ForeColor = Color.FromArgb(255, 255, 255);
                    break;
                case "error":
                    textStatusServer.Text = "Server status: error";
                    textStatusServer.ForeColor = Color.FromArgb(255, 89, 89);
                    break;
                case "not responsing":
                    textStatusServer.Text = "Server status: not responsing";
                    textStatusServer.ForeColor = Color.FromArgb(127, 0, 0);
                    break;
                default:
                    break;
            }

        }

        private bool IsURL (string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        private void ShowError (string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        }

        private IWebDriver getNewWebDriver ()
        {
            string[] userUgent = File.ReadLines("user-agents.txt").ToArray();
            int randomUserUgent = RandomNumber(1, userUgent.Length);
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddArguments("disable-infobars");
            options.AddArgument("--user-agent=" + userUgent[randomUserUgent]);
            Driver = new ChromeDriver(options);
            return Driver;
        }
        private void Wait(int milliseconds, Action callBack)
        {
            Timer timer = new Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer.Interval = milliseconds;
            timer.Enabled = true;
            timer.Start();
            timer.Tick += (s, e) =>
            {
                timer.Enabled = false;
                timer.Stop();
                callBack();
            };
            while (timer.Enabled)
            {
                Application.DoEvents();
            }
        }

        private int RandomNumber (int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void ProgramForm_Load(object sender, EventArgs e)
        {

        }
    }
}
