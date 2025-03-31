namespace caro27_033.GUI
{
    partial class frmScore
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScore));
            dtgScoreBoard = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtgScoreBoard).BeginInit();
            SuspendLayout();
            // 
            // dtgScoreBoard
            // 
            dtgScoreBoard.AllowUserToAddRows = false;
            dtgScoreBoard.AllowUserToDeleteRows = false;
            dtgScoreBoard.AllowUserToResizeColumns = false;
            dtgScoreBoard.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dtgScoreBoard.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dtgScoreBoard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgScoreBoard.BackgroundColor = Color.White;
            dtgScoreBoard.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.DarkBlue;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dtgScoreBoard.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dtgScoreBoard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dtgScoreBoard.DefaultCellStyle = dataGridViewCellStyle3;
            dtgScoreBoard.Dock = DockStyle.Fill;
            dtgScoreBoard.GridColor = Color.Gray;
            dtgScoreBoard.Location = new Point(0, 0);
            dtgScoreBoard.Name = "dtgScoreBoard";
            dtgScoreBoard.ReadOnly = true;
            dtgScoreBoard.RowHeadersVisible = false;
            dtgScoreBoard.RowHeadersWidth = 62;
            dtgScoreBoard.Size = new Size(330, 330);
            dtgScoreBoard.TabIndex = 0;
            // 
            // frmScore
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 330);
            Controls.Add(dtgScoreBoard);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmScore";
            Text = "Bảng Xếp Hạng";
            Load += frmScore_Load;
            ((System.ComponentModel.ISupportInitialize)dtgScoreBoard).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dtgScoreBoard;
    }
}