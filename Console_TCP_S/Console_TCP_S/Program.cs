using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace Console_TCP_S
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8000;
            try
            {
                TcpListener msgListen = new TcpListener(port);
                msgListen.Start();

                Console.WriteLine("연결할 클라이언트를 기다리고 있습니다.");
                Console.WriteLine("끝내려면 <Ctrl+C>를 누르십시오.");

                while(true)
                {
                    Socket s = msgListen.AcceptSocket();
                    NetworkStream msgNts = new NetworkStream(s);
                    String sMsg = DateTime.Now.ToString();
                    Byte[] sByte = Encoding.Default.GetBytes(sMsg);
                    msgNts.Write(sByte, 0, sByte.Length);
                    msgNts.Flush();

                    msgNts.Close();
                    s.Close();
                }
            }
            catch(SocketException ex)
            {
                if(ex.ErrorCode == 10048)
                {
                    Console.WriteLine("이 포트에 연결하지 못했습니다. \n" +
                        "다른 서버가 이 포트를 사용 중입니다.");
                }
            }
        }
    }
}
