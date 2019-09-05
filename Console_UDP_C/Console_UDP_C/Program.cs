using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//네임스페이스 지정
using System.Net;
using System.Net.Sockets;

namespace Console_UDP_C
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UdpClient udpC = new UdpClient(8001);
                Boolean bTag = true;

                while (bTag)
                {
                    IPAddress ipAd = IPAddress.Any;
                    String strSend = "서버의 시간";
                    Byte[] byteSend = Encoding.Default.GetBytes(strSend);
                    //데이터 그램 전송
                    //TCP 프로토콜과는 달리 Connect() 메서드의 호출 없이
                    //목적지를 정한 뒤 바로 전송
                    udpC.Send(byteSend, byteSend.Length, "localhost", 8000);
                    IPEndPoint recPoint = new IPEndPoint(ipAd, 8000);
                    //데이터 수신
                    Byte[] byteRec = udpC.Receive(ref recPoint);
                    String strRec = Encoding.Default.GetString(byteRec);
                    Console.WriteLine("현재 날짜 및 시간:{0}", strRec);

                    //연결 종료
                    udpC.Close();
                    bTag = false;
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
