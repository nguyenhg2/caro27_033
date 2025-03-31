using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using caro27_033.Class;

namespace caro27_033.BLL
{
    public class Bot
    {
        private List<List<Button>> _matrix;
        private string _level;
        private Random _random = new Random();

        // Constructor nhận ma trận bàn cờ và cấp độ khó
        public Bot(List<List<Button>> matrix, string level)
        {
            _matrix = matrix;
            _level = level;
        }

        // Phương thức tìm nước đi tiếp theo cho máy
        public Point FindNextMove(Image playerMark, Image botMark)
        {
            switch (_level)
            {
                case "Khó":
                    return FindBestMoveHard(playerMark, botMark);
                case "Trung bình":
                    return FindBestMoveMedium(playerMark, botMark);
                case "Dễ":
                default:
                    return FindRandomMove();
            }
        }

        // Cấp độ dễ: Đánh ngẫu nhiên vào ô trống
        private Point FindRandomMove()
        {
            List<Point> emptyPositions = new List<Point>();

            // Tìm tất cả các ô trống
            for (int i = 0; i < _matrix.Count; i++)
            {
                for (int j = 0; j < _matrix[i].Count; j++)
                {
                    if (_matrix[i][j].BackgroundImage == null)
                    {
                        emptyPositions.Add(new Point(i, j));
                    }
                }
            }

            // Nếu còn ô trống, chọn ngẫu nhiên
            if (emptyPositions.Count > 0)
            {
                int randomIndex = _random.Next(emptyPositions.Count);
                return emptyPositions[randomIndex];
            }

            // Nếu không còn ô trống
            return new Point(-1, -1);
        }

        // Cấp độ trung bình: Ưu tiên phòng thủ
        private Point FindBestMoveMedium(Image playerMark, Image botMark)
        {
            // 70% thời gian sẽ chơi thông minh, 30% ngẫu nhiên
            if (_random.Next(100) < 30)
                return FindRandomMove();

            // Tìm nước đi tấn công hoặc phòng thủ
            Point attackMove = FindAttackMove(botMark);
            Point defendMove = FindDefendMove(playerMark);

            // Ưu tiên phòng thủ nếu người chơi sắp thắng
            if (defendMove.X != -1)
                return defendMove;

            // Nếu không có nước phòng thủ cần thiết, tấn công
            if (attackMove.X != -1)
                return attackMove;

            // Nếu không có nước tấn công tốt, đánh ngẫu nhiên
            return FindRandomMove();
        }

        // Cấp độ khó: Thông minh hơn, ưu tiên tấn công
        private Point FindBestMoveHard(Image playerMark, Image botMark)
        {
            // 90% thời gian sẽ chơi thông minh, 10% ngẫu nhiên
            if (_random.Next(100) < 10)
                return FindRandomMove();

            Point attackMove = FindAttackMove(botMark);
            Point defendMove = FindDefendMove(playerMark);

            // Ưu tiên tấn công nếu có cơ hội thắng
            if (attackMove.X != -1)
                return attackMove;

            // Nếu không có nước tấn công tốt, phòng thủ
            if (defendMove.X != -1)
                return defendMove;

            // Nếu không có nước đặc biệt, tìm nước tốt nhất
            return FindStrategicMove();
        }

        // Tìm nước tấn công (khi bot có cơ hội thắng)
        private Point FindAttackMove(Image botMark)
        {
            // Tìm các vị trí mà bot có thể thắng trong nước tiếp theo
            for (int i = 0; i < _matrix.Count; i++)
            {
                for (int j = 0; j < _matrix[i].Count; j++)
                {
                    if (_matrix[i][j].BackgroundImage == null)
                    {
                        // Giả lập đặt quân
                        _matrix[i][j].BackgroundImage = botMark;

                        // Kiểm tra nếu bot thắng
                        CheckWin checkWin = new CheckWin(_matrix);
                        bool isWinning = checkWin.Check(i, j);

                        // Hoàn tác
                        _matrix[i][j].BackgroundImage = null;

                        if (isWinning)
                            return new Point(i, j);
                    }
                }
            }

            return new Point(-1, -1);
        }

        // Tìm nước phòng thủ (khi người chơi sắp thắng)
        private Point FindDefendMove(Image playerMark)
        {
            // Tìm các vị trí mà người chơi có thể thắng trong nước tiếp theo
            for (int i = 0; i < _matrix.Count; i++)
            {
                for (int j = 0; j < _matrix[i].Count; j++)
                {
                    if (_matrix[i][j].BackgroundImage == null)
                    {
                        // Giả lập người chơi đặt quân
                        _matrix[i][j].BackgroundImage = playerMark;

                        // Kiểm tra nếu người chơi thắng
                        CheckWin checkWin = new CheckWin(_matrix);
                        bool isWinning = checkWin.Check(i, j);

                        // Hoàn tác
                        _matrix[i][j].BackgroundImage = null;

                        if (isWinning)
                            return new Point(i, j);
                    }
                }
            }

            return new Point(-1, -1);
        }

        // Tìm nước đi chiến lược (ưu tiên trung tâm và đánh gần quân đã có)
        private Point FindStrategicMove()
        {
            // Ưu tiên đánh ở trung tâm bàn cờ
            int centerRow = _matrix.Count / 2;
            int centerCol = _matrix[0].Count / 2;

            // Kiểm tra trung tâm trước
            if (_matrix[centerRow][centerCol].BackgroundImage == null)
                return new Point(centerRow, centerCol);

            // Tìm vị trí gần với quân đã đánh
            for (int distance = 1; distance <= 2; distance++)
            {
                List<Point> nearbyMoves = new List<Point>();

                for (int i = 0; i < _matrix.Count; i++)
                {
                    for (int j = 0; j < _matrix[i].Count; j++)
                    {
                        if (_matrix[i][j].BackgroundImage != null)
                        {
                            // Kiểm tra các ô xung quanh
                            for (int di = -distance; di <= distance; di++)
                            {
                                for (int dj = -distance; dj <= distance; dj++)
                                {
                                    int ni = i + di;
                                    int nj = j + dj;

                                    if (ni >= 0 && ni < _matrix.Count &&
                                        nj >= 0 && nj < _matrix[0].Count &&
                                        _matrix[ni][nj].BackgroundImage == null)
                                    {
                                        nearbyMoves.Add(new Point(ni, nj));
                                    }
                                }
                            }
                        }
                    }
                }

                if (nearbyMoves.Count > 0)
                {
                    int randomIndex = _random.Next(nearbyMoves.Count);
                    return nearbyMoves[randomIndex];
                }
            }

            // Nếu không tìm được nước đi chiến lược, đánh ngẫu nhiên
            return FindRandomMove();
        }
    }
}