using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using caro27_033.Entity;
using caro27_033.GUI;
using caro27_033.Class;
using Microsoft.Data.SqlClient;

namespace caro27_033.BLL
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        private PictureBox avartar1;
        private PictureBox avartar2;
        private Label labelName1;
        private Label labelName2;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;

        // Quản lý timer riêng biệt
        private GameTimerManager timerManager = null!;

        private string imagePathX = $"{Application.StartupPath}\\Resources\\X.png";
        private string imagePathO = $"{Application.StartupPath}\\Resources\\O.png";

        private int currentPlayer = 0;
        private CheckWin checkWin;
        private Image imageX;
        private Image imageO;

        // Thêm thuộc tính cho Bot
        private Bot bot;
        private bool isPlayingWithBot = false;
        private string botLevel = "Dễ";

        public Panel ChessBoard { get { return chessBoard; } set { chessBoard = value; } }
        public PictureBox Avatar1 { get { return avartar1; } set { avartar1 = value; } }
        public PictureBox Avatar2 { get { return avartar2; } set { avartar2 = value; } }
        public Label LabelName1 { get { return labelName1; } set { labelName1 = value; } }
        public Label LabelName2 { get { return labelName2; } set { labelName2 = value; } }
        public ProgressBar ProgressBar1 { get { return progressBar1; } set { progressBar1 = value; } }
        public ProgressBar ProgressBar2 { get { return progressBar2; } set { progressBar2 = value; } }

        public List<List<Button>> matrix = new List<List<Button>>();
        public List<Player> Player { get; set; } = new List<Player>();
        public GameTimerManager TimerManager { get => timerManager; set => timerManager = value; }

        // Thêm thuộc tính để kiểm tra có đang chơi với máy không
        public bool IsPlayingWithBot
        {
            get => isPlayingWithBot;
            set => isPlayingWithBot = value;
        }

        // Thêm thuộc tính cấp độ của bot
        public string BotLevel
        {
            get => botLevel;
            set => botLevel = value;
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, PictureBox avt1, PictureBox avt2,
                                Label lab1, Label lab2, ProgressBar prgBar1, ProgressBar prgBar2,
                                bool playWithBot = false, string level = "Dễ")
        {
            this.chessBoard = chessBoard;
            this.avartar1 = avt1;
            this.avartar2 = avt2;
            this.labelName1 = lab1;
            this.labelName2 = lab2;
            this.progressBar1 = prgBar1;
            this.progressBar2 = prgBar2;
            this.isPlayingWithBot = playWithBot;
            this.botLevel = level;

            checkWin = new CheckWin(matrix);

            imageX = File.Exists(imagePathX) ? Image.FromFile(imagePathX) : new Bitmap(1, 1);
            imageO = File.Exists(imagePathO) ? Image.FromFile(imagePathO) : new Bitmap(1, 1);

            // Khởi tạo người chơi
            Player.Add(new Player(labelName2.Text, imageX));  // Người chơi 1 hoặc người chơi
            Player.Add(new Player(labelName1.Text, imageO));  // Người chơi 2 hoặc Bot

            // Khởi tạo timer manager
            TimerManager = new GameTimerManager(progressBar1, progressBar2, OnTimeOut);

            // Khởi tạo bàn cờ
            DrawChessBoard();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Tạo bàn cờ lần đầu
        /// </summary>
        public void DrawChessBoard()
        {
            // Xóa bàn cờ cũ
            chessBoard.Controls.Clear();

            // Khởi tạo ma trận button
            matrix.Clear();

            // Tạo danh sách để lưu tất cả các button
            List<Button> allButtons = new List<Button>();

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                matrix.Add(new List<Button>());

                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(j * Cons.CHESS_WIDTH, i * Cons.CHESS_HEIGHT),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString(),
                        TabStop = false
                    };

                    btn.Click += Btn_Click;
                    matrix[i].Add(btn);
                    allButtons.Add(btn);
                }
            }

            // Thêm tất cả các button vào panel cùng một lúc
            chessBoard.Controls.AddRange(allButtons.ToArray());

            // Reset màu nền của tên người chơi
            labelName1.BackColor = Color.White;
            labelName2.BackColor = Color.White;

            // Thiết lập người chơi đầu tiên
            currentPlayer = 0;

            // Khởi tạo bot nếu chơi với máy
            if (isPlayingWithBot)
            {
                bot = new Bot(matrix, botLevel);
            }

            // Chuyển lượt
            ChangePlayer();

            // Bắt đầu đếm ngược cho người chơi đầu tiên
            TimerManager.StartCountdown(currentPlayer);
        }

        /// <summary>
        /// Click chọn nước đi, kiểm tra nước đi hợp lệ? Kiểm tra đã win hay chưa?
        /// </summary>
        private void Btn_Click(object? sender, EventArgs e)
        {
            Button? btn = sender as Button;

            // Nếu button đã có ảnh thì không xử lý
            if (btn == null || btn.BackgroundImage != null) return;

            // Hiển thị ảnh X hoặc O tùy thuộc vào người chơi hiện tại
            btn.BackgroundImage = Player[currentPlayer].Mark;

            // Kiểm tra điều kiện chiến thắng
            checkWin = new CheckWin(matrix);
            int row = Convert.ToInt32(btn.Tag);
            int col = matrix[row].IndexOf(btn);

            if (checkWin.Check(row, col))
            {
                TimerManager.StopTimer();
                // Cập nhật điểm số vào SQL Server
                UpdatePlayerScore(Player[currentPlayer].Name);

                DialogResult result = MessageBox.Show("Bạn muốn chơi tiếp? ",
                    $"{Player[currentPlayer].Name} đã thắng! ",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    ResetChessBoard();
                else
                    Application.Exit();
                return;
            }

            // Kiểm tra hòa (bàn cờ đầy)
            if (IsBoardFull())
            {
                TimerManager.StopTimer();
                DialogResult result = MessageBox.Show("Bàn cờ đã đầy. Hòa! Bạn muốn chơi tiếp?",
                    "Hòa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                    ResetChessBoard();
                else
                    Application.Exit();
                return;
            }

            // Dừng timer hiện tại
            TimerManager.StopTimer();

            // Chuyển lượt
            currentPlayer = currentPlayer == 0 ? 1 : 0;
            ChangePlayer();
            TimerManager.StartCountdown(currentPlayer);

            // Nếu đang chơi với bot và đến lượt bot
            if (isPlayingWithBot && currentPlayer == 1)
            {
                // Cho bot suy nghĩ một chút trước khi đánh
                System.Windows.Forms.Timer botThinkTimer = new System.Windows.Forms.Timer();
                botThinkTimer.Interval = 500; // 0.5 giây
                botThinkTimer.Tick += (s, args) =>
                {
                    botThinkTimer.Stop();
                    MakeBotMove();
                };
                botThinkTimer.Start();
            }
        }

        // Phương thức kiểm tra bàn cờ đã đầy chưa
        private bool IsBoardFull()
        {
            foreach (var row in matrix)
            {
                foreach (var button in row)
                {
                    if (button.BackgroundImage == null)
                        return false;
                }
            }
            return true;
        }

        // Phương thức để bot đánh
        private void MakeBotMove()
        {
            // Khởi tạo lại bot với ma trận và cấp độ hiện tại
            bot = new Bot(matrix, botLevel);

            // Tìm nước đi cho bot
            Point move = bot.FindNextMove(Player[0].Mark, Player[1].Mark);

            // Nếu tìm được nước đi hợp lệ
            if (move.X >= 0 && move.X < matrix.Count && move.Y >= 0 && move.Y < matrix[0].Count)
            {
                // Lấy button tại vị trí đó
                Button botButton = matrix[move.X][move.Y];

                // Đánh dấu nước đi của bot
                botButton.BackgroundImage = Player[currentPlayer].Mark;

                // Kiểm tra chiến thắng
                checkWin = new CheckWin(matrix);
                if (checkWin.Check(move.X, move.Y))
                {
                    TimerManager.StopTimer();
                    // Cập nhật điểm số vào SQL Server nếu bot thắng
                    UpdatePlayerScore(Player[currentPlayer].Name);

                    DialogResult result = MessageBox.Show("Bạn muốn chơi tiếp? ",
                        $"{Player[currentPlayer].Name} đã thắng! ",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                        ResetChessBoard();
                    else
                        Application.Exit();
                    return;
                }

                // Kiểm tra hòa
                if (IsBoardFull())
                {
                    TimerManager.StopTimer();
                    DialogResult result = MessageBox.Show("Bàn cờ đã đầy. Hòa! Bạn muốn chơi tiếp?",
                        "Hòa", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (result == DialogResult.Yes)
                        ResetChessBoard();
                    else
                        Application.Exit();
                    return;
                }

                // Chuyển lượt lại cho người chơi
                TimerManager.StopTimer();
                currentPlayer = 0;  // Chuyển về người chơi
                ChangePlayer();
                TimerManager.StartCountdown(currentPlayer);
            }
        }

        private void UpdatePlayerScore(string playerName)
        {
            try
            {
                string connString = @"Data Source=NguyenDZ;Initial Catalog=UserName;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = @"
                        IF EXISTS (SELECT 1 FROM UserName WHERE Name = @Name)
                            UPDATE UserName SET Score = Score + 1 WHERE Name = @Name
                        ELSE
                            INSERT INTO UserName (Name, Score) VALUES (@Name, 1)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", playerName);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật điểm số: " + ex.Message);
            }
        }

        /// <summary>
        /// Xử lý khi hết thời gian
        /// </summary>
        private void OnTimeOut(int player)
        {
            TimerManager.StopTimer();
            MessageBox.Show($"{Player[currentPlayer].Name} đã thua do hết thời gian! ",
                "Hết thời gian", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetChessBoard();
        }

        /// <summary>
        /// Reset bàn cờ mà không tạo lại các button
        /// </summary>
        public void ResetChessBoard()
        {
            // Xóa hình ảnh nền của tất cả các button
            foreach (List<Button> buttonRow in matrix)
            {
                foreach (Button button in buttonRow)
                {
                    button.BackgroundImage = null;
                }
            }

            // Reset màu nền của tên người chơi
            labelName1.BackColor = Color.White;
            labelName2.BackColor = Color.White;

            // Chuyển lượt người chơi
            currentPlayer = 0;
            ChangePlayer();
            TimerManager.StartCountdown(currentPlayer);

            // Cập nhật bảng điểm
            frmScore frm = new frmScore();
            frm.LoadScoreData();
        }

        /// <summary>
        /// Đổi lượt hiển thị label
        /// </summary>
        private void ChangePlayer()
        {
            // Reset màu nền
            labelName1.BackColor = Color.White;
            labelName2.BackColor = Color.White;

            // Thay đổi hiển thị tên người chơi hiện tại
            if (currentPlayer == 0)
                labelName2.BackColor = Color.Green;
            else
                labelName1.BackColor = Color.Green;
        }
        #endregion
    }
}