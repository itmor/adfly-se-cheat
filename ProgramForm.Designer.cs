namespace AdflySe
{
    partial class ProgramForm
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
        private System.Windows.Forms.TextBox inputServerAddress;
        private System.Windows.Forms.Button btnServerConnect;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnServerDisconnect;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox inputAdflyAddress;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Label textStatusServer;
    }
}

