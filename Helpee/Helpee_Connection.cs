using Standards.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Standards;
using Standards.Network;

namespace Helpee
{
    public class Helpee_Connection
    {
        public TcpListener Helpee_Listener;

        public static User_Data User { get; set; }

        #region Delegates

        public event Connected NewClientConnected;
        public delegate void Connected(Helpee_Connection conn);
        #endregion Delegates

        private readonly BackgroundWorker wkr = new BackgroundWorker();

        private Socket C_Socket;
        private NetworkStream C_nStream;
        private BinaryReader C_reader;
        private BinaryWriter C_writer;

        public Helpee_Connection(TcpListener listener)
        {
            Helpee_Listener = listener;

            wkr.WorkerReportsProgress = true;
            wkr.DoWork += Wkr_DoWork;
            wkr.ProgressChanged += Wkr_ProgressChanged;

            wkr.RunWorkerAsync();
        }

        private void Wkr_DoWork(object sender, DoWorkEventArgs e)
        {
            C_Socket = Helpee_Listener.AcceptSocket();

            wkr.ReportProgress(0);

            C_nStream = new NetworkStream(C_Socket);
            C_reader = new BinaryReader(C_nStream);
            C_writer = new BinaryWriter(C_nStream);

            IFormatter formatter = new BinaryFormatter();

            while (true)
            {
                //Error checking
                if (C_nStream == null)
                {
                    C_nStream = new NetworkStream(C_Socket);
                    if (C_reader == null)
                        C_reader = new BinaryReader(C_nStream);

                    if (C_reader.BaseStream == null)
                        continue;
                }

                object o = formatter.Deserialize(C_reader.BaseStream);
                if (o is null)
                    continue;
                else //Instead of double sorting i sort it once
                    wkr.ReportProgress(1, o);
            }

        }

        private void Wkr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //New Client Connected
            if (e.ProgressPercentage == 0)
            {
                NewClientConnected(this);
                return;
            }
            object Sort = e.UserState;

            switch (Sort)
            {
                //Incoming Files/Messages
                case File_Standard _:

                    break;
                //incoming user input (or request)
                case User_Input UI:

                    break;

                default:
                    break;
            }
        }
    }
}
