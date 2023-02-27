using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            ActiveControl = txtMessage;
        }

        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default;
        string readData = null;
        private void frmClient_Load(object sender, EventArgs e)
        {
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            readData = "Conected to Chat Server ...";
            msg();
            clientSocket.Connect("127.0.0.1", 8888);
            serverStream = clientSocket.GetStream();
            //Tao thong diep join
            byte[] outStream = Encoding.ASCII.GetBytes(txtUsername.Text + "$");
            //Gui thong diep
            serverStream.Write(outStream, 0, outStream.Length);
            //Xoa bo dem
            serverStream.Flush();
            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
        }
        private void getMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = clientSocket.ReceiveBufferSize;
                byte[] inStream = new byte[65536];
                serverStream.Read(inStream, 0, buffSize);
                readData = Encoding.ASCII.GetString(inStream);
                msg();
            }
        }
        private void msg()
        {
            //Xu truy cap lsvMessage tu Thread getMessage
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                lsvMessage.Text = lsvMessage.Text + Environment.NewLine + " >> " + readData;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] outStream = Encoding.ASCII.GetBytes(txtMessage.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
    }
}
