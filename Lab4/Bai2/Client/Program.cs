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
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", PORT_NUMBER);
            Stream stream = client.GetStream();
            Console.WriteLine("\t\t\tCLIENT");
            Console.WriteLine("Connected to Server.");

            while (true)
            {
                Console.Write("Client says: ");
                string msg = Console.ReadLine();
                if (msg.ToUpper().CompareTo("EXIT") == 0)
                {
                    break;
                }
                byte[] data = encoding.GetBytes("Client says: " + msg);
                stream.Write(data, 0, data.Length);
                data = new byte[BUFFER_SIZE];
                int soByte = stream.Read(data, 0, BUFFER_SIZE);
                Console.WriteLine(encoding.GetString(data, 0, soByte));
            }
            stream.Close();
            client.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
}