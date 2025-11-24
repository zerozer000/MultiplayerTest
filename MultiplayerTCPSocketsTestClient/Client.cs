using System.Net.Sockets;

using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    await socket.ConnectAsync("127.0.0.1", 7777);
    Console.WriteLine($"Connected to {socket.RemoteEndPoint}");
}
catch (SocketException)
{
    Console.WriteLine($"Cannot connect to {socket.RemoteEndPoint}");
}