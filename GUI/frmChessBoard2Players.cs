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
    public partial class frmChessBoard2Players : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        #endregion

        public frmChessBoard2Players(string player1Name, string player2Name)
        {
            InitializeComponent();

            // Tạo bàn cờ cho 2 người chơi (isPlayingWithBot = false)
            chessBoard = new ChessBoardManager(pnlChessBoard, ptbavt1, ptbavt2, labPlayer2, labPlayer1, progressBar1, progressBar2, false);

            // Cập nhật tên người chơi
            labPlayer1.Text = player1Name;
            labPlayer2.Text = player2Name;
            txtRename1.Text = player1Name;
            txtRename2.Text = player2Name;

            // Vẽ bàn cờ
            chessBoard.DrawChessBoard();
        }

        private void frmChessBoard2Players_FormClosed(object sender, FormClosedEventArgs e)
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
        }

        private void tsmPause_Click(object sender, EventArgs e)
        {
            chessBoard.TimerManager.StopTimer();
            DialogResult result = MessageBox.Show("Tiếp tục? ", "Tạm dừng", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                chessBoard.TimerManager.ResumeTimer();
            }
        }

        private void tsmEndo_Click(object sender, EventArgs e)
        {
            chessBoard.ResetChessBoard();
        }

        private void txtRename1_TextChanged(object sender, EventArgs e)
        {
            chessBoard.TimerManager.StopTimer();
        }

        private void txtRename1_Leave(object sender, EventArgs e)
        {
            labPlayer1.Text = txtRename1.Text;
            chessBoard.TimerManager.ResumeTimer();
        }

        private void txtRename1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labPlayer1.Text = txtRename1.Text;
                chessBoard.TimerManager.ResumeTimer();
            }
        }

        private void txtRename2_TextChanged(object sender, EventArgs e)
        {
            chessBoard.TimerManager.StopTimer();
        }

        private void txtRename2_Leave(object sender, EventArgs e)
        {
            labPlayer2.Text = txtRename2.Text;
            chessBoard.TimerManager.ResumeTimer();
        }

        private void txtRename2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                labPlayer2.Text = txtRename2.Text;
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
            }
            else
            {
                tsmOnOffMusic.Text = "Bật";
            }
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScore frmScore = new frmScore();
            frmScore.StartPosition = FormStartPosition.CenterScreen;
            frmScore.ShowDialog();
        }
    }
}
