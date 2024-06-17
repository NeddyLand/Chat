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
    static class UDPServer
    {
        public static void Start()
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            new Thread(() =>
            {
                Console.WriteLine("Сервер ждет сообщение от клиента");
                Console.WriteLine("Нажмите ENTER для завершения.");
                Console.ReadLine();
                Environment.Exit(0);
            }
                ).Start();

            while (true)
            {
                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var messageText = Encoding.UTF8.GetString(buffer);

                Message message = Message.DeserializeFromJson(messageText);
                message.Print();

                byte[] reply = Encoding.UTF8.GetBytes("Сообщение получено");
                udpClient.Send(reply, reply.Length, iPEndPoint);
            }
        }
    }
}
