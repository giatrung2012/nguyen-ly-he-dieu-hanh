using System.Collections;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    public static Hashtable clientsList = new Hashtable();

    private static void Main(string[] args)
    {
        //tao serverSocket lang nghe ket noi tu client tren port 8888
        TcpListener serverSocket = new TcpListener(8888);
        TcpClient clientSocket = default;
        int counter = 0;
        serverSocket.Start();
        Console.WriteLine("Chat Server Started ....");
        counter = 0;
        while ((true))
        {
            counter += 1;
            //Lang nghe ket noi tu server => clientSocket
            clientSocket = serverSocket.AcceptTcpClient();
            //Du lieu tu client
            byte[] bytesFrom = new byte[65536];
            //Ten user
            string dataFromClient = null;
            //Doc thong diep connect tu client
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
            //Covert byte[] sang string dang UTF8Encoding
            dataFromClient = Encoding.ASCII.GetString(bytesFrom);
            //Get UserName tu client
            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
            //Add socket and Username vao clientsList
            clientsList.Add(dataFromClient, clientSocket);
            //Gui thong diep connect den tat ca client
            broadcast(dataFromClient + " Joined ", dataFromClient, false);
            Console.WriteLine(dataFromClient + " Joined chat room ");
            //Class handleClient xu ly lang nghe thong diep tu chat client
            handleClient client = new handleClient();
            client.startClient(clientSocket, dataFromClient, clientsList);
        }
        clientSocket.Close();
        serverSocket.Stop();
        Console.WriteLine("exit");
        Console.ReadLine();
    }

    //Phương thức broadcast thực hiện gửi msg từ uName đến tất cả client qua socket tuong ung
    //với flag = flase la Join lan dau , flag = true la gui thong diep chat
    public static void broadcast(string msg, string uName, bool flag)
    {
        foreach (DictionaryEntry Item in clientsList)
        {
            TcpClient broadcastSocket = (TcpClient)Item.Value;
            NetworkStream broadcastStream = broadcastSocket.GetStream();
            Byte[] broadcastBytes = null;
            if (flag == true)
            {
                //Covert msg chat sang byte[]
                broadcastBytes = Encoding.ASCII.GetBytes(uName + " says : " + msg);
            }
            else
            {
                //Covert msg connect lan dau sang byte[]
                broadcastBytes = Encoding.ASCII.GetBytes(msg);
            }
            //Send thong dep den client tuong ung socket
            broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);
            //xoa bo dem Stream
            broadcastStream.Flush();
        }
    } //end broadcast function
}

public class handleClient
{
    TcpClient clientSocket;//Socket tuong ung
    string clNo;//Ten UserName
    Hashtable clientsList; // Danh sach socket ket noi
    public void startClient(TcpClient inClientSocket, string userName, Hashtable cList)
    {
        clientSocket = inClientSocket;
        clNo = userName;
        clientsList = cList;
        Thread ctThread = new Thread(doChat);
        ctThread.Start();
    }
    private void doChat()
    {
        int requestCount = 0;
        byte[] bytesFrom = new byte[65536];
        string dataFromClient = null;
        string rCount = null;
        requestCount = 0;
        while ((true))
        {
            try
            {
                //Nhan thong diep chat tu client
                NetworkStream networkStream = clientSocket.GetStream();
                networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                //Covert byte[] sang string UTF8Encoding
                dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
                rCount = Convert.ToString(requestCount);
                //Gui thong diep chat tu client den tat ca cac client con lai qua socket
                Program.broadcast(dataFromClient, clNo, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }//end while
    }//end doChat
} //end class handleClinet
