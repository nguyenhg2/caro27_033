using caro27_033.Class;
using caro27_033.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace caro27_033.GUI
{
    public partial class frmChessBoard : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        #endregion
        public frmChessBoard(string playerName, string level)
        {
            InitializeComponent();
            chessBoard = new ChessBoardManager(pnlChessBoard, ptbavt1, ptbavt2,
                                               labNameBot, labNamePlayer,
                                               progressBar1, progressBar2,
                                               true, level);  // true = chơi với máy
            labNamePlayer.Text = playerName;
            txtRename.Text = playerName;
            lblLevel.Text = level;
            chessBoard.BotLevel = level;  // Cập nhật cấp độ bot
            chessBoard.DrawChessBoard();
        }

        private void frmChessBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmReturnStart_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Run(new GUI.frmStart());
        }

        private void tsmPause_Click(object sender, EventArgs e)
        {
            chessBoard.TimerManager.StopTimer();
            DialogResult result = MessageBox.Show("Tiếp tục?", "Tạm dừng", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                chessBoard.TimerManager.ResumeTimer();
            }
        }

        private void tsmEndo_Click(object sender, EventArgs e)
        {
            chessBoard.ResetChessBoard();
        }


        private void txtRename_TextChanged(object sender, EventArgs e)
        {
            chessBoard.TimerManager.StopTimer();

        }

        private void txtRename_Leave(object sender, EventArgs e)
        {
            labNamePlayer.Text = txtRename.Text;
            chessBoard.TimerManager.ResumeTimer();
        }

        private void txtRename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labNamePlayer.Text = txtRename.Text;
                chessBoard.TimerManager.ResumeTimer();
            }
        }

        private void tsmHideShowChatBox_Click(object sender, EventArgs e)
        {
            if (tsmHideShowChatBox.Text == "Ẩn")
            {
                lblChatBox.Visible = false;
                txtChatBox.Visible = false;
                lblNameChatbox.Visible = false;
                tsmHideShowChatBox.Text = "Hiện";
            }
            else
            {
                lblChatBox.Visible = true;
                txtChatBox.Visible = true;
                lblNameChatbox.Visible = true;
                tsmHideShowChatBox.Text = "Ẩn";
            }


        }

        private void tsmOnOffMusic_Click(object sender, EventArgs e)
        {
            if (tsmOnOffMusic.Text == "Bật")
            {
                tsmOnOffMusic.Text = "Tắt";
                //
            }
            else
            {
                tsmOnOffMusic.Text = "Bật";
                //
            }
        }

        private void tsmEasyLevel_Click(object sender, EventArgs e)
        {
            lblLevel.Text = "Dễ";
            chessBoard.BotLevel = "Dễ";  // Cập nhật cấp độ bot
        }

        private void tsmMediumLevel_Click(object sender, EventArgs e)
        {
            lblLevel.Text = "Trung bình";
            chessBoard.BotLevel = "Trung bình";  // Cập nhật cấp độ bot
        }

        private void tsmHardLevel_Click(object sender, EventArgs e)
        {
            lblLevel.Text = "Khó";
            chessBoard.BotLevel = "Khó";  // Cập nhật cấp độ bot
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScore frmScore = new frmScore();
            frmScore.StartPosition = FormStartPosition.CenterScreen;
            frmScore.ShowDialog();
        }

    }
}
