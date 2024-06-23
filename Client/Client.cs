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
        private IPEndPoint _iPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
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


            while (true)
            {
                Console.InputEncoding = System.Text.Encoding.GetEncoding("UTF-16");
                string messageText;
                string nicknameTo = "All";
                do
                {
                    //Console.Clear();
                    Console.WriteLine("Введите сообщение");
                    messageText = Console.ReadLine();
                    Console.WriteLine("Введите получателя");
                    nicknameTo = Console.ReadLine();
                }
                while (string.IsNullOrEmpty(messageText));
                if (messageText == "Exit")
                    Environment.Exit(0);
                Message message = new Message() { Text = messageText, NicknameFrom = _user, NicknameTo = nicknameTo, DateTime = DateTime.Now };
                string json = message.SerializeMessageToJson();

                byte[] data = Encoding.UTF8.GetBytes(json);
                udpClient.Send(data, data.Length, _iPEndPoint);

                byte[] buffer = udpClient.Receive(ref _iPEndPoint);
                var answer = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(answer);
            }
        }
    }
}
