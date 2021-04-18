using Standards;
using Standards.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProj_Helper
{
    public partial class Form1 : Form
    {
        //Recieves messages/files
        readonly Queue<object> IncomingData = new Queue<object>();
        Helper_Connection connection;


        //Message history system
        private readonly List<string> messages = new List<string>();
        private int messagesPOS = 0;

        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;

            messages.Add("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PbScreenShare_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Checks if keyboard control is allowed
            if (connection.Allowed_Control.KeyBoard)
            {

            }
            else
            {
                RequestControl("Keyboard");
            }
        }
        private void PbScreenShare_Click(object sender, EventArgs e)
        {
            //Checks if Mouse control is allowed
            if (connection.Allowed_Control.Mouse)
            {

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
                connection.Send_To_Helpee(ui);
                MessageBox.Show("Request Sent!");
            }
        }

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
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a file to send";
            ofd.Multiselect = false;
            DialogResult res =  ofd.ShowDialog();
            if(res == DialogResult.OK)
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

                SendToHostee(fs);
            }
            else
                MessageBox.Show("File selection cancelled");
            
        }

        private void Send_Message()
        {
            File_Standard fs = new File_Standard
            {
                File_Contents = General_Standards.Encrypt(TbChatMessage.Text),
                File_Name = "Chat_Message",
                File_Ext = "MSG"
            };

            LstChat.Items.Add(TbChatMessage.Text);
            TbChatMessage.Text = "";

            connection.Send_To_Helpee(fs);
        }
    }
}
