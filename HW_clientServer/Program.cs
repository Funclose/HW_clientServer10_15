using System.Net.Sockets;
using System.Text;

namespace HW_clientServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectToServer();
            Console.ReadLine();
        }
        static void ConnectToServer()
        {
            string connect = "127.0.0.1";
            int port = 4444;
            try
            {
                byte[] data = new byte[255];
                TcpClient client = new TcpClient(connect, port);

                NetworkStream stream = client.GetStream();
                Console.WriteLine("connected to server");
                StringBuilder reasponData = new StringBuilder();
                int bytes;
                Console.WriteLine("hello from client");
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    Task.Delay(1000);
                    reasponData.Append($"Time now: {DateTime.Now}");
                }
                while (stream.DataAvailable);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex.Message);
            }
        }
    }
}
