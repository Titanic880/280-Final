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


        private void PbScreenShare_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void PbScreenShare_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

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
                    SendToHostee();
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
    }
}
