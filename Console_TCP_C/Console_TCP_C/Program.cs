using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//네트워크 통신에 필요한 네임스페이스 지정
using System.Net;
using System.Net.Sockets;

namespace Console_TCP_C
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //클라이언트 소켓을 생성해 서버에 연결
                TcpClient msgTcpc = new TcpClient();
                msgTcpc.Connect("localhost", 8000);

                //네트워크 스트림을 생성해 서버로부터 데이터 수신
                NetworkStream cNts = msgTcpc.GetStream();
                Byte[] byteReceive = new Byte[128];

                //스트림에서 데이터를 읽어옴, 반환값은 스트림에서 읽은 총 바이트 수
                int i = cNts.Read(byteReceive, 0, 128);

                //바이트 배열을 문자열로 디코딩
                String strReceive = Encoding.Default.GetString(byteReceive);
                Console.WriteLine("{0}바이트를 받았습니다.", i);
                Console.WriteLine("현재 날짜 및 시간 : {0}", strReceive);

                //연결 종료
                cNts.Close();
                msgTcpc.Close();
            }
            catch(SocketException ex)
            {
                if(ex.ErrorCode == 10061)
                {
                    Console.WriteLine("서버에 연결할 수 없습니다.");
                }
            }

        }
    }
}
