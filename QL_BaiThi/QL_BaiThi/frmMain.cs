using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BaiThi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void thoátĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuDangNhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmDN = new frmDangNhap();
            frmDN.ShowDialog(this);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmDangNhap frmDN = new frmDangNhap();
            frmDN.ShowDialog(this);
        }

        private void thaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau fDoiMK = new frmDoiMatKhau();
            fDoiMK.ShowDialog();
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            frmMonHoc fMon = new frmMonHoc();
            fMon.ShowDialog();
        }

        private void mnuTrungTam_Click(object sender, EventArgs e)
        {
            frmTrungTam fTT = new frmTrungTam();
            fTT.ShowDialog();
        }

        private void mnuNguoiSuDung_Click(object sender, EventArgs e)
        {
            frmNguoiSuDung fNSD = new frmNguoiSuDung();
            fNSD.ShowDialog();
        }

        private void mnuBTTheoLop_Click(object sender, EventArgs e)
        {
            frmXemBaiThiTheoLop fBaiThiTheoTT = new frmXemBaiThiTheoLop();
            fBaiThiTheoTT.ShowDialog();
        }
    }
}
