namespace caro27_033.GUI
{
    partial class frmLogin2Players
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
            btnLogin = new Button();
            btnQuit = new Button();
            txtPlayer1 = new TextBox();
            txtPlayer2 = new TextBox();
            SuspendLayout();

            // btnLogin
            btnLogin.BackColor = Color.LightBlue;
            btnLogin.Font = new System.Drawing.Font("Showcard Gothic", 16F, FontStyle.Bold);
            btnLogin.Location = new Point(343, 300);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(238, 64);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "VÀO GAME";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            // btnQuit
            btnQuit.BackColor = Color.LightBlue;
            btnQuit.Font = new System.Drawing.Font("Showcard Gothic", 16F, FontStyle.Bold);
            btnQuit.Location = new Point(343, 380);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(238, 64);
            btnQuit.TabIndex = 3;
            btnQuit.Text = "THOÁT";
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += btnQuit_Click;

            // txtPlayer1
            txtPlayer1.Font = new System.Drawing.Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPlayer1.ForeColor = Color.Gray;
            txtPlayer1.Location = new Point(341, 100);
            txtPlayer1.Name = "txtPlayer1";
            txtPlayer1.Size = new Size(240, 49);
            txtPlayer1.TabIndex = 1;
            txtPlayer1.Text = "Tên người chơi 1";
            txtPlayer1.Enter += txtPlayer1_Enter;
            txtPlayer1.KeyDown += txtPlayer1_KeyDown;
            txtPlayer1.Leave += txtPlayer1_Leave;

            // txtPlayer2
            txtPlayer2.Font = new System.Drawing.Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtPlayer2.ForeColor = Color.Gray;
            txtPlayer2.Location = new Point(341, 200);
            txtPlayer2.Name = "txtPlayer2";
            txtPlayer2.Size = new Size(240, 49);
            txtPlayer2.TabIndex = 2;
            txtPlayer2.Text = "Tên người chơi 2";
            txtPlayer2.Enter += txtPlayer2_Enter;
            txtPlayer2.KeyDown += txtPlayer2_KeyDown;
            txtPlayer2.Leave += txtPlayer2_Leave;

            // frmLogin2Players
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginGround__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(909, 518);
            Controls.Add(txtPlayer2);
            Controls.Add(txtPlayer1);
            Controls.Add(btnQuit);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin2Players";
            Text = "frmLogin2Players";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnQuit;
        private TextBox txtPlayer1;
        private TextBox txtPlayer2;
    }
}
