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
            Client client = new Client("Vladimir", "128.0.0.1:12345");
            client.SentMessage();
        }
    }
}
