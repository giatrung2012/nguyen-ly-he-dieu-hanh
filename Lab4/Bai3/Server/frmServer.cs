using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class frmServer : Form
    {
        IPEndPoint IP;
        Socket server, client;
        List<Socket> clientList;
        private string msg;
        MemoryStream stream;
        BinaryFormatter formatter;
        Thread listen, receive;

        public frmServer()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
            ActiveControl = txtMessage;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMessage("Server: " + txtMessage.Text);
            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);
            listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        client = server.Accept();
                        clientList.Add(client);
                        receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });
            listen.IsBackground = true;
            listen.Start();
        }

        private void Close()
        {
            server.Close();
        }

        private void Send(Socket client)
        {
            if (client != null && txtMessage.Text != string.Empty)
                client.Send(Serialize("Server: " + txtMessage.Text));
        }

        private void Receive(object obj)
        {
            client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    msg = (string)Deserialize(data);
                    foreach (Socket item in clientList)
                    {
                        if (item != null && item != client)
                            item.Send(Serialize(msg));
                    }
                    AddMessage(msg);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        private void AddMessage(string s)
        {
            lsvMessage.Items.Add(new ListViewItem() { Text = s });
        }

        byte[] Serialize(object obj)
        {
            stream = new MemoryStream();
            formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        private void frmServer_Load(object sender, EventArgs e)
        {
            txtMessage.Focus();
        }

        object Deserialize(byte[] data)
        {
            stream = new MemoryStream(data);
            formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
