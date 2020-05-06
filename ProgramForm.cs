using SeproxyTools;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AdflySe
{
    public partial class ProgramForm : Form
    {
        Seproxy seproxy = new Seproxy();
        bool serverConnect = false;
        public ProgramForm()
        {
            InitializeComponent();
            
            

            if (seproxy.SetServerAddress("http://322.188.53.22:8080"))
            {
                seproxy.Connect();
                seproxy.GetNewProxy(() => {
                    Debug.WriteLine("Proxy changed");
                });
            }

            

        }

        public bool NewProxyHandler (string response)
        {
            return false;
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
            this.btnServerConnect.Click += new System.EventHandler(this.connectBtnClickHandler);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(109)))), ((int)(((byte)(224)))));
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStop.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnStop.Location = new System.Drawing.Point(421, 419);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(148, 31);
            this.btnStop.TabIndex = 3;
            this.btnStop.TabStop = false;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // btnServerDisconnect
            // 
            this.btnServerDisconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(109)))), ((int)(((byte)(224)))));
            this.btnServerDisconnect.FlatAppearance.BorderSize = 0;
            this.btnServerDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServerDisconnect.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnServerDisconnect.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnServerDisconnect.Location = new System.Drawing.Point(421, 300);
            this.btnServerDisconnect.Name = "btnServerDisconnect";
            this.btnServerDisconnect.Size = new System.Drawing.Size(148, 33);
            this.btnServerDisconnect.TabIndex = 4;
            this.btnServerDisconnect.TabStop = false;
            this.btnServerDisconnect.Text = "Disconnect";
            this.btnServerDisconnect.UseVisualStyleBackColor = false;
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
            this.textStatusServer.AutoSize = true;
            this.textStatusServer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textStatusServer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.textStatusServer.Location = new System.Drawing.Point(286, 210);
            this.textStatusServer.Name = "textStatusServer";
            this.textStatusServer.Size = new System.Drawing.Size(184, 18);
            this.textStatusServer.TabIndex = 7;
            this.textStatusServer.Text = "Server status: not connected";
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
            this.MaximizeBox = false;
            this.Name = "ProgramForm";
            this.Load += new System.EventHandler(this.ProgramForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ProgramForm_Load(object sender, System.EventArgs e)
        {

        }

        private void connectBtnClickHandler(object sender, System.EventArgs e)
        {
            string seAdressInInput = inputServerAddress.Text;

            if (seAdressInInput != "" && serverConnect == false)
            {
                serverConnect = true;
                disableButton(btnServerConnect);
                setTextStatusServer("connected");
                Debug.WriteLine(seAdressInInput);
            }

        }
        public void disableButton (Button button)
        {
            button.Enabled = false;
            button.BackColor = Color.FromArgb(90, 90, 90);
        }

        public void enableButton(Button button)
        {
            button.Enabled = true;
            button.BackColor = Color.FromArgb(20, 109, 224);
            button.ForeColor = Color.FromArgb(255, 255, 255);
        }

        public void setTextStatusServer (string status)
        {
            switch (status)
            {
                case "connected":
                    textStatusServer.Text = "Server status: connected";
                    textStatusServer.ForeColor = Color.FromArgb(255, 204, 7);
                    break;
                case "disconected":
                    textStatusServer.Text = "Server status: disconected";
                    break;
                case "error":
                    textStatusServer.Text = "Server status: error";
                    break;
                case "not responsing":
                    textStatusServer.Text = "Server status: not responsing";
                    break;
                default:
                    break;
            }

        }

    }
}
