using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace caro27_033.GUI
{
    partial class frmLogin1
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
            txtUserName = new TextBox();
            cmbLevel = new ComboBox();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LightBlue;
            btnLogin.Font = new System.Drawing.Font("Showcard Gothic", 16F, FontStyle.Bold);
            btnLogin.Location = new Point(343, 250);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(238, 64);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "VÀO GAME";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.LightBlue;
            btnQuit.Font = new System.Drawing.Font("Showcard Gothic", 16F, FontStyle.Bold);
            btnQuit.Location = new Point(343, 354);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(238, 64);
            btnQuit.TabIndex = 3;
            btnQuit.Text = "THOÁT";
            btnQuit.UseVisualStyleBackColor = false;
            btnQuit.Click += btnQuit_Click;
            // 
            // txtUserName
            // 
            txtUserName.Font = new System.Drawing.Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 163);
            txtUserName.ForeColor = Color.Gray;
            txtUserName.Location = new Point(341, 72);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(240, 49);
            txtUserName.TabIndex = 1;
            txtUserName.Text = "Tên người chơi";
            txtUserName.Enter += txtUserName_Enter;
            txtUserName.KeyDown += txtUserName_KeyDown;
            txtUserName.Leave += txtUserName_Leave;
            // 
            // cmbLevel
            // 
            cmbLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLevel.Font = new System.Drawing.Font("Times New Roman", 18F);
            cmbLevel.Items.AddRange(new object[] { "Chọn cấp độ", "Dễ", "Trung bình", "Khó" });
            cmbLevel.SelectedIndex = 0;
            cmbLevel.Location = new Point(341, 162);
            cmbLevel.Name = "cmbLevel";
            cmbLevel.Size = new Size(240, 49);
            cmbLevel.TabIndex = 2;
            cmbLevel.KeyDown += cmbLevel_KeyDown;
            // 
            // frmLogin1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.loginGround__2_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(909, 518);
            Controls.Add(cmbLevel);
            Controls.Add(txtUserName);
            Controls.Add(btnQuit);
            Controls.Add(btnLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmLogin1";
            Text = "frmLogin1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogin;
        private Button btnQuit;
        private TextBox txtUserName;
        private ComboBox cmbLevel;
    }
}