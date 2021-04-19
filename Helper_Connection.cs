using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.ComponentModel;
using System.Net.Sockets;
using System.IO;

using Standards.Network;
using Standards.User;
using Standards;
using System.Drawing;

namespace FinalProj_Helper
{
    public class Helper_Connection
    {
        private readonly string IPAddress;
        public User_Control Allowed_Control { get; set; }

        #region Delegates

        //Runs when control is removed from the helper
        public event ControlRevoked Rekoved_Control;
        public delegate void ControlRevoked();

        //Runs when a file/message is incoming
        public event File_Recieved FileIncoming;
        public delegate void File_Recieved(File_Standard File);

        //Handles incoming Images
        public event Image_Update UpdatePicture;
        public delegate void Image_Update(Image file);
        #endregion Delegates

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
                //Checks for stream, if it is null then it checks down stream
                //Depreciated?
                if(nStream == null)
                {
                    nStream = tcpClient.GetStream();
                    writer = new BinaryWriter(nStream);
                    Stream = new BinaryFormatter();
                    if (nStream == null)
                        continue;
                }
                object o = Stream.Deserialize(nStream);

                switch (o)
                {
                    //Passes the Standard up a level for processing (keeps this class clean)
                    case File_Standard _:
                        FileIncoming((File_Standard)o);
                        break;
                        //Assigns the Helpee Control and ties the delegate
                    case Control_Data c:
                        //Checks for empty control
                        if(Allowed_Control == null)
                            Allowed_Control = new User_Control(c);
                        else
                        {
                            //instead of comparing we just check if they're true (Slightly faster?)
                            if (c.KeyBoard)
                                Allowed_Control.KeyBoard = true;
                            if (c.Mouse)
                                Allowed_Control.Mouse = true;

                            //Checks against the timers runtime
                            if (Allowed_Control.Timer_Time != c.Timer_Time)
                                Allowed_Control.Timer_Time = c.Timer_Time;
                        }
                        if (Allowed_Control.Use_Timer)
                        {
                            //Assigns delegate and restarts internal timer
                            Allowed_Control.TimerComplete += Allowed_Control_ControlRevoke;
                            Allowed_Control.Restart_Timer();
                        }
                        break;
                    case Image img:
                        UpdatePicture(img);
                        break;

                        //UNIMPLEMENTED IDEA
                    case byte[] _:

                        break;
                        //UNIMPLEMENTED IDEA
                    case string _:

                        break;

                    default:
                        //Better than a crash/Error?
                        break;
                }
            }
        }

        /// <summary>
        /// Sends an object to the sender to be processed
        /// </summary>
        /// <param name="package"></param>
        public void Send_To_Helpee(object package)
        {
            //Checks if there might be a problem
            //Depreciated?
            if (package == null || writer == null)
                return;

            IFormatter stream = new BinaryFormatter();
            stream.Serialize(writer.BaseStream, package);
        }

        /// <summary>
        /// notifies the helper that the control has been revoked
        /// </summary>
        /// <param name="new_Control"></param>
        private void Allowed_Control_ControlRevoke(User_Control new_Control)
        {
            //Sets the new control information
            Allowed_Control = new_Control;
            //passes it up to the form
            Rekoved_Control();
        }
    }
}
