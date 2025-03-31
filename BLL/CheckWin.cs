using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caro27_033.BLL
{
    public class CheckWin
    {
        #region Properties

        private List<List<Button>> matrix;
        private int winCondition = 5; // Số quân cần để thắng

        public CheckWin(List<List<Button>> matrix)
        {
            this.matrix = matrix;
        }

        #endregion

        #region Methors

        /// <summary>
        /// Kiểm tra người chơi có thắng không sau khi đặt quân cờ tại (row, col) 
        /// </summary>
        public bool Check(int row, int col)
        {
            if (CountConsecutive(row, col, 0, 1) + CountConsecutive(row, col, 0, -1) >= winCondition - 1) return true; // Ngang
            if (CountConsecutive(row, col, 1, 0) + CountConsecutive(row, col, -1, 0) >= winCondition - 1) return true; // Dọc
            if (CountConsecutive(row, col, 1, 1) + CountConsecutive(row, col, -1, -1) >= winCondition - 1) return true; // Chéo chính
            if (CountConsecutive(row, col, 1, -1) + CountConsecutive(row, col, -1, 1) >= winCondition - 1) return true; // Chéo phụ

            return false;
        }

        /// <summary>
        /// Đếm số quân cờ cùng loại theo một hướng
        /// </summary>
        private int CountConsecutive(int row, int col, int rowDir, int colDir)
        {
            int count = 0;
            int r = row + rowDir;
            int c = col + colDir;

            while (IsValidPosition(r, c) && matrix[r][c].BackgroundImage == matrix[row][col].BackgroundImage)
            {
                count++;
                r += rowDir;
                c += colDir;
            }

            return count;
        }

        /// <summary>
        /// Kiểm tra vị trí có nằm trong bàn cờ không
        /// </summary>
        private bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[0].Count;
        }

        #endregion


    }
}
