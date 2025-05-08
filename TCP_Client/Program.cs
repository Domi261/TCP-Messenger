using SuperSimpleTcp;
using System;
using System.Text;

class Program
{
    static void Main()
    {
        var client = new SimpleTcpClient("127.0.0.1:9000");

        client.Events.Connected += (s, e) =>
            Console.WriteLine("✔ Verbunden mit Server.");

        client.Events.Disconnected += (s, e) =>
            Console.WriteLine("✖ Verbindung getrennt.");

        client.Events.DataReceived += (s, e) =>
        {
            string msg = Encoding.UTF8.GetString(e.Data);
            Console.WriteLine($"[Server] {msg}");
        };

        client.Connect();

        while (true)
        {
            Console.Write("Du> ");
            string input = Console.ReadLine();
            if (input?.ToLower() == "exit") break;

            client.Send(input);
        }

        client.Disconnect();
    }
}
