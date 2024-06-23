using Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class UDPServer
    {
        public string Name { get => "Server"; }
        public Dictionary<string, IPEndPoint> Users { get; private set; }
        public void Register(string username, IPEndPoint iPEndPoint)
        {
            if (Users == null)
            {
                Users = new Dictionary<string, IPEndPoint>();
            }
            Users.Add(username, iPEndPoint);
        }
        public void Delete(string username)
        {
            Users.Remove(username);
        }
        public static void Start()
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            Task.Run(() =>
            {
                Console.WriteLine("Сервер ждет сообщение от клиента");
                Console.WriteLine("Нажмите любую клавишу для завершения.");
                Console.ReadKey();
                cancelTokenSource.Cancel();
            });
            while (!token.IsCancellationRequested)
            {
                Task.Run(() =>
                {
                    byte[] buffer = udpClient.Receive(ref iPEndPoint);
                    var messageText = Encoding.UTF8.GetString(buffer);

                    Message message = Message.DeserializeFromJson(messageText);
                    message.Print();

                    byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");
                    udpClient.Send(reply, reply.Length, iPEndPoint);
                });
            }
            cancelTokenSource.Dispose();
        }
    }
}
