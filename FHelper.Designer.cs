
namespace FinalProj_Helper
{
    partial class FHelper
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
            this.PbScreenShare = new System.Windows.Forms.PictureBox();
            this.BtnSend = new System.Windows.Forms.Button();
            this.LstChat = new System.Windows.Forms.ListBox();
            this.LblChat = new System.Windows.Forms.Label();
            this.TbChatMessage = new System.Windows.Forms.TextBox();
            this.BtnSendFile = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.LbliP = new System.Windows.Forms.Label();
            this.TbUsername = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            this.MTbPassword = new System.Windows.Forms.MaskedTextBox();
            this.TbIP = new System.Windows.Forms.TextBox();
            this.BtnRegister = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PbScreenShare)).BeginInit();
            this.SuspendLayout();
            // 
            // PbScreenShare
            // 
            this.PbScreenShare.Dock = System.Windows.Forms.DockStyle.Right;
            this.PbScreenShare.Location = new System.Drawing.Point(297, 0);
            this.PbScreenShare.Name = "PbScreenShare";
            this.PbScreenShare.Size = new System.Drawing.Size(503, 450);
            this.PbScreenShare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PbScreenShare.TabIndex = 0;
            this.PbScreenShare.TabStop = false;
            this.PbScreenShare.Click += new System.EventHandler(this.PbScreenShare_Click);
            this.PbScreenShare.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PbScreenShare_PreviewKeyDown);
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(5, 360);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(140, 23);
            this.BtnSend.TabIndex = 1;
            this.BtnSend.Text = "Send Message";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click);
            // 
            // LstChat
            // 
            this.LstChat.FormattingEnabled = true;
            this.LstChat.Location = new System.Drawing.Point(5, 233);
            this.LstChat.Name = "LstChat";
            this.LstChat.Size = new System.Drawing.Size(286, 95);
            this.LstChat.TabIndex = 2;
            // 
            // LblChat
            // 
            this.LblChat.AutoSize = true;
            this.LblChat.Location = new System.Drawing.Point(2, 217);
            this.LblChat.Name = "LblChat";
            this.LblChat.Size = new System.Drawing.Size(50, 13);
            this.LblChat.TabIndex = 3;
            this.LblChat.Text = "Chat Box";
            // 
            // TbChatMessage
            // 
            this.TbChatMessage.Location = new System.Drawing.Point(5, 334);
            this.TbChatMessage.Name = "TbChatMessage";
            this.TbChatMessage.Size = new System.Drawing.Size(286, 20);
            this.TbChatMessage.TabIndex = 4;
            this.TbChatMessage.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.TbChatMessage_PreviewKeyDown);
            // 
            // BtnSendFile
            // 
            this.BtnSendFile.Location = new System.Drawing.Point(151, 360);
            this.BtnSendFile.Name = "BtnSendFile";
            this.BtnSendFile.Size = new System.Drawing.Size(140, 23);
            this.BtnSendFile.TabIndex = 5;
            this.BtnSendFile.Text = "Send File";
            this.BtnSendFile.UseVisualStyleBackColor = true;
            this.BtnSendFile.Click += new System.EventHandler(this.BtnSendFile_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(5, 189);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(121, 23);
            this.BtnConnect.TabIndex = 7;
            this.BtnConnect.Text = "Connect to User";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnLogin
            // 
            this.BtnLogin.Location = new System.Drawing.Point(5, 91);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(121, 23);
            this.BtnLogin.TabIndex = 8;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = true;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LbliP
            // 
            this.LbliP.AutoSize = true;
            this.LbliP.Location = new System.Drawing.Point(2, 146);
            this.LbliP.Name = "LbliP";
            this.LbliP.Size = new System.Drawing.Size(46, 13);
            this.LbliP.TabIndex = 9;
            this.LbliP.Text = "Users Ip";
            // 
            // TbUsername
            // 
            this.TbUsername.Location = new System.Drawing.Point(5, 25);
            this.TbUsername.Name = "TbUsername";
            this.TbUsername.Size = new System.Drawing.Size(121, 20);
            this.TbUsername.TabIndex = 10;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(2, 48);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(53, 13);
            this.LblPassword.TabIndex = 12;
            this.LblPassword.Text = "Password";
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Location = new System.Drawing.Point(2, 9);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(55, 13);
            this.LblUsername.TabIndex = 13;
            this.LblUsername.Text = "Username";
            // 
            // MTbPassword
            // 
            this.MTbPassword.Location = new System.Drawing.Point(5, 65);
            this.MTbPassword.Name = "MTbPassword";
            this.MTbPassword.PasswordChar = '*';
            this.MTbPassword.Size = new System.Drawing.Size(121, 20);
            this.MTbPassword.TabIndex = 14;
            this.MTbPassword.UseSystemPasswordChar = true;
            // 
            // TbIP
            // 
            this.TbIP.Location = new System.Drawing.Point(5, 163);
            this.TbIP.Name = "TbIP";
            this.TbIP.Size = new System.Drawing.Size(121, 20);
            this.TbIP.TabIndex = 15;
            // 
            // BtnRegister
            // 
            this.BtnRegister.Location = new System.Drawing.Point(5, 120);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(121, 23);
            this.BtnRegister.TabIndex = 16;
            this.BtnRegister.Text = "Register";
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // FHelper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.TbIP);
            this.Controls.Add(this.MTbPassword);
            this.Controls.Add(this.LblUsername);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.TbUsername);
            this.Controls.Add(this.LbliP);
            this.Controls.Add(this.BtnLogin);
            this.Controls.Add(this.BtnConnect);
            this.Controls.Add(this.BtnSendFile);
            this.Controls.Add(this.TbChatMessage);
            this.Controls.Add(this.LblChat);
            this.Controls.Add(this.LstChat);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.PbScreenShare);
            this.Name = "FHelper";
            this.Text = "Tech Support";
            ((System.ComponentModel.ISupportInitialize)(this.PbScreenShare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PbScreenShare;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.ListBox LstChat;
        private System.Windows.Forms.Label LblChat;
        private System.Windows.Forms.TextBox TbChatMessage;
        private System.Windows.Forms.Button BtnSendFile;
        private System.Windows.Forms.Button BtnConnect;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Label LbliP;
        private System.Windows.Forms.TextBox TbUsername;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.MaskedTextBox MTbPassword;
        private System.Windows.Forms.TextBox TbIP;
        private System.Windows.Forms.Button BtnRegister;
    }
}

