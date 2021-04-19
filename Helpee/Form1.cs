using AutoIt;
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
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpee
{
    public partial class Form1 : Form
    {
        private Helpee_Connection connection;
        private TcpListener tcpListener;

        public Form1()
        {
            InitializeComponent();
            //Gets the local IP to host on
            TbIP.Text = Dns
                .GetHostEntry(SystemInformation.ComputerName)
                .AddressList
                .Where(x => x.AddressFamily == AddressFamily.InterNetwork)
                .FirstOrDefault().ToString();
        }

        private void BtnHost_Click(object sender, EventArgs e)
        {
            BtnHost.Enabled = false;
            if(IPAddress.TryParse(TbIP.Text, out IPAddress serverIP))
            {
                tcpListener = new TcpListener(serverIP, General_Standards.Port);
                tcpListener.Start();

                connection = new Helpee_Connection(tcpListener);
                connection.FileIncoming += Connection_FileIncoming;
                connection.InputIncoming += Connection_InputIncoming;
                connection.NewClientConnected += Connection_NewClientConnected;
            }
            else
                MessageBox.Show("Invalid IP!!");
        }

        #region Delegates
        private void Connection_NewClientConnected(Helpee_Connection conn)
        {
            MessageBox.Show("a Helper has connected!");
        }

        private void Connection_InputIncoming(User_Input input)
        {
            //Checks if the user is requesting control
            if (!input.Request)
            {   //Checks if the input is mouse or keyboard action
                if (input.Input_Type)
                {
                    AutoItX.Send(input.Key_Pressed.ToString());
                }
                else
                {
                    //Calculates where to click
                    int xClick = (int)(SystemInformation.VirtualScreen.Width * input.xRatio);
                    int yClick = (int)(SystemInformation.VirtualScreen.Height * input.yRatio);
                    //Clicks with left or right click
                    if (input.Click_Side)
                        AutoItX.MouseClick("LEFT", xClick, yClick);
                    else
                        AutoItX.MouseClick("RIGHT", xClick, yClick);
                }
            }
        }

        private void Connection_FileIncoming(File_Standard fs)
        {
            if (fs.Is_File)
            {
                DialogResult res = MessageBox.Show($"File recieved, would you like to install it? ({fs.File_Name}.{fs.File_Ext})",
                "Install File?", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                    File.WriteAllBytes(fs.File_Name + fs.File_Ext, fs.File_Contents);
            }
            else
                LstChat.Items.Add(General_Standards.Decrypt(fs.File_Contents));
            
        }

        #endregion Delegates

        private void BtnSend_Click(object sender, EventArgs e)
        {

        }
        private void BtnSendFile_Click(object sender, EventArgs e)
        {
            if (connection != null)
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

                    connection.Send_To_Helper(fs);
                }
                else
                    MessageBox.Show("File selection cancelled");
            }
        }

        private void CbTimer_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Please be warned, the helper will have unconditional control of the given attributes without a timer limiting them!");
        }

        private void BtnAllow_Click(object sender, EventArgs e)
        {
            User_Control cntrl = new User_Control
            {
                KeyBoard = CbKeyboard.Checked,
                Mouse = CbMouse.Checked,
                Timer = Convert.ToInt32(NUDTimer.Value),
                Use_Timer = CbTimer.Checked
            };

            connection.Send_To_Helper(cntrl);
        }
    }
}
