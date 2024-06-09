using Chat;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SentMessage(args[0], args[1]);
        }
        public static void SentMessage(string from, string ip)
        {
            UdpClient udpClient = new UdpClient();
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ip), 12345);


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
                Message message = new Message() { Text = messageText, NicknameFrom = from, NicknameTo = "Server", DateTime = DateTime.Now };
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
