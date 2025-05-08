using SuperSimpleTcp;
using System;
using System.Text;

class Program
{
    static void Main()
    {
        var server = new SimpleTcpServer("127.0.0.1:9000");

        server.Events.ClientConnected += (s, e) =>
            Console.WriteLine($"[+] Verbunden: {e.IpPort}");

        server.Events.ClientDisconnected += (s, e) =>
            Console.WriteLine($"[-] Getrennt: {e.IpPort}");

        server.Events.DataReceived += (s, e) =>
        {
            string msg = Encoding.UTF8.GetString(e.Data);
            Console.WriteLine($"[{e.IpPort}] {msg}");

            // Nachricht an alle Clients zurücksenden
            foreach (var client in server.GetClients())
            {
                server.Send(client, $"[{e.IpPort}] {msg}");
            }
        };


        server.Start();
        Console.WriteLine("✅ Server läuft auf 127.0.0.1:9000");

        while (true)
        {
            Console.Write("Server> ");
            string input = Console.ReadLine();
            if (input?.ToLower() == "exit") break;

            foreach (var client in server.GetClients())
                server.Send(client, input);
        }

        server.Stop();
    }
}
