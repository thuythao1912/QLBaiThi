using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_BaiThi
{
    public partial class frmXemBaiThiTheoLop : Form
    {
        DataSet dsBaiThi = new DataSet();
        DataSet dsLop = new DataSet();
        DataSet dsMonHoc = new DataSet();
        DataView dvBaiThi = new DataView();
       int ThemSua = 0, ViTriLop, ViTriMon;

        public frmXemBaiThiTheoLop()
        {
            InitializeComponent();
        }

        private void frmXemBaiThiTheoTT_Load(object sender, EventArgs e)
        {
            string strSelectLop = "Select MaLop, TenLop From LopHoc";
            MyPublics.OpenData(strSelectLop, dsLop, "LopHoc");
            cbMaLop.DataSource = dsLop.Tables["LopHoc"];
            cbMaLop.DisplayMember = "TenLop";
            cbMaLop.ValueMember = "MaLop";

            string strSelectMon = "Select MaMon from MonHoc";
            MyPublics.OpenData(strSelectMon, dsMonHoc, "MonHoc");
            cbMaMon.DataSource = dsMonHoc.Tables["MonHoc"];
            cbMaMon.DisplayMember = "MaMon";
            cbMaMon.ValueMember = "MaMon";

            txtHK.MaxLength = 8;
            txtLanThi.MaxLength = 8;
            txtNH.MaxLength = 8;
            txtSoBai.MaxLength = 8;

            NhanDuLieu();

            dvBaiThi.Table = dsBaiThi.Tables["TheoDoiBaiThi"];
            dvBaiThi.RowFilter = "MaLop like '" + cbMaLop.SelectedValue + "'";
            dgvBaiThiTheoLop.DataSource = dvBaiThi;

            dgvBaiThiTheoLop.Width = 780;
            dgvBaiThiTheoLop.AllowUserToAddRows = false;
            dgvBaiThiTheoLop.AllowUserToDeleteRows = false;

            dgvBaiThiTheoLop.Columns[0].Width = 80;
            dgvBaiThiTheoLop.Columns[0].HeaderText = "Mã môn";
            dgvBaiThiTheoLop.Columns[1].Width = 80;
            dgvBaiThiTheoLop.Columns[1].HeaderText = "Mã lớp";
            dgvBaiThiTheoLop.Columns[2].Width = 80;
            dgvBaiThiTheoLop.Columns[2].HeaderText = "Lần thi";
            dgvBaiThiTheoLop.Columns[3].Width = 80;
            dgvBaiThiTheoLop.Columns[3].HeaderText = "Học kỳ";
            dgvBaiThiTheoLop.Columns[4].Width = 80;
            dgvBaiThiTheoLop.Columns[4].HeaderText = "Năm học";
            dgvBaiThiTheoLop.Columns[5].Width = 80;
            dgvBaiThiTheoLop.Columns[5].HeaderText = "Ngày thi";
            dgvBaiThiTheoLop.Columns[6].Width = 80;
            dgvBaiThiTheoLop.Columns[6].HeaderText = "Số bài";
            dgvBaiThiTheoLop.Columns[7].Width = 80;
            dgvBaiThiTheoLop.Columns[7].HeaderText = "Ngày nhận";
            dgvBaiThiTheoLop.Columns[8].Width = 80;
            dgvBaiThiTheoLop.Columns[8].HeaderText = "Hạn nộp";
            dgvBaiThiTheoLop.EditMode = DataGridViewEditMode.EditProgrammatically;

            GanDuLieu();
            DieuKhienKhiBinhThuong();

        }

        void NhanDuLieu()
        {
            string strSelect = "Select * From TheoDoiBaiThi";
            MyPublics.OpenData(strSelect, dsBaiThi, "TheoDoiBaiThi");
        }

        void GanDuLieu()
        {
            if (dvBaiThi.Count > 0)
            {
                txtHK.Text = dgvBaiThiTheoLop[3, dgvBaiThiTheoLop.CurrentRow.Index].Value.ToString();
                txtNH.Text = dgvBaiThiTheoLop[4, dgvBaiThiTheoLop.CurrentRow.Index].Value.ToString();
                txtLanThi.Text = dgvBaiThiTheoLop[2, dgvBaiThiTheoLop.CurrentRow.Index].Value.ToString();
                txtSoBai.Text = dgvBaiThiTheoLop[6, dgvBaiThiTheoLop.CurrentRow.Index].Value.ToString();
                cbMaMon.SelectedIndex = cbMaMon.FindString(dgvBaiThiTheoLop[0, dgvBaiThiTheoLop.CurrentRow.Index].Value.ToString());
            }
            else
            {
                txtHK.Clear();
                txtNH.Clear();
                txtLanThi.Clear();
                txtSoBai.Clear();
                cbMaMon.SelectedIndex = -1;
            }

        }



        void DieuKhienKhiThem()
        {
            txtHK.Clear();
            txtNH.Clear();
            txtLanThi.Clear();
            txtSoBai.Clear();

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;

            cbMaLop.Enabled = false;

            txtHK.Focus();

        }

        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.StrQuyenSD == "AdminChinh")
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                cbMaLop.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                cbMaLop.Enabled = false;
            }

            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtHK.ReadOnly = true;
            txtHK.BackColor = Color.White;
            txtNH.ReadOnly = true;
            txtNH.BackColor = Color.White;
            txtLanThi.ReadOnly = true;
            txtLanThi.BackColor = Color.White;
            txtSoBai.ReadOnly = true;
            txtSoBai.BackColor = Color.White;
            cbMaLop.Enabled = true;
        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            txtHK.ReadOnly = true;
            txtHK.BackColor = Color.White;
            txtNH.ReadOnly = true;
            txtNH.BackColor = Color.White;
            txtLanThi.ReadOnly = true;
            txtLanThi.BackColor = Color.White;
            cbMaLop.Enabled = false;
            cbMaMon.Enabled = false;
        }

        private void cbMaLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbMaLop.SelectedIndex != -1) && (ThemSua == 0))
            {

                dvBaiThi.RowFilter = "MaLop like'" + cbMaLop.SelectedValue + "'";
                dgvBaiThiTheoLop.DataSource = dvBaiThi;
                GanDuLieu();
                
                string strSelectTT = "Select MaTT from LopHoc where MaLop = '" + cbMaLop.SelectedValue.ToString() + "'";
                SqlCommand cmdCommand = new SqlCommand (strSelectTT, MyPublics.conMyConnection);
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                SqlDataReader drReader = cmdCommand.ExecuteReader();
                    if(drReader.HasRows){
                        drReader.Read();
                        MyPublics.strLop = drReader.GetString(0);
                        drReader.Close();
                        MyPublics.conMyConnection.Close();
                    }
                    //MessageBox.Show(MyPublics.strLop + " abc " + cbMaLop.SelectedValue.ToString() + " TT " +MyPublics.strTrungTam); 
                    if ((MyPublics.StrQuyenSD == "AdminTT") && (MyPublics.strLop == MyPublics.strTrungTam) || (MyPublics.StrQuyenSD == "AdminChinh"))
                    {
                        MyPublics.conMyConnection.Close();
                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;

                    }
                    else
                    {
                        MyPublics.conMyConnection.Close();
                        btnThem.Enabled = false;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                    }

                }

            }

        private void dgvBaiThiTheoLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GanDuLieu();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemSua = 1;
            DieuKhienKhiThem();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ThemSua = 2;
            ViTriLop = cbMaLop.SelectedIndex;
            ViTriMon = cbMaMon.SelectedIndex;
            DieuKhienKhiChinhSua();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                string strDelete = "Delete TheoDoiBaiThi where MaMon = @MaMon and MaLop = @MaLop and LanThi = @LanThi and HocKy = @HocKy and NamHoc = @NamHoc ";
                if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                    MyPublics.conMyConnection.Open();
                SqlCommand cmdCommand = new SqlCommand(strDelete, MyPublics.conMyConnection);
                cmdCommand.Parameters.AddWithValue("@TenTaiKhoan", txtTenTK.Text);
                cmdCommand.ExecuteNonQuery();
                MyPublics.conMyConnection.Close();
                dgvNguoiSuDung.Rows.RemoveAt(dgvNguoiSuDung.CurrentRow.Index);
                GanDuLieu();
            }
            DieuKhienKhiBinhThuong();
        }

        
    }
}
