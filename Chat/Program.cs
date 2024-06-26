﻿using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Server("Server");
        }
        public static void Server(string name)
        {
            UdpClient udpClient = new UdpClient(12345);
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 0);
            new Thread(()  => 
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
