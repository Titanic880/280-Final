using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

using Standards.Network;
using Standards.User;

namespace FinalProj_Helper
{
    public class Helper_Connection
    {
        private readonly string IPAddress;
        public User_Data User { get; set; }
        public Control Allowed_Control { get; set; }


        //User Stack
        private TcpClient tcpClient;
        private NetworkStream nStream;
        private BinaryWriter writer;

        //Worker
        readonly private BackgroundWorker wkr = new BackgroundWorker();

        public Helper_Connection(string Ip)
        {
            //Ip to use
            IPAddress = Ip;


        }
    }
}
