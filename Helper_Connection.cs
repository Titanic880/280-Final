using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

using Standards.Network;
using Standards.User;
using Standards;

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

            wkr.DoWork += Wkr_DoWork;

            wkr.RunWorkerAsync();
        }

        private void Wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            tcpClient = new TcpClient();

            tcpClient.Connect(IPAddress, General_Standards.Port);

            nStream = tcpClient.GetStream();
            writer = new BinaryWriter(nStream);
            IFormatter Stream = new BinaryFormatter();

            while (true)
            {
                if(nStream == null)
                {
                    nStream = tcpClient.GetStream();
                    writer = new BinaryWriter(nStream);
                    Stream = new BinaryFormatter();
                }
                object o = Stream.Deserialize(nStream);

                switch (o)
                {
                    //Delegate? (With user prompt)
                    case File_Standard _:

                        break;
                        //Delegate?
                    case User_Input _:

                        break;
                        //Direct configure (Hook into internal delegate!)
                    case Control _:

                        break;
                        //UNIMPLEMENTED IDEA
                    case byte[] _:

                        break;
                        //UNIMPLEMENTED IDEA
                    case string _:

                        break;
                }
            }
        }
    }
}
