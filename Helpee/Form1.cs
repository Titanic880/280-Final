using Standards.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        }

        private void BtnSend_Click(object sender, EventArgs e)
        {

        }

        private void BtnSendFile_Click(object sender, EventArgs e)
        {

        }

        private void CbTimer_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Please be warned, the helper will have unconditional control of the given atrobutes without a timer limiting them!");
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

            connection.Send_To_Helpee(cntrl);
        }
    }
}
