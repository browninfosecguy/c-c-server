using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace tcpReceive
{
    public class tcpserver
    {
       
        public static void Main()
        {
            IPAddress ipad = IPAddress.Parse("127.0.0.1");
            Int32 prt = 4444;
            TcpListener tl = new TcpListener(ipad, prt);
            tl.Start();

            TcpClient tc = tl.AcceptTcpClient();

            NetworkStream ns = tc.GetStream();
            StreamReader sr = new StreamReader(ns);

            string result = sr.ReadToEnd();

            string path = @"c:\MyTest.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    
                    sw.Write(result);
                }
                
            }
                tc.Close();
            tl.Stop();
        }
    }
}