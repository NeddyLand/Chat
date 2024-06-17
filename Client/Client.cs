using Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace Client
{
    internal class Client
    {
        public string User {  get { return _user; } set { _user = value; } }
        public string IP { get { return _ip; } set { _ip = value; } }
        string _user;
        string _ip;
        public Client(string user, string ip) 
        { 
            _user = user;
            _ip = ip;
        }
        public void SentMessage()
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(_ip), 12345);


            while (true)
            {
                Console.InputEncoding = System.Text.Encoding.GetEncoding("UTF-16");
                string messageText;
                do
                {
                    //Console.Clear();
                    Console.WriteLine("Введите сообщение");
                    messageText = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(messageText));
                if (messageText == "Exit")
                    Environment.Exit(0);
                Message message = new Message() { Text = messageText, NicknameFrom = _user, NicknameTo = "Server", DateTime = DateTime.Now };
                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, iPEndPoint);

                byte[] buffer = udpClient.Receive(ref iPEndPoint);
                var answer = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(answer);
            }
        }
    }
}
