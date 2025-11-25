using System.Net;
using System.Net.Sockets;

Console.Write("Enter port : ");
string? InputPort = Console.ReadLine();
if (InputPort == "")
{
    Console.Write("Null port");
    Environment.Exit(1);
}
int Port = Convert.ToInt16(InputPort);

IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, Port);
using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(ipPoint);
socket.Listen();
Console.WriteLine("Server started waiting for connections");
// получаем входящее подключение
using Socket client = await socket.AcceptAsync();
// получаем адрес клиента
Console.WriteLine($"Client connected: {client.RemoteEndPoint}");