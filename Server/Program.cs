namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = Task.Run(() => UDPServer.Start());
            Task.WaitAll(t);
        }
    }
}
