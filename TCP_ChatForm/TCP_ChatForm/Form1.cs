using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP_ChatForm
{
    public partial class Server_Form : Form
    {
        public Server_Form()
        {
            InitializeComponent();
        }
        
        public enum Protocol
        {
            Connecte = 1000, //연결요구
            DisConnecte = 2000, //연결 해제 요구
            Message = 3000 //일반 메시지
        }

        private TcpListener sListen;
        private Boolean bService = false; //서비스 시작/종료 플래그
        private Boolean IsConnected = false; //클라이언트와의 연결 상태
        private NetworkStream sNts;
        private Thread ServerTh; //클라이언트 연결 대기 스레드
        private Thread ReadTh; //수신 스레드

        private void StartListen()
        {
            try
            {
                sListen = new TcpListener(8001);
                sListen.Start();
                chatlog_tbox.Text = "서버가 시작했습니다.";
                bService = true;
            }
            catch
            {
                MessageBox.Show("서버 시작 도중 오류가 발생했습니다.");
            }

            while (bService) // 서버 시작되면
            {
                Socket s = sListen.AcceptSocket();
                if (s.Connected) // 클라이언트 연결 되면
                {
                    IsConnected = true;
                    sNts = new NetworkStream(s);
                    ReadTh = new Thread(new ThreadStart(Receive));
                    ReadTh.Start();
                }
            }
        }

        // 클라이언트로부터 전송된 데이터 수신
        private void Receive()
        {
            Byte[] Buffer = new Byte[1024];
            String Temp;
            String[] msg;
            char c = '|';
            try
            {
                while (IsConnected) // 클라이언트 연결되어 있는 동안
                {
                    sNts.Read(Buffer, 0, Buffer.Length);
                    Temp = Encoding.Default.GetString(Buffer);
                    msg = Temp.Split(c);

                    switch (Convert.ChangeType(msg[0], Protocol.Connecte.GetType()))
                    {
                        case Protocol.Connecte: // 연결 요청
                            Temp = (msg[1].Trim() + "님이 접속했습니다.\n");
                            chatlog_tbox.Text += "Temp";
                            break;
                        case Protocol.Message: // 일반 메시지 수신
                            chatlog_tbox.Text += msg[1].ToString() + "\n";
                            break;
                        case Protocol.DisConnecte: // 연결 해제 요청
                            Temp = msg[1] + "님이 접속 해제했습니다.\n";
                            chatlog_tbox.Text += Temp;
                            break;
                    }
                    Array.Clear(Buffer, 0, Buffer.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("데이터 수신 중 오류");
            }
        }

        // 서버 연결 중지
        private void ServerStop()
        {
            if (bService)
            {
                sListen.Stop();
                ServerTh.Abort();
                bService = false;
            }
            chatlog_tbox.Text += "서버가 중지되었습니다.";
        }

        // 서버 소켓 연결 끊기
        private void Disconnect()
        {
            if (!IsConnected) return;

            IsConnected = false;
            sNts.Close();
            ReadTh.Abort();
        }

        private void SendMsg(String msg)
        {
            try
            {
                Byte[] byteSend = Encoding.Default.GetBytes(msg.ToCharArray());
                sNts.Write(byteSend, 0, byteSend.Length);
                sNts.Flush();
            }
            catch
            {
                MessageBox.Show("데이터 전송 실패");
            }
        }
        private void Server_bt_Click(object sender, EventArgs e)
        {
            if(server_bt.Text == "서버 시작")
            {
                ServerTh = new Thread(new ThreadStart(StartListen));
                ServerTh.Start();
                server_bt.Text = "서버 멈춤";
            }
            else
            {
                ServerStop();
                server_bt.Text = "서버 시작";
            }
        }

        private void Send_bt_Click(object sender, EventArgs e)
        {
            if(msg_tbox.Text != "")
            {
                String msg = Protocol.Message + "|[server]" + msg_tbox.Text + "|END";
                SendMsg(msg);
                msg = "[server]" + msg_tbox.Text + "\n";
                chatlog_tbox.Text += msg;
                msg_tbox.Text = "";
            }
        }

        private void Server_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
            Disconnect();
        }
    }
}
