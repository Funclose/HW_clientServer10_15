using System.Data.Common;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
     class Program
    {
        static async Task Main(string[] args)
        {
            StartServer();
        }

        public static void StartServer()
        {

            IPAddress ipAddres = IPAddress.Parse("127.0.0.1");
            int port = 4444;
            TcpListener tcpListener = new TcpListener(ipAddres, port);
            try
            {
                tcpListener.Start();
                while (true)
                {
                    TcpClient client = tcpListener.AcceptTcpClient();
                    Console.WriteLine("новый клиекнт подключен");
                    NetworkStream stream = client.GetStream();
                    string currentime = DateTime.Now.ToString();
                    byte[] data = Encoding.ASCII.GetBytes(currentime);
                    stream.Write(data, 0, data.Length);

                    Console.WriteLine("время с сервера " + currentime);

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ошибка с сервера: " + ex.Message);
            }
            finally
            {
                tcpListener.Stop();
            }
        }



    }
}
