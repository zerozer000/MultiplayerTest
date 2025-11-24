using System.Net;
using System.Net.Sockets;

IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, 7777);
using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(ipPoint);
socket.Listen();
Console.WriteLine("Server started waiting for connections");
// получаем входящее подключение
using Socket client = await socket.AcceptAsync();
// получаем адрес клиента
Console.WriteLine($"Client connected: {client.RemoteEndPoint}");