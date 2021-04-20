
namespace Helpee
{
    partial class FHelpee
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
            this.TbIP = new System.Windows.Forms.TextBox();
            this.MTbPassword = new System.Windows.Forms.MaskedTextBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TbUsername = new System.Windows.Forms.TextBox();
            this.LbliP = new System.Windows.Forms.Label();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.BtnHost = new System.Windows.Forms.Button();
            this.BtnSendFile = new System.Windows.Forms.Button();
            this.TbChatMessage = new System.Windows.Forms.TextBox();
            this.LblChat = new System.Windows.Forms.Label();
            this.LstChat = new System.Windows.Forms.ListBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.PbScreenShare = new System.Windows.Forms.PictureBox();
            this.BtnAllow = new System.Windows.Forms.Button();
            this.CbTimer = new System.Windows.Forms.CheckBox();
            this.NUDTimer = new System.Windows.Forms.NumericUpDown();
            this.LblTime = new System.Windows.Forms.Label();
            this.CbKeyboard = new System.Windows.Forms.CheckBox();
            this.CbMouse = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.PbScreenShare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // TbIP
            // 
            this.TbIP.Location = new System.Drawing.Point(4, 137);
            this.TbIP.Name = "TbIP";
            this.TbIP.Size = new System.Drawing.Size(121, 20);
            this.TbIP.TabIndex = 29;
            // 
            // MTbPassword
            // 
            this.MTbPassword.Location = new System.Drawing.Point(4, 65);
            this.MTbPassword.Name = "MTbPassword";
            this.MTbPassword.PasswordChar = '*';
            this.MTbPassword.Size = new System.Drawing.Size(121, 20);
            this.MTbPassword.TabIndex = 28;
            this.MTbPassword.UseSystemPasswordChar = true;
            this.MTbPassword.Visible = false;
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Location = new System.Drawing.Point(1, 9);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(55, 13);
            this.LblUsername.TabIndex = 27;
            this.LblUsername.Text = "Username";
            this.LblUsername.Visible = false;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(1, 48);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(53, 13);
            this.LblPassword.TabIndex = 26;
            this.LblPassword.Text = "Password";
            this.LblPassword.Visible = false;
            // 
            // TbUsername
            // 
            this.TbUsername.Location = new System.Drawing.Point(4, 25);
            this.TbUsername.Name = "TbUsername";
            this.TbUsername.Size = new System.Drawing.Size(121, 20);
            this.TbUsername.TabIndex = 25;
            this.TbUsername.Visible = false;
            // 
            // LbliP
            // 
            this.LbliP.AutoSize = true;
            this.LbliP.Location = new System.Drawing.Point(1, 120);
            this.LbliP.Name = "LbliP";
            this.LbliP.Size = new System.Drawing.Size(46, 13);
            this.LbliP.TabIndex = 24;
            this.LbliP.Text = "Users Ip";
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(4, 91);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(121, 23);
            this.BtnLogin.TabIndex = 23;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Visible = false;
            // 
            // BtnHost
            // 
            this.BtnHost.Location = new System.Drawing.Point(4, 163);
            this.BtnHost.Name = "BtnHost";
            this.BtnHost.Size = new System.Drawing.Size(121, 23);
            this.BtnHost.TabIndex = 22;
            this.BtnHost.Text = "Host";
            this.BtnHost.UseVisualStyleBackColor = true;
            this.BtnHost.Click += new System.EventHandler(this.BtnHost_Click);
            // 
            // BtnSendFile
            // 
            this.BtnSendFile.Location = new System.Drawing.Point(150, 360);
            this.BtnSendFile.Name = "BtnSendFile";
            this.BtnSendFile.Size = new System.Drawing.Size(140, 23);
            this.BtnSendFile.TabIndex = 21;
            this.BtnSendFile.Text = "Send File";
            this.BtnSendFile.UseVisualStyleBackColor = true;
            this.BtnSendFile.Click += new System.EventHandler(this.BtnSendFile_Click);
            // 
            // TbChatMessage
            // 
            this.TbChatMessage.Location = new System.Drawing.Point(4, 334);
            this.TbChatMessage.Name = "TbChatMessage";
            this.TbChatMessage.Size = new System.Drawing.Size(286, 20);
            this.TbChatMessage.TabIndex = 20;
            // 
            // LblChat
            // 
            this.LblChat.AutoSize = true;
            this.LblChat.Location = new System.Drawing.Point(1, 217);
            this.LblChat.Name = "LblChat";
            this.LblChat.Size = new System.Drawing.Size(50, 13);
            this.LblChat.TabIndex = 19;
            this.LblChat.Text = "Chat Box";
            // 
            // LstChat
            // 
            this.LstChat.FormattingEnabled = true;
            this.LstChat.Location = new System.Drawing.Point(4, 233);
            this.LstChat.Name = "LstChat";
            this.LstChat.Size = new System.Drawing.Size(286, 95);
            this.LstChat.TabIndex = 18;
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(4, 360);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(140, 23);
            this.BtnSend.TabIndex = 17;
            this.BtnSend.Text = "Send Message";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // PbScreenShare
            // 
            this.PbScreenShare.Dock = System.Windows.Forms.DockStyle.Right;
            this.PbScreenShare.Location = new System.Drawing.Point(297, 0);
            this.PbScreenShare.Name = "PbScreenShare";
            this.PbScreenShare.Size = new System.Drawing.Size(503, 450);
            this.PbScreenShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbScreenShare.TabIndex = 16;
            this.PbScreenShare.TabStop = false;
            // 
            // BtnAllow
            // 
            this.BtnAllow.Location = new System.Drawing.Point(150, 134);
            this.BtnAllow.Name = "BtnAllow";
            this.BtnAllow.Size = new System.Drawing.Size(140, 23);
            this.BtnAllow.TabIndex = 31;
            this.BtnAllow.Text = "Allow Control";
            this.BtnAllow.UseVisualStyleBackColor = true;
            this.BtnAllow.Click += new System.EventHandler(this.BtnAllow_Click);
            // 
            // CbTimer
            // 
            this.CbTimer.AutoSize = true;
            this.CbTimer.Checked = true;
            this.CbTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbTimer.Location = new System.Drawing.Point(150, 67);
            this.CbTimer.Name = "CbTimer";
            this.CbTimer.Size = new System.Drawing.Size(117, 17);
            this.CbTimer.TabIndex = 32;
            this.CbTimer.Text = "Use Auto Timeout?";
            this.CbTimer.UseVisualStyleBackColor = true;
            this.CbTimer.CheckedChanged += new System.EventHandler(this.CbTimer_CheckedChanged);
            // 
            // NUDTimer
            // 
            this.NUDTimer.Location = new System.Drawing.Point(151, 45);
            this.NUDTimer.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.NUDTimer.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NUDTimer.Name = "NUDTimer";
            this.NUDTimer.Size = new System.Drawing.Size(56, 20);
            this.NUDTimer.TabIndex = 33;
            this.NUDTimer.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Location = new System.Drawing.Point(148, 29);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(131, 13);
            this.LblTime.TabIndex = 34;
            this.LblTime.Text = "Time Allowed (In seconds)";
            // 
            // CbKeyboard
            // 
            this.CbKeyboard.AutoSize = true;
            this.CbKeyboard.Checked = true;
            this.CbKeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbKeyboard.Location = new System.Drawing.Point(150, 88);
            this.CbKeyboard.Name = "CbKeyboard";
            this.CbKeyboard.Size = new System.Drawing.Size(135, 17);
            this.CbKeyboard.TabIndex = 35;
            this.CbKeyboard.Text = "Allow Keyboard Control";
            this.CbKeyboard.UseVisualStyleBackColor = true;
            // 
            // CbMouse
            // 
            this.CbMouse.AutoSize = true;
            this.CbMouse.Checked = true;
            this.CbMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbMouse.Location = new System.Drawing.Point(150, 111);
            this.CbMouse.Name = "CbMouse";
            this.CbMouse.Size = new System.Drawing.Size(122, 17);
            this.CbMouse.TabIndex = 36;
            this.CbMouse.Text = "Allow Mouse Control";
            this.CbMouse.UseVisualStyleBackColor = true;
            // 
            // FHelpee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CbMouse);
            this.Controls.Add(this.CbKeyboard);
            this.Controls.Add(this.LblTime);
            this.Controls.Add(this.NUDTimer);
            this.Controls.Add(this.CbTimer);
            this.Controls.Add(this.BtnAllow);
            this.Controls.Add(this.TbIP);
            this.Controls.Add(this.MTbPassword);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.TbUsername);
            this.Controls.Add(this.LbliP);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.BtnHost);
            this.Controls.Add(this.BtnSendFile);
            this.Controls.Add(this.TbChatMessage);
            this.Controls.Add(this.LblChat);
            this.Controls.Add(this.LstChat);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.PbScreenShare);
            this.Name = "FHelpee";
            this.Text = "Tech Support Helper";
            ((System.ComponentModel.ISupportInitialize)(this.PbScreenShare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbIP;
        private System.Windows.Forms.MaskedTextBox MTbPassword;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TbUsername;
        private System.Windows.Forms.Label LbliP;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Button BtnHost;
        private System.Windows.Forms.Button BtnSendFile;
        private System.Windows.Forms.TextBox TbChatMessage;
        private System.Windows.Forms.Label LblChat;
        private System.Windows.Forms.ListBox LstChat;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.PictureBox PbScreenShare;
        private System.Windows.Forms.Button BtnAllow;
        private System.Windows.Forms.CheckBox CbTimer;
        private System.Windows.Forms.NumericUpDown NUDTimer;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.CheckBox CbKeyboard;
        private System.Windows.Forms.CheckBox CbMouse;
    }
}

