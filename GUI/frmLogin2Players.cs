using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace caro27_033.GUI
{
    public partial class frmLogin2Players : Form
    {
        #region Tạo khung bo tròn
        // Ghi đè phương thức OnLoad để áp dụng bo tròn khi form tải
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Bán kính góc bo tròn
            int cornerRadius = 30;

            // Tạo vùng bo tròn cho form
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
                path.AddArc(this.Width - cornerRadius - 1, 0, cornerRadius, cornerRadius, 270, 90);
                path.AddArc(this.Width - cornerRadius - 1, this.Height - cornerRadius - 1, cornerRadius, cornerRadius, 0, 90);
                path.AddArc(0, this.Height - cornerRadius - 1, cornerRadius, cornerRadius, 90, 90);
                path.CloseFigure();

                // Áp dụng hình dạng bo tròn vào form
                this.Region = new Region(path);
            }
        }
        #endregion

        public frmLogin2Players()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPlayer1.Text == "Tên người chơi 1" || string.IsNullOrEmpty(txtPlayer1.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người chơi 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPlayer2.Text == "Tên người chơi 2" || string.IsNullOrEmpty(txtPlayer2.Text))
            {
                MessageBox.Show("Vui lòng nhập tên người chơi 2", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Close();
            string player1Name = txtPlayer1.Text;
            string player2Name = txtPlayer2.Text;

            // Tạo form bàn cờ cho 2 người chơi
            frmChessBoard2Players chessBoard = new frmChessBoard2Players(player1Name, player2Name);
            chessBoard.StartPosition = FormStartPosition.CenterScreen;
            chessBoard.ShowDialog();
        }

        // Khi người dùng nhấn vào textbox để nhập
        private void txtPlayer1_Enter(object sender, EventArgs e)
        {
            if (txtPlayer1.Text == "Tên người chơi 1")
            {
                txtPlayer1.Text = "";
                txtPlayer1.ForeColor = Color.Black;
            }
        }

        private void txtPlayer1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlayer1.Text))
            {
                txtPlayer1.Text = "Tên người chơi 1";
                txtPlayer1.ForeColor = Color.Gray;
            }
        }

        private void txtPlayer2_Enter(object sender, EventArgs e)
        {
            if (txtPlayer2.Text == "Tên người chơi 2")
            {
                txtPlayer2.Text = "";
                txtPlayer2.ForeColor = Color.Black;
            }
        }

        private void txtPlayer2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlayer2.Text))
            {
                txtPlayer2.Text = "Tên người chơi 2";
                txtPlayer2.ForeColor = Color.Gray;
            }
        }

        // Nhấn enter sau khi nhập tên
        private void txtPlayer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPlayer2.Focus();
                e.SuppressKeyPress = true; // Ngăn không cho nhấn Enter trong TextBox
            }
        }

        private void txtPlayer2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}