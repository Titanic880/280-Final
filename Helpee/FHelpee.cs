﻿using AutoIt;
using Standards;
using Standards.Network;
using Standards.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Helpee
{
    public partial class FHelpee : Form
    {
        private static Helpee_Connection connection;
        private TcpListener tcpListener;

        private readonly Timer tim = new Timer();
        private readonly Timer timee = new Timer();
        public Bitmap Screenshot { get; private set; }
        //What is displayed
        Graphics ScreenGraphics;

        //Stops keyboard input
        private bool stop = false;
        //Stops the user from double clicking the stop action
        private const int minTime = 3;
        private int stopTime = minTime;

        //Message history system
        private readonly List<string> messages = new List<string>();
        private int messagesPOS = 0;

        public FHelpee()
        {
            InitializeComponent();
            //Gets the local IP to host on
            this.KeyPreview = true;

            TbIP.Text = Dns
                .GetHostEntry(SystemInformation.ComputerName)
                .AddressList
                .Where(x => x.AddressFamily == AddressFamily.InterNetwork)
                .FirstOrDefault().ToString();
            if(!Standards.EF_Database.Db_Logic.Connect("server=localhost,1433;database=280Final;user id=SA;password=SchoolCont"))
                MessageBox.Show("Login Not Working.");

            tim.Interval = 3000;
            tim.Tick += Tim_Tick;
            timee.Tick += Timee_Tick;
        }

        private void Timee_Tick(object sender, EventArgs e)
        {
            timee.Stop();
            MessageBox.Show("Control has been revoked from the helper");
            BtnAllow.Enabled = true;
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            //Generate the size of the image
            Screenshot = new Bitmap(General_Standards.Current_Screen.Bounds.Width,
                                    General_Standards.Current_Screen.Bounds.Height,
                                    PixelFormat.Format32bppArgb);
            //Generates the image
            ScreenGraphics = Graphics.FromImage(Screenshot);
            //Copies screen
            ScreenGraphics.CopyFromScreen(
                //Sets the size of the original Picture
                General_Standards.Current_Screen.Bounds.X,
                General_Standards.Current_Screen.Bounds.Y,
                //Sets the origin of the x/y of render body
                0, 0,
                //Sets the size of the render body
                Screen.PrimaryScreen.Bounds.Size,
                CopyPixelOperation.SourceCopy
                );

            //Sets the picture box
            PbScreenShare.Image = Screenshot;

            //Sends image to the helper
            if (connection != null)
                connection.Send_To_Helper(PbScreenShare.Image);
            
            //NOT NEEDED WITH TIMER
            //System.Threading.Thread.Sleep(1500);
            //Cleans up what is not in use (goes from gigabytes in seconds to a consistent >100MB process)
            GC.Collect();
            //Checks for stopping
            if (!stop && stopTime > 0)
                stopTime--;
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
            tim.Start();
            //imagewkr.RunWorkerAsync();
        }

        private void Connection_InputIncoming(User_Input input)
        {
            //Checks if the user has stopped input
            if (!stop)
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
                        int xClick = Convert.ToInt32(General_Standards.Current_Screen.Bounds.Width * input.xRatio);
                        int yClick = Convert.ToInt32(General_Standards.Current_Screen.Bounds.Height * input.yRatio);
                        //Clicks with left or right click
                        if (input.Click_Side)
                            AutoItX.MouseClick("LEFT", xClick, yClick);
                        else
                            AutoItX.MouseClick("RIGHT", xClick, yClick);
                    }
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
                LstChat.Items.Add(fs.Message);
            
        }

        #endregion Delegates

        private void BtnSend_Click(object sender, EventArgs e)
        {
            Send_Message();
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

            connection.Send_To_Helper(fs);
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
            if(!CbTimer.Checked)
                MessageBox.Show("Please be warned, the helper will have unconditional control of the given attributes without a timer limiting them!");
        }

        private void BtnAllow_Click(object sender, EventArgs e)
        {
            Control_Data cntrl = new Control_Data
            {
                KeyBoard = CbKeyboard.Checked,
                Mouse = CbMouse.Checked,
                Timer_Time = Convert.ToInt32(NUDTimer.Value),
                Use_Timer = CbTimer.Checked
            };

            connection.Send_To_Helper(cntrl);

            
            //Checks to see if using timer, sets a local timer to alert the helpee that it has timed out
            if (CbTimer.Checked)
            {
                BtnAllow.Enabled = false;
                timee.Interval = Convert.ToInt32(NUDTimer.Value)*1000;
                timee.Start();
            }

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
                    Send_Message();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Any control can/should tie into this
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FHelpee_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Checks if we're already stopped
            if (!stop)
            {   //checks for stop key
                if (e.KeyCode == Keys.Escape)
                {
                    stop = true;
                    stopTime = minTime;
                    MessageBox.Show("Input has been blocked!");
                }
            }
            else if (stopTime == 0)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    stop = false;
                    MessageBox.Show("Input has been re-enabled!");
                }
            }
        }
    }
}
