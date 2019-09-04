using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//네트워크 통신 네임스페이스 지정
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
                //지정된 포트 값을 매개변수로 받아 TcpListener 객체 생성
                TcpListener msgListen = new TcpListener(port);
                //클라이언트 연결 대기 시작
                msgListen.Start();

                Console.WriteLine("연결할 클라이언트를 기다리고 있습니다.");
                Console.WriteLine("끝내려면 <Ctrl+C>를 누르십시오.");

                while(true)
                {
                    //클라이언트의 접속 처리
                    //접속이 있을 때까지 블록 상태, 접속 시 서버 소켓을 반환
                    Socket s = msgListen.AcceptSocket();

                    //연결 성공 시 지정된 소켓에 대해 데이터 송수신을 위한 네트워크 스트림 생성
                    NetworkStream msgNts = new NetworkStream(s);
                    String sMsg = DateTime.Now.ToString();

                    //문자열을 바이트 배열로 인코딩
                    Byte[] sByte = Encoding.Default.GetBytes(sMsg);

                    //스트림에 데이터를 입력
                    //(스트림에 쓸 바이트 배열, 데이터를 쓰기 시작할 배열 내의 위치, 스트림에 쓸 바이트 수)
                    msgNts.Write(sByte, 0, sByte.Length);

                    //버퍼의 내용을 즉시 전송
                    msgNts.Flush();

                    //연결 종료
                    msgNts.Close();
                    s.Close();
                }
            }
            catch(SocketException ex)
            {
                //포트 사용중일 시 예외처리
                if(ex.ErrorCode == 10048)
                {
                    Console.WriteLine("이 포트에 연결하지 못했습니다. \n" +
                        "다른 서버가 이 포트를 사용 중입니다.");
                }
            }
        }
    }
}
