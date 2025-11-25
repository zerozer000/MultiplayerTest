using System.Net.Sockets;

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

Console.Write("Enter ip to connect (empty for localhost): ");
string? Ip = Console.ReadLine();
if(Ip == "")
{
    Console.Write("Ip will be localhost");
    Ip = "localhost";
}
if (Ip == null)
{
    Console.Write("Ip will be localhost");
    Ip = "localhost";
}

Console.Write("Enter port : ");
string? InputPort = Console.ReadLine();
if (InputPort == "")
{
    Console.Write("Null port");
    Environment.Exit(1);
}
int Port = Convert.ToInt16(InputPort);

try
{
    await socket.ConnectAsync(Ip, Port);
    Console.WriteLine($"Connected to {socket.RemoteEndPoint}");
}
catch (SocketException)
{
    Console.WriteLine($"Cannot connect to ({socket.RemoteEndPoint})");
}