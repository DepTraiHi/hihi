using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void mnuPhieuKiemKe_Click(object sender, EventArgs e)
        {

        }

        private void Quanlybanhang_Load(object sender, EventArgs e)
        {

        }

        private void mnuFile_Click(object sender, EventArgs e)
        {

        }

        private void mnuKhachHangThanThiet_Click(object sender, EventArgs e)
        {
            FrmCDTKHTT cd = new FrmCDTKHTT();  
            cd.Show();
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon hd = new frmHoaDon();
            hd.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
