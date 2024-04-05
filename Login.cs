using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLBH
{

    public partial class Login : Form
    {
        Ketnoi kn = new Ketnoi();
        SqlCommand cmd;
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            kn.openKetnoi();
            conn = kn.getKetNoi();
            cmd = conn.CreateCommand();
            cmd.CommandText = "select count(*) from NguoiDung where TaiKhoan='" + txtTK.Text + "'and MatKhau='" + txtMK.Text + "'";
            int count = (int)cmd.ExecuteScalar();
            if (count > 0)
            {
                MessageBox.Show("Dang Nhap Thanh Cong!");
                this.Hide();
                TrangChu tc = new TrangChu();
                tc.Show();
            }
            else
            {
                MessageBox.Show("Dang Nhap That Bai!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
