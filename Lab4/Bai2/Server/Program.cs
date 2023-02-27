using System.Net;
using System.Net.Sockets;
using System.Text;

internal class Program
{
    private const int BUFFER_SIZE = 1024;
    private const int PORT_NUMBER = 9999;
    static ASCIIEncoding encoding = new ASCIIEncoding();

    private static void Main(string[] args)
    {
        try
        {
            IPAddress address = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(address, PORT_NUMBER);
            listener.Start();
            Console.WriteLine("\t\t\tSERVER STARTED ON " + listener.LocalEndpoint);
            Console.WriteLine("Waiting for a connection...");

            Socket socket = listener.AcceptSocket();
            Console.WriteLine("Connection received from " + socket.RemoteEndPoint);

            while (true)
            {
                byte[] data = new byte[BUFFER_SIZE];
                int soByte = socket.Receive(data);
                Console.WriteLine(encoding.GetString(data, 0, soByte));
                Console.Write("Server says: ");
                string msg = Console.ReadLine();
                if (msg.ToUpper().CompareTo("EXIT") == 0)
                {
                    break;
                }
                socket.Send(encoding.GetBytes("Server says: " + msg));
            }
            socket.Close();
            listener.Stop();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
}