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

namespace TCP_ChatForm_C
{
    public partial class Client_Form : Form
    {
        public Client_Form()
        {
            InitializeComponent();
        }

        private enum Protocol
        {
            Connecte = 1000,
            DisConnecte = 2000,
            Message =3000
        }

        private TcpClient cSocket;
        private NetworkStream cNts;
        private Boolean IsConnected = false;
        private Thread ReadTh;

        private void SendMsg(String msg)
        {
            try
            {
                Byte[] byteSend = Encoding.Default.GetBytes(msg.ToCharArray());
                cNts.Write(byteSend, 0, byteSend.Length);
                cNts.Flush();
            }
            catch
            {
                MessageBox.Show("데이터 전송 실패");
            }
        }

        private void Disconnect()
        {
            if (IsConnected == false) return;
            SendMsg(Protocol.DisConnecte + "|홍길동|END");
            MessageBox.Show("서버 연결 해제");
            IsConnected = false;

            cNts.Close();
            cSocket.Close();
            ReadTh.Abort();
            connect_bt.Text = "서버 연결";
        }

        private void Receive()
        {
            Byte[] Buffer = new Byte[1024];
            char c = '|';
            String[] msg;
            String Temp;

            try
            {
                while (IsConnected)
                {
                    cNts.Read(Buffer, 0, Buffer.Length);
                    Temp = Encoding.Default.GetString(Buffer);
                    msg = Temp.Split(c);

                    if(msg[0] == Protocol.Message.ToString())
                    {
                        chatlog_tbox.Text += msg[1] + "\r\n";
                    }
                    Array.Clear(Buffer, 0, Buffer.Length);
                }
            }
            catch
            {
                MessageBox.Show("데이터 수신 오류");
            }
            Disconnect();
        }

        private void Send_bt_Click(object sender, EventArgs e)
        {
            if(msg_tbox.Text != "")
            {
                String msg = Protocol.Message + "|[client]" + msg_tbox.Text + "|END";
                SendMsg(msg);
                msg = "[client]" + msg_tbox.Text + "\r\n";
                chatlog_tbox.Text += msg;
                msg_tbox.Text = "";
            }
        }

        private void Connect_bt_Click(object sender, EventArgs e)
        {
            if(connect_bt.Text == "서버 연결")
            {
                try
                {
                    cSocket = new TcpClient();
                    cSocket.Connect("localhost", 8001);
                    chatlog_tbox.Text += "서버 연결에 성공했습니다.\r\n";
                    IsConnected = true;
                }
                catch
                {
                    MessageBox.Show("서버 연결에 실패했습니다.");
                    return;
                }
                cNts = cSocket.GetStream();
                SendMsg(Protocol.Connecte + "|홍길동|END");
                ReadTh = new Thread(new ThreadStart(Receive));
                ReadTh.Start();
                connect_bt.Text = "연결 해제";
            }
            else
            {
                Disconnect();
            }
        }

        private void Client_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }
    }
}
