using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace caro27_033.GUI
{
    public partial class frmScore : Form
    {
        public frmScore()
        {
            InitializeComponent();
        }
        static string connString = @"Data Source=NguyenDZ;Initial Catalog=UserName;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection conn = new SqlConnection(connString);

        private void frmScore_Load(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT *FROM UserName", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dtgScoreBoard.DataSource = dt;

                //if (dtgScoreBoard.Columns["Name"] != null)
                //    dtgScoreBoard.Columns["Name"].HeaderText = "Tên người chơi";

                //if (dtgScoreBoard.Columns["Score"] != null)
                //    dtgScoreBoard.Columns["Score"].HeaderText = "Điểm số";


                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void LoadScoreData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM UserName ORDER BY Score DESC", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dtgScoreBoard.DataSource = dt;

                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}