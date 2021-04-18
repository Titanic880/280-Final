
namespace FinalProj_Helper
{
    partial class Form1
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
            this.PbScreenShare.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbScreenShare_MouseClick);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnSendFile);
            this.Controls.Add(this.TbChatMessage);
            this.Controls.Add(this.LblChat);
            this.Controls.Add(this.LstChat);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.PbScreenShare);
            this.Name = "Form1";
            this.Text = "Form1";
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
    }
}

