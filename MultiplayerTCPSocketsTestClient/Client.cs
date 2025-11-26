using System.Net.Sockets;
using System.Text;

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

Console.Write("Enter ip to connect (empty for localhost): ");
string? Ip = Console.ReadLine();
if(string.IsNullOrWhiteSpace(Ip))
{
    Console.WriteLine("Ip will be localhost");
    Ip = "localhost";
}

Console.Write("Enter port : ");
string? InputPort = Console.ReadLine();
if (string.IsNullOrWhiteSpace(InputPort))
{
    Console.WriteLine("Port is empty");
    Environment.Exit(1);
}
if(!InputPort.All(char.IsDigit))
{
    Console.WriteLine("Invalid port, only digits");
    Environment.Exit(1);
}
int Port = Convert.ToInt16(InputPort);

var msg = "awsdfasdfasdf";
try
{
    await socket.ConnectAsync(Ip, Port);
    Console.WriteLine($"Connected to {socket.RemoteEndPoint}");
    while(true)
    {
        byte[] msgBytes = Encoding.UTF8.GetBytes(msg);
        
        await socket.SendAsync(msgBytes);
        Console.WriteLine("message was sended");
    }
}
catch (SocketException)
{
    Console.WriteLine($"Cannot connect to ({socket.RemoteEndPoint})");
}