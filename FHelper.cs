using Standards;
using Standards.Network;
using Standards.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProj_Helper
{
    public partial class FHelper : Form
    {
        private Helper_Connection H_connection;
        public static User_Data User { get; set; }

        //Message history system
        private readonly List<string> messages = new List<string>();
        private int messagesPOS = 0;

        public FHelper()
        {
            InitializeComponent();
            //Sets up Network IP List
            TbIP.Text = Dns.GetHostEntry(SystemInformation.ComputerName).AddressList
               .Where(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();
            Standards.EF_Database.Db_Logic.Connect("server=localhost,1433;database=280Final;user id=SA;password=SchoolCont");
            KeyPreview = true;

            messages.Add("");
        }
        #region ScreenShare
        /// <summary>
        /// Sends key inputs to the helpee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbScreenShare_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (H_connection != null)
                if (H_connection.Allowed_Control != null)
                    //Checks if keyboard control is allowed
                    if (H_connection.Allowed_Control.KeyBoard)
                    {
                        User_Input input = new User_Input
                        {
                            Input_Type = true,
                            Key_Pressed = e.KeyCode
                        };
                        H_connection.Send_To_Helpee(input);
                    }
                    else
                    {
                        RequestControl(false);
                    }
        }

        /// <summary>
        /// Sends mouse inputs to the helpee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbScreenShare_Click(object sender, EventArgs e)
        {
            if (H_connection != null)
                if (H_connection.Allowed_Control != null)
                    //Checks if Mouse control is allowed
                    if (H_connection.Allowed_Control.Mouse)
                    {
                        User_Input input = new User_Input();
                        MouseEventArgs args = (MouseEventArgs)e;
                        if (args.Button == MouseButtons.Left)
                            input.Click_Side = true;
                        input.xRatio = Convert.ToDouble(args.X) / Convert.ToDouble(PbScreenShare.Width);
                        input.yRatio = Convert.ToDouble(args.Y) / Convert.ToDouble(PbScreenShare.Height);
                        
                        H_connection.Send_To_Helpee(input);
                    }
                    else
                    {
                        RequestControl(true);
                    }
        }
        private void RequestControl(bool type)
        {
            //Same bool Idea as User_Input
            string txt;
            if (type)
                txt = "Would you like to request Keyboard Access?";
            else
                txt = "Would you like to request Mouse Access?";


            DialogResult res = MessageBox.Show(txt, "Request Access?", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //Generates and sends a request to the host (helpee)
                User_Input ui = new User_Input
                {
                    Request = true
                };
                H_connection.Send_To_Helpee(ui);
                MessageBox.Show("Request Sent!");
            }
        }
        #endregion ScreenShare
        /// <summary>
        /// QoL Textbox controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TbChatMessage_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (messagesPOS < 0) //Loops to top
                messagesPOS = messages.Count;
            else if (messagesPOS > messages.Count) //Loops to bottom
                messagesPOS = -1;

            //Switch of all used keys
            switch (e.KeyCode)
            {
                //Cycles to newer message
                case Keys.Down:
                    messagesPOS++;

                    if (messagesPOS < 0) //Loops to top
                        messagesPOS = messages.Count - 1;
                    else if (messagesPOS >= messages.Count) //Loops to bottom
                        messagesPOS = 0;

                    if (messages[messagesPOS] == null)
                        return;
                    else
                        TbChatMessage.Text = messages[messagesPOS];
                    break;
                //Cycles to older message
                case Keys.Up:
                    messagesPOS--;

                    if (messagesPOS < 0) //Loops to top
                        messagesPOS = messages.Count - 1;
                    else if (messagesPOS > messages.Count) //Loops to bottom
                        messagesPOS = 0;

                    if (messages[messagesPOS] == null)
                        return;
                    else
                        TbChatMessage.Text = messages[messagesPOS];
                    break;

                //Sends a message if enter is pressed
                case Keys.Enter:
                    Send_Message();
                    break;
                default:
                    break;
            }
        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (H_connection != null)
            {

                OpenFileDialog ofd = new OpenFileDialog
                {
                    Title = "Choose a file to send",
                    Multiselect = false
                };
                DialogResult res = ofd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string tmp = ofd.FileName.Split('\\')[ofd.FileName.Split('\\').Length - 1];
                    File_Standard fs = new File_Standard
                    {
                        //Grabs the file Name
                        File_Name = tmp.Split('.')[tmp.Split('.').Length - 1],
                        //Grabs the last object that occurs after a period (File Extension)
                        File_Ext = ofd.FileName.Split('.')[ofd.FileName.Split('.').Length - 1],
                        //Gets the contents and sets the file flag
                        File_Contents = File.ReadAllBytes(ofd.FileName),
                        Is_File = true
                    };

                    H_connection.Send_To_Helpee(fs);
                }
                else
                    MessageBox.Show("File selection cancelled");
            }
            
        }

        private void Send_Message()
        {
            File_Standard fs = new File_Standard
            {
                Message = TbChatMessage.Text,
                File_Name = "Chat_Message",
                File_Ext = "MSG"
            };

            LstChat.Items.Add(TbChatMessage.Text);
            TbChatMessage.Text = "";

            H_connection.Send_To_Helpee(fs);
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            H_connection = new Helper_Connection(TbIP.Text);
            H_connection.UpdatePicture += UpdatePicture;
            H_connection.Rekoved_Control += Revoked_Control;
            H_connection.FileIncoming += FileIncoming;
        }

        #region Delegates
        /// <summary>
        /// HANDLES FILES AND MESSAGES
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        private void FileIncoming(File_Standard FileR)
        {
            if (FileR.Is_File)
            {
                DialogResult res = MessageBox.Show($"File recieved, would you like to install it? ({FileR.File_Name}.{FileR.File_Ext})",
                    "Install File?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    File.WriteAllBytes(FileR.File_Name + FileR.File_Ext, FileR.File_Contents);
            }
            else
                LstChat.Items.Add(FileR.Message);
        }

        /// <summary>
        /// Alerts the helper that the control has been revoked
        /// </summary>
        private void Revoked_Control(string Message)
        {
            MessageBox.Show(Message);
        }
        private void UpdatePicture(Image file) => BeginInvoke(new MethodInvoker(() => UpdatePic(file)));
        private void UpdatePic(Image img) => PbScreenShare.Image = img;

        #endregion Delegates

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //User = Standards.EF_Database.Db_Logic.Login(TbUsername.Text, General_Standards.Hasher(MTbPassword.Text));
            if (User != null)
            {
                TbUsername.Enabled = false;
                MTbPassword.Enabled = false;
                BtnLogin.Enabled = false;
                BtnConnect.Enabled = true;
            }
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Send_Message();
        }
    }
}
