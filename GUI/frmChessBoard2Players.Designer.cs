namespace caro27_033.GUI
{
    partial class frmChessBoard2Players
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
            mnuChessBoard = new MenuStrip();
            tsmSetting = new ToolStripMenuItem();
            tsmReturnStart = new ToolStripMenuItem();
            tsmMusic = new ToolStripMenuItem();
            tsmOnOffMusic = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();
            tsmControl = new ToolStripMenuItem();
            tsmPause = new ToolStripMenuItem();
            tsmUndo = new ToolStripMenuItem();
            tsmEndo = new ToolStripMenuItem();
            tsmConnect = new ToolStripMenuItem();
            tsmLAN = new ToolStripMenuItem();
            tsmDisplay = new ToolStripMenuItem();
            tsmRename = new ToolStripMenuItem();
            txtRename1 = new ToolStripTextBox();
            txtRename2 = new ToolStripTextBox();
            tsmChangeTheme = new ToolStripMenuItem();
            thayĐổiToolStripMenuItem = new ToolStripMenuItem();
            tsmChatBox = new ToolStripMenuItem();
            tsmHideShowChatBox = new ToolStripMenuItem();
            bảngĐiểmToolStripMenuItem = new ToolStripMenuItem();
            tsmHelp = new ToolStripMenuItem();
            tsmTheRules = new ToolStripMenuItem();
            tsmTip = new ToolStripMenuItem();
            pnlChessBoard = new Panel();
            txtChatBox = new TextBox();
            ptbavt1 = new PictureBox();
            ptbavt2 = new PictureBox();
            labPlayer2 = new Label();
            labPlayer1 = new Label();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            lblChatBox = new Label();
            lblNameChatbox = new Label();
            mnuChessBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbavt1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ptbavt2).BeginInit();
            SuspendLayout();

            // mnuChessBoard
            mnuChessBoard.ImageScalingSize = new Size(20, 20);
            mnuChessBoard.Items.AddRange(new ToolStripItem[] { tsmSetting, tsmControl, tsmConnect, tsmDisplay, tsmHelp });
            mnuChessBoard.Location = new Point(0, 0);
            mnuChessBoard.Name = "mnuChessBoard";
            mnuChessBoard.Padding = new Padding(8, 2, 0, 2);
            mnuChessBoard.Size = new Size(1178, 33);
            mnuChessBoard.TabIndex = 0;
            mnuChessBoard.Text = "menuStrip1";

            // tsmSetting
            tsmSetting.DropDownItems.AddRange(new ToolStripItem[] { tsmReturnStart, tsmMusic, tsmExit });
            tsmSetting.Name = "tsmSetting";
            tsmSetting.Size = new Size(83, 29);
            tsmSetting.Text = "Cài đặt";

            // tsmReturnStart
            tsmReturnStart.Name = "tsmReturnStart";
            tsmReturnStart.ShowShortcutKeys = false;
            tsmReturnStart.Size = new Size(336, 34);
            tsmReturnStart.Text = "Quay lại màn hình đăng nhập";
            tsmReturnStart.Click += tsmReturnStart_Click;

            // tsmMusic
            tsmMusic.DropDownItems.AddRange(new ToolStripItem[] { tsmOnOffMusic });
            tsmMusic.Name = "tsmMusic";
            tsmMusic.Size = new Size(336, 34);
            tsmMusic.Text = "Âm thanh";

            // tsmOnOffMusic
            tsmOnOffMusic.Name = "tsmOnOffMusic";
            tsmOnOffMusic.Size = new Size(139, 34);
            tsmOnOffMusic.Text = "Bật";
            tsmOnOffMusic.Click += tsmOnOffMusic_Click;

            // tsmExit
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(336, 34);
            tsmExit.Text = "Thoát";
            tsmExit.Click += tsmExit_Click;

            // tsmControl
            tsmControl.DropDownItems.AddRange(new ToolStripItem[] { tsmPause, tsmUndo, tsmEndo });
            tsmControl.Name = "tsmControl";
            tsmControl.Size = new Size(111, 29);
            tsmControl.Text = "Điều khiển";

            // tsmPause
            tsmPause.Name = "tsmPause";
            tsmPause.Size = new Size(270, 34);
            tsmPause.Text = "Tạm dừng";
            tsmPause.Click += tsmPause_Click;

            // tsmUndo
            tsmUndo.Name = "tsmUndo";
            tsmUndo.Size = new Size(270, 34);
            tsmUndo.Text = "Quay lại";

            // tsmEndo
            tsmEndo.Name = "tsmEndo";
            tsmEndo.Size = new Size(270, 34);
            tsmEndo.Text = "Chơi lại";
            tsmEndo.Click += tsmEndo_Click;

            // tsmConnect
            tsmConnect.DropDownItems.AddRange(new ToolStripItem[] { tsmLAN });
            tsmConnect.Name = "tsmConnect";
            tsmConnect.Size = new Size(83, 29);
            tsmConnect.Text = "Kết nối";

            // tsmLAN
            tsmLAN.Name = "tsmLAN";
            tsmLAN.Size = new Size(270, 34);
            tsmLAN.Text = "LAN";

            // tsmDisplay
            tsmDisplay.DropDownItems.AddRange(new ToolStripItem[] { tsmRename, tsmChangeTheme, tsmChatBox, bảngĐiểmToolStripMenuItem });
            tsmDisplay.Name = "tsmDisplay";
            tsmDisplay.Size = new Size(89, 29);
            tsmDisplay.Text = "Hiển thị";

            // tsmRename
            tsmRename.DropDownItems.AddRange(new ToolStripItem[] { txtRename1, txtRename2 });
            tsmRename.Name = "tsmRename";
            tsmRename.Size = new Size(270, 34);
            tsmRename.Text = "Đổi tên";

            // txtRename1
            txtRename1.Name = "txtRename1";
            txtRename1.Size = new Size(100, 31);
            txtRename1.Leave += txtRename1_Leave;
            txtRename1.KeyDown += txtRename1_KeyDown;
            txtRename1.TextChanged += txtRename1_TextChanged;

            // txtRename2
            txtRename2.Name = "txtRename2";
            txtRename2.Size = new Size(100, 31);
            txtRename2.Leave += txtRename2_Leave;
            txtRename2.KeyDown += txtRename2_KeyDown;
            txtRename2.TextChanged += txtRename2_TextChanged;

            // tsmChangeTheme
            tsmChangeTheme.DropDownItems.AddRange(new ToolStripItem[] { thayĐổiToolStripMenuItem });
            tsmChangeTheme.Name = "tsmChangeTheme";
            tsmChangeTheme.Size = new Size(270, 34);
            tsmChangeTheme.Text = "Giao diện";

            // thayĐổiToolStripMenuItem
            thayĐổiToolStripMenuItem.Name = "thayĐổiToolStripMenuItem";
            thayĐổiToolStripMenuItem.Size = new Size(182, 34);
            thayĐổiToolStripMenuItem.Text = "Thay đổi";

            // tsmChatBox
            tsmChatBox.DropDownItems.AddRange(new ToolStripItem[] { tsmHideShowChatBox });
            tsmChatBox.Name = "tsmChatBox";
            tsmChatBox.Size = new Size(270, 34);
            tsmChatBox.Text = "Khung chat";

            // tsmHideShowChatBox
            tsmHideShowChatBox.Name = "tsmHideShowChatBox";
            tsmHideShowChatBox.Size = new Size(136, 34);
            tsmHideShowChatBox.Text = "Ẩn";
            tsmHideShowChatBox.Click += tsmHideShowChatBox_Click;

            // bảngĐiểmToolStripMenuItem
            bảngĐiểmToolStripMenuItem.Name = "bảngĐiểmToolStripMenuItem";
            bảngĐiểmToolStripMenuItem.Size = new Size(270, 34);
            bảngĐiểmToolStripMenuItem.Text = "Bảng điểm";
            bảngĐiểmToolStripMenuItem.Click += bảngĐiểmToolStripMenuItem_Click;

            // tsmHelp
            tsmHelp.DropDownItems.AddRange(new ToolStripItem[] { tsmTheRules, tsmTip });
            tsmHelp.Name = "tsmHelp";
            tsmHelp.Size = new Size(93, 29);
            tsmHelp.Text = "Trợ giúp";

            // tsmTheRules
            tsmTheRules.Name = "tsmTheRules";
            tsmTheRules.Size = new Size(185, 34);
            tsmTheRules.Text = "Luật chơi";

            // tsmTip
            tsmTip.Name = "tsmTip";
            tsmTip.Size = new Size(185, 34);
            tsmTip.Text = "Gợi ý";

            // pnlChessBoard
            pnlChessBoard.BackColor = Color.Transparent;
            pnlChessBoard.Location = new Point(215, 38);
            pnlChessBoard.Margin = new Padding(4);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(750, 750);
            pnlChessBoard.TabIndex = 1;

            // txtChatBox
            txtChatBox.Location = new Point(983, 741);
            txtChatBox.Margin = new Padding(4);
            txtChatBox.Multiline = true;
            txtChatBox.Name = "txtChatBox";
            txtChatBox.Size = new Size(184, 47);
            txtChatBox.TabIndex = 4;

            // ptbavt1
            ptbavt1.BackgroundImage = Properties.Resources.player2Avatar;
            ptbavt1.BackgroundImageLayout = ImageLayout.Stretch;
            ptbavt1.Location = new Point(12, 45);
            ptbavt1.Margin = new Padding(4);
            ptbavt1.Name = "ptbavt1";
            ptbavt1.Size = new Size(184, 229);
            ptbavt1.TabIndex = 7;
            ptbavt1.TabStop = false;

            // ptbavt2
            ptbavt2.BackgroundImage = Properties.Resources.player1Avatar;
            ptbavt2.BackgroundImageLayout = ImageLayout.Stretch;
            ptbavt2.Location = new Point(983, 45);
            ptbavt2.Margin = new Padding(4);
            ptbavt2.Name = "ptbavt2";
            ptbavt2.Size = new Size(184, 229);
            ptbavt2.TabIndex = 8;
            ptbavt2.TabStop = false;

            // labPlayer2
            labPlayer2.AutoSize = true;
            labPlayer2.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            labPlayer2.Location = new Point(13, 335);
            labPlayer2.Margin = new Padding(4, 0, 4, 0);
            labPlayer2.Name = "labPlayer2";
            labPlayer2.Size = new Size(132, 30);
            labPlayer2.TabIndex = 9;
            labPlayer2.Text = "Player 2";

            // labPlayer1
            labPlayer1.AutoSize = true;
            labPlayer1.Font = new System.Drawing.Font("Showcard Gothic", 12F);
            labPlayer1.Location = new Point(983, 335);
            labPlayer1.Margin = new Padding(4, 0, 4, 0);
            labPlayer1.Name = "labPlayer1";
            labPlayer1.Size = new Size(132, 30);
            labPlayer1.TabIndex = 10;
            labPlayer1.Text = "Player 1";

            // progressBar1
            progressBar1.BackColor = Color.Red;
            progressBar1.Cursor = Cursors.AppStarting;
            progressBar1.ForeColor = SystemColors.MenuHighlight;
            progressBar1.Location = new Point(12, 287);
            progressBar1.Margin = new Padding(4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(184, 36);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 11;

            // progressBar2
            progressBar2.Location = new Point(983, 287);
            progressBar2.Margin = new Padding(4);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(184, 36);
            progressBar2.Style = ProgressBarStyle.Continuous;
            progressBar2.TabIndex = 12;

            // lblChatBox
            lblChatBox.BackColor = Color.White;
            lblChatBox.Location = new Point(983, 567);
            lblChatBox.Name = "lblChatBox";
            lblChatBox.Size = new Size(183, 167);
            lblChatBox.TabIndex = 13;

            // lblNameChatbox
            lblNameChatbox.BackColor = Color.Transparent;
            lblNameChatbox.Font = new System.Drawing.Font("Showcard Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNameChatbox.ForeColor = Color.Yellow;
            lblNameChatbox.Location = new Point(983, 507);
            lblNameChatbox.Name = "lblNameChatbox";
            lblNameChatbox.Size = new Size(183, 46);
            lblNameChatbox.TabIndex = 14;
            lblNameChatbox.Text = "KHUNG CHAT";
            lblNameChatbox.TextAlign = ContentAlignment.MiddleCenter;

            // frmChessBoard2Players
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.chessBoard;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1178, 794);
            Controls.Add(lblNameChatbox);
            Controls.Add(lblChatBox);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(labPlayer1);
            Controls.Add(labPlayer2);
            Controls.Add(ptbavt2);
            Controls.Add(ptbavt1);
            Controls.Add(txtChatBox);
            Controls.Add(pnlChessBoard);
            Controls.Add(mnuChessBoard);
            MainMenuStrip = mnuChessBoard;
            Margin = new Padding(4);
            Name = "frmChessBoard2Players";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caro - Chế độ 2 người chơi";
            FormClosed += frmChessBoard2Players_FormClosed;
            mnuChessBoard.ResumeLayout(false);
            mnuChessBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbavt1).EndInit();
            ((System.ComponentModel.ISupportInitialize)ptbavt2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuChessBoard;
        private ToolStripMenuItem tsmSetting;
        private Panel pnlChessBoard;
        private TextBox txtChatBox;
        private PictureBox ptbavt1;
        private PictureBox ptbavt2;
        private Label labPlayer2;
        private Label labPlayer1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Label lblChatBox;
        private Label lblNameChatbox;
        private ToolStripMenuItem tsmExit;
        private ToolStripMenuItem tsmMusic;
        private ToolStripMenuItem tsmReturnStart;
        private ToolStripMenuItem tsmControl;
        private ToolStripMenuItem tsmPause;
        private ToolStripMenuItem tsmUndo;
        private ToolStripMenuItem tsmEndo;
        private ToolStripMenuItem tsmConnect;
        private ToolStripMenuItem tsmDisplay;
        private ToolStripMenuItem tsmChangeTheme;
        private ToolStripMenuItem thayĐổiToolStripMenuItem;
        private ToolStripMenuItem tsmChatBox;
        private ToolStripMenuItem tsmHideShowChatBox;
        private ToolStripMenuItem tsmHelp;
        private ToolStripMenuItem tsmTheRules;
        private ToolStripMenuItem tsmTip;
        private ToolStripMenuItem tsmLAN;
        private ToolStripMenuItem tsmRename;
        private ToolStripTextBox txtRename1;
        private ToolStripTextBox txtRename2;
        private ToolStripMenuItem tsmOnOffMusic;
        private ToolStripMenuItem bảngĐiểmToolStripMenuItem;
    }
}
