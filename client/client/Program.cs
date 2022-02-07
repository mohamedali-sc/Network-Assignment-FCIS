using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IPAddress h = IPAddress.Parse("127.0.0.1");
            IPEndPoint hostEndpoint = new IPEndPoint(h, 8000);
            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            clientSock.Connect(hostEndpoint);

            byte[] recivedata = new byte[1024];
            int recivedbytelen = clientSock.Receive(recivedata);
            string filedata = "";
            filedata = Encoding.ASCII.GetString(recivedata, 0, recivedbytelen);
            
            Console.WriteLine("Server Said: {0}", filedata);
            Console.WriteLine("Conversation Ended");
            clientSock.Shutdown(SocketShutdown.Both);
            clientSock.Close();






        }
    }
}
