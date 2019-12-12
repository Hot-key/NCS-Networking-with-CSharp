namespace NcsChatClient
{
    partial class FormChat
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
            this.listBoxMsgList = new System.Windows.Forms.ListBox();
            this.listBoxUserList = new System.Windows.Forms.ListBox();
            this.buttonSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxMsgList
            // 
            this.listBoxMsgList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxMsgList.FormattingEnabled = true;
            this.listBoxMsgList.IntegralHeight = false;
            this.listBoxMsgList.ItemHeight = 12;
            this.listBoxMsgList.Location = new System.Drawing.Point(12, 12);
            this.listBoxMsgList.Name = "listBoxMsgList";
            this.listBoxMsgList.Size = new System.Drawing.Size(587, 346);
            this.listBoxMsgList.TabIndex = 0;
            // 
            // listBoxUserList
            // 
            this.listBoxUserList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxUserList.FormattingEnabled = true;
            this.listBoxUserList.IntegralHeight = false;
            this.listBoxUserList.ItemHeight = 12;
            this.listBoxUserList.Location = new System.Drawing.Point(604, 12);
            this.listBoxUserList.Name = "listBoxUserList";
            this.listBoxUserList.Size = new System.Drawing.Size(111, 346);
            this.listBoxUserList.TabIndex = 1;
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(604, 363);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(111, 22);
            this.buttonSend.TabIndex = 2;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 364);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(587, 21);
            this.textBox1.TabIndex = 3;
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 395);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.listBoxUserList);
            this.Controls.Add(this.listBoxMsgList);
            this.Name = "FormChat";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMsgList;
        private System.Windows.Forms.ListBox listBoxUserList;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBox1;
    }
}