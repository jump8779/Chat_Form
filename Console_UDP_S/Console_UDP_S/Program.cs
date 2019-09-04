using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;

namespace Console_UDP_S
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8000;
            try
            {
                UdpClient udpS = new UdpClient(port);
                Console.WriteLine("연결할 클라이언트를 기다리고 있습니다.");
                Console.WriteLine("끝내려면 <Ctrl+C>를 누르십시오.");

                while (true)
                {
                    IPAddress ipAd = IPAddress.Any;
                    IPEndPoint recPoint = new IPEndPoint(ipAd, port);
                    Byte[] byteRec = udpS.Receive(ref recPoint);
                    String strRec = Encoding.Default.GetString(byteRec);
                    Console.WriteLine("[수신]:" + strRec);
                    String strSend = DateTime.Now.ToString();
                    Byte[] byteSend = Encoding.Default.GetBytes(strSend);
                    udpS.Send(byteSend, byteSend.Length, recPoint);
                }
            }
            catch(SocketException ex)
            {
                if(ex.ErrorCode == 10048)
                {
                    Console.WriteLine("이 포트에 연결하지 못했습니다. \n" +
                        "다른 서버가 이 포트를 사용 중 입니다.");
                }
            }
        }
    }
}
