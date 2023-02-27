using System.IO.Pipes;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("------------CLIENT--------------");
        var client = new NamedPipeClientStream("PipesOfPiece");
        Console.WriteLine("Client waiting connnect...");
        client.Connect();
        Console.WriteLine("Client connected to server!");
        StreamReader reader = new StreamReader(client);
        StreamWriter writer = new StreamWriter(client);
        while (true)
        {
            Console.Write("Client:");
            string input = Console.ReadLine();
            if (String.IsNullOrEmpty(input)) break;
            writer.WriteLine(input);
            writer.Flush();
            Console.WriteLine("Server: " + reader.ReadLine());
        }
    }
}