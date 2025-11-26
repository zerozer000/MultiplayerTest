using System.Net;
using System.Net.Sockets;
using System.Text;

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


using Socket client = await socket.AcceptAsync();


Console.WriteLine($"Client connected: {client.RemoteEndPoint}");

while (true)
{
    List<byte> response = [];
    byte[] buffer = new byte[512];
    int bytes = 0;
    do
    {
        bytes = await client.ReceiveAsync(buffer);
        response.AddRange(buffer.Take(bytes));
    }
    while (bytes > 0);
    var responseText = Encoding.UTF8.GetString(response.ToArray());
    Console.WriteLine(responseText);
    Console.WriteLine("sex");
}

