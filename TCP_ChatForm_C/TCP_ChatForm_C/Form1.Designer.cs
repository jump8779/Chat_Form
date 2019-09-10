namespace TCP_ChatForm_C
{
    partial class Client_Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatlog_tbox = new System.Windows.Forms.TextBox();
            this.msg_tbox = new System.Windows.Forms.TextBox();
            this.send_bt = new System.Windows.Forms.Button();
            this.connect_bt = new System.Windows.Forms.Button();
            this.filesend_bt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // chatlog_tbox
            // 
            this.chatlog_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatlog_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chatlog_tbox.Location = new System.Drawing.Point(12, 12);
            this.chatlog_tbox.Multiline = true;
            this.chatlog_tbox.Name = "chatlog_tbox";
            this.chatlog_tbox.ReadOnly = true;
            this.chatlog_tbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatlog_tbox.Size = new System.Drawing.Size(776, 439);
            this.chatlog_tbox.TabIndex = 0;
            // 
            // msg_tbox
            // 
            this.msg_tbox.Font = new System.Drawing.Font("굴림", 11F);
            this.msg_tbox.Location = new System.Drawing.Point(13, 468);
            this.msg_tbox.Name = "msg_tbox";
            this.msg_tbox.Size = new System.Drawing.Size(698, 29);
            this.msg_tbox.TabIndex = 1;
            // 
            // send_bt
            // 
            this.send_bt.Location = new System.Drawing.Point(718, 468);
            this.send_bt.Name = "send_bt";
            this.send_bt.Size = new System.Drawing.Size(70, 29);
            this.send_bt.TabIndex = 2;
            this.send_bt.Text = "전송";
            this.send_bt.UseVisualStyleBackColor = true;
            this.send_bt.Click += new System.EventHandler(this.Send_bt_Click);
            // 
            // connect_bt
            // 
            this.connect_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connect_bt.Location = new System.Drawing.Point(267, 517);
            this.connect_bt.Name = "connect_bt";
            this.connect_bt.Size = new System.Drawing.Size(118, 48);
            this.connect_bt.TabIndex = 3;
            this.connect_bt.Text = "서버 연결";
            this.connect_bt.UseVisualStyleBackColor = true;
            this.connect_bt.Click += new System.EventHandler(this.Connect_bt_Click);
            // 
            // filesend_bt
            // 
            this.filesend_bt.Location = new System.Drawing.Point(422, 517);
            this.filesend_bt.Name = "filesend_bt";
            this.filesend_bt.Size = new System.Drawing.Size(114, 48);
            this.filesend_bt.TabIndex = 4;
            this.filesend_bt.Text = "파일 전송";
            this.filesend_bt.UseVisualStyleBackColor = true;
            this.filesend_bt.Click += new System.EventHandler(this.Filesend_bt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 577);
            this.Controls.Add(this.filesend_bt);
            this.Controls.Add(this.connect_bt);
            this.Controls.Add(this.send_bt);
            this.Controls.Add(this.msg_tbox);
            this.Controls.Add(this.chatlog_tbox);
            this.Name = "Client_Form";
            this.Text = "클라이언트";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatlog_tbox;
        private System.Windows.Forms.TextBox msg_tbox;
        private System.Windows.Forms.Button send_bt;
        private System.Windows.Forms.Button connect_bt;
        private System.Windows.Forms.Button filesend_bt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

