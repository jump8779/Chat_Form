using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                TcpClient msgTcpc = new TcpClient();
                msgTcpc.Connect("localhost", 8000);

                NetworkStream cNts = msgTcpc.GetStream();
                Byte[] byteReceive = new Byte[128];
                int i = cNts.Read(byteReceive, 0, 128);
                String strReceive = Encoding.Default.GetString(byteReceive);
                Console.WriteLine("{0}바이트를 받았습니다.", i);
                Console.WriteLine("현재 날짜 및 시간 : {0}", strReceive);

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
