namespace NcsChatClient
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonRoomJoin = new System.Windows.Forms.Button();
            this.listBoxUserList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnectServer = new System.Windows.Forms.Button();
            this.textBoxIpAddress = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxRoomName = new System.Windows.Forms.TextBox();
            this.buttonCreateRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxPw = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonNameChange = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.timerRefreshRoom = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonRoomJoin
            // 
            this.buttonRoomJoin.Location = new System.Drawing.Point(312, 131);
            this.buttonRoomJoin.Name = "buttonRoomJoin";
            this.buttonRoomJoin.Size = new System.Drawing.Size(266, 23);
            this.buttonRoomJoin.TabIndex = 13;
            this.buttonRoomJoin.Text = "접속";
            this.buttonRoomJoin.UseVisualStyleBackColor = true;
            // 
            // listBoxUserList
            // 
            this.listBoxUserList.FormattingEnabled = true;
            this.listBoxUserList.IntegralHeight = false;
            this.listBoxUserList.ItemHeight = 12;
            this.listBoxUserList.Location = new System.Drawing.Point(312, 8);
            this.listBoxUserList.Name = "listBoxUserList";
            this.listBoxUserList.Size = new System.Drawing.Size(266, 119);
            this.listBoxUserList.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(305, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 150);
            this.label1.TabIndex = 5;
            // 
            // buttonConnectServer
            // 
            this.buttonConnectServer.Location = new System.Drawing.Point(224, 7);
            this.buttonConnectServer.Name = "buttonConnectServer";
            this.buttonConnectServer.Size = new System.Drawing.Size(75, 23);
            this.buttonConnectServer.TabIndex = 3;
            this.buttonConnectServer.Text = "연결";
            this.buttonConnectServer.UseVisualStyleBackColor = true;
            this.buttonConnectServer.Click += new System.EventHandler(this.buttonConnectServer_Click);
            // 
            // textBoxIpAddress
            // 
            this.textBoxIpAddress.Location = new System.Drawing.Point(12, 8);
            this.textBoxIpAddress.Name = "textBoxIpAddress";
            this.textBoxIpAddress.Size = new System.Drawing.Size(135, 21);
            this.textBoxIpAddress.TabIndex = 1;
            this.textBoxIpAddress.Text = "127.0.0.1";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(153, 8);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(65, 21);
            this.textBoxPort.TabIndex = 2;
            this.textBoxPort.Text = "65535";
            // 
            // textBoxRoomName
            // 
            this.textBoxRoomName.Location = new System.Drawing.Point(12, 105);
            this.textBoxRoomName.Name = "textBoxRoomName";
            this.textBoxRoomName.Size = new System.Drawing.Size(206, 21);
            this.textBoxRoomName.TabIndex = 8;
            // 
            // buttonCreateRoom
            // 
            this.buttonCreateRoom.Location = new System.Drawing.Point(224, 104);
            this.buttonCreateRoom.Name = "buttonCreateRoom";
            this.buttonCreateRoom.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateRoom.TabIndex = 9;
            this.buttonCreateRoom.Text = "방 만들기";
            this.buttonCreateRoom.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 1);
            this.label2.TabIndex = 10;
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(69, 43);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(149, 21);
            this.textBoxId.TabIndex = 4;
            // 
            // textBoxPw
            // 
            this.textBoxPw.Location = new System.Drawing.Point(69, 70);
            this.textBoxPw.Name = "textBoxPw";
            this.textBoxPw.Size = new System.Drawing.Size(149, 21);
            this.textBoxPw.TabIndex = 6;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(224, 42);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "회원가입";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "아이디";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "비밀번호";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(11, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 1);
            this.label5.TabIndex = 16;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(224, 69);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 7;
            this.buttonLogin.Text = "로그인";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonNameChange
            // 
            this.buttonNameChange.Location = new System.Drawing.Point(224, 131);
            this.buttonNameChange.Name = "buttonNameChange";
            this.buttonNameChange.Size = new System.Drawing.Size(75, 23);
            this.buttonNameChange.TabIndex = 11;
            this.buttonNameChange.Text = "이름변경";
            this.buttonNameChange.UseVisualStyleBackColor = true;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 132);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(206, 21);
            this.textBoxName.TabIndex = 10;
            // 
            // timerRefreshRoom
            // 
            this.timerRefreshRoom.Interval = 5000;
            this.timerRefreshRoom.Tick += new System.EventHandler(this.timerRefreshRoom_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 160);
            this.Controls.Add(this.buttonNameChange);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPw);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCreateRoom);
            this.Controls.Add(this.textBoxRoomName);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIpAddress);
            this.Controls.Add(this.buttonConnectServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonRoomJoin);
            this.Controls.Add(this.listBoxUserList);
            this.Name = "Form1";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRoomJoin;
        private System.Windows.Forms.ListBox listBoxUserList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnectServer;
        private System.Windows.Forms.TextBox textBoxIpAddress;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxRoomName;
        private System.Windows.Forms.Button buttonCreateRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxPw;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonNameChange;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Timer timerRefreshRoom;
    }
}

