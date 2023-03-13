using System.IO.Pipes;

internal class Program
{
    private static void Main(string[] args)
    {
        var server = new NamedPipeServerStream("PipesOfPiece");
        Console.WriteLine("--------------SERVER------------");
        server.WaitForConnection();
        Console.WriteLine("Server waiting connect.");
        Console.WriteLine("Server connected to client!");
        StreamReader reader = new StreamReader(server);
        StreamWriter writer = new StreamWriter(server);
        while (true)
        {
            Console.WriteLine("Client:" + reader.ReadLine());
            Console.Write("Server:");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) break;
            writer.WriteLine(input);
            writer.Flush();
        }
    }
}


