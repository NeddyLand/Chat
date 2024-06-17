using System.Net.Sockets;
using System.Net;
using System.Text;
using Server;

namespace Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UDPServer.Start();
        }
    }
}
