using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Name : Mohamed Ali Salama hassan\n");
            Console.WriteLine("ID : 20191700563\n");
            Console.WriteLine("Department : SC\n");
            Console.WriteLine("Section : 4\n");
            IPEndPoint ipaddres = new IPEndPoint(IPAddress.Any, 8000);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ipaddres);
            s.Listen(100);
            Socket clientSock = s.Accept();

            
                string filename = args[0];
                byte[] fileNameByte = Encoding.ASCII.GetBytes(filename);
                byte[] fileLength = BitConverter.GetBytes(filename.Length);
                byte[] fileData = File.ReadAllBytes(filename);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                fileLength.CopyTo(clientData, 3);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length);
                
                  
                  clientSock.Send(clientData);

                   clientSock.Close();
            
          



        }
    }
}
