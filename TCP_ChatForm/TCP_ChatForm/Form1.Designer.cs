namespace TCP_ChatForm
{
    partial class Server_Form
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
            this.server_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chatlog_tbox
            // 
            this.chatlog_tbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatlog_tbox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.chatlog_tbox.Location = new System.Drawing.Point(13, 13);
            this.chatlog_tbox.Multiline = true;
            this.chatlog_tbox.Name = "chatlog_tbox";
            this.chatlog_tbox.ReadOnly = true;
            this.chatlog_tbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.chatlog_tbox.Size = new System.Drawing.Size(662, 440);
            this.chatlog_tbox.TabIndex = 0;
            // 
            // msg_tbox
            // 
            this.msg_tbox.Font = new System.Drawing.Font("굴림", 11F);
            this.msg_tbox.Location = new System.Drawing.Point(12, 476);
            this.msg_tbox.Name = "msg_tbox";
            this.msg_tbox.Size = new System.Drawing.Size(587, 29);
            this.msg_tbox.TabIndex = 1;
            // 
            // send_bt
            // 
            this.send_bt.Location = new System.Drawing.Point(606, 476);
            this.send_bt.Name = "send_bt";
            this.send_bt.Size = new System.Drawing.Size(69, 29);
            this.send_bt.TabIndex = 2;
            this.send_bt.Text = "전송";
            this.send_bt.UseVisualStyleBackColor = true;
            // 
            // server_bt
            // 
            this.server_bt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.server_bt.Font = new System.Drawing.Font("굴림", 11F);
            this.server_bt.Location = new System.Drawing.Point(266, 521);
            this.server_bt.Name = "server_bt";
            this.server_bt.Size = new System.Drawing.Size(138, 37);
            this.server_bt.TabIndex = 3;
            this.server_bt.Text = "서버 시작";
            this.server_bt.UseVisualStyleBackColor = true;
            // 
            // Server_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 579);
            this.Controls.Add(this.server_bt);
            this.Controls.Add(this.send_bt);
            this.Controls.Add(this.msg_tbox);
            this.Controls.Add(this.chatlog_tbox);
            this.Name = "Server_Form";
            this.Text = "서버";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chatlog_tbox;
        private System.Windows.Forms.TextBox msg_tbox;
        private System.Windows.Forms.Button send_bt;
        private System.Windows.Forms.Button server_bt;
    }
}

