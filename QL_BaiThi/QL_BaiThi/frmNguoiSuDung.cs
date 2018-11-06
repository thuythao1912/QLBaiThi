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
    public partial class frmNguoiSuDung : Form
    {
        DataSet dsUser = new DataSet();
        DataSet dsTT = new DataSet();
        DataView dvUser = new DataView();
        DataSet dsQuyenSD = new DataSet();
        int ViTriTT, ThemSua = 0;

        public frmNguoiSuDung()
        {
            InitializeComponent();
        }

        void NhanDuLieu()
        {
            string strSelect = "Select * From NguoiSuDung";
            MyPublics.OpenData(strSelect, dsUser, "NguoiSuDung");
        }

        void GanDuLieu()
        {

            if (dvUser.Count > 0)
            {
                txtTenTK.Text = dgvNguoiSuDung[0, dgvNguoiSuDung.CurrentRow.Index].Value.ToString();
                cbQuyenSD.SelectedIndex = cbQuyenSD.FindString(dgvNguoiSuDung[2, dgvNguoiSuDung.CurrentRow.Index].Value.ToString());
            }
            else
            {
                txtTenTK.Clear();
                cbQuyenSD.SelectedIndex = -1;
            }
        }

        private void frmNguoiSuDung_Load(object sender, EventArgs e)
        {
            string strSelect = "Select MaTT, TenTT From TrungTam";
            MyPublics.OpenData(strSelect, dsTT, "TrungTam");
            cbMaTT.DataSource = dsTT.Tables["TrungTam"];
            cbMaTT.DisplayMember = "TenTT";
            cbMaTT.ValueMember = "MaTT";

            dsQuyenSD.Tables.Add("DSQuyenSD");
            dsQuyenSD.Tables["DSQuyenSD"].Columns.Add("QuyenSD");
            dsQuyenSD.Tables["DSQuyenSD"].Rows.Add("User");
            dsQuyenSD.Tables["DSQuyenSD"].Rows.Add("AdminTT");
            dsQuyenSD.Tables["DSQuyenSD"].Rows.Add("AdminChinh");

            cbQuyenSD.DataSource = dsQuyenSD;
            cbQuyenSD.DisplayMember = "DSQuyenSD.QuyenSD";
            cbQuyenSD.ValueMember = "DSQuyenSD.QuyenSD";

            txtTenTK.MaxLength = 30;

            NhanDuLieu();
            dvUser.Table = dsUser.Tables["NguoiSuDung"];
            dvUser.RowFilter = "MaTT like '" + cbMaTT.SelectedValue + "'";

            dgvNguoiSuDung.DataSource = dvUser;
            dgvNguoiSuDung.Width = 380;
            dgvNguoiSuDung.AllowUserToAddRows = false;
            dgvNguoiSuDung.AllowUserToDeleteRows = false;

            dgvNguoiSuDung.Columns[0].Width = 80;
            dgvNguoiSuDung.Columns[0].HeaderText = "Tên tài khoản";
            dgvNguoiSuDung.Columns[1].Width = 80;
            dgvNguoiSuDung.Columns[1].HeaderText = "Mật khẩu";
            dgvNguoiSuDung.Columns[2].Width = 80;
            dgvNguoiSuDung.Columns[2].HeaderText = "Quyền SD";
            dgvNguoiSuDung.Columns[3].Width = 80;
            dgvNguoiSuDung.Columns[3].HeaderText = "Mã Trung tâm";


            dgvNguoiSuDung.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvNguoiSuDung.CellFormatting += new DataGridViewCellFormattingEventHandler(this.dgvNguoiSuDung_CellFormatting);
            GanDuLieu();
            DieuKhienKhiBinhThuong();
        }

        private void dgvNguoiSuDung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (e.Value != null)
                {
                    e.Value = new String('*', e.Value.ToString().Length);
                }
            }
        }

        private void cbMaTT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cbMaTT.SelectedIndex != -1) && (ThemSua == 0))
            {
                dvUser.RowFilter = "MaTT like'" + cbMaTT.SelectedValue + "'";
                dgvNguoiSuDung.DataSource = dvUser;
                GanDuLieu();
                //MessageBox.Show(MyPublics.strTrungTam + " abc " + cbMaTT.SelectedValue);
                if ((MyPublics.StrQuyenSD == "AdminTT") && (MyPublics.strTrungTam == cbMaTT.SelectedValue.ToString()) || (MyPublics.StrQuyenSD == "AdminChinh"))
                {
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;

                }
                else {
                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }

            }
        }

        private void dgvNguoiSuDung_CellClick(object sender, DataGridViewCellEventArgs e)
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
            ViTriTT = cbMaTT.SelectedIndex;
            DieuKhienKhiChinhSua();
        }

        void ThucThiLuu()
        {
            string strSql, strMK;
            if (ThemSua == 1)
                strSql = "Insert into NguoiSuDung values (@TenTaiKhoan, @MatKhau, @QuyenSD, @MaTT)";
            else
                strSql = "Update NguoiSuDung set QuyenSD = @QuyenSD, MaTT = @MaTT where TenTaiKhoan = @TenTaiKhoan";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand(strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@TenTaiKhoan", txtTenTK.Text);
            cmdCommand.Parameters.AddWithValue("@MaTT", cbMaTT.SelectedValue.ToString());
            cmdCommand.Parameters.AddWithValue("@QuyenSD", cbQuyenSD.SelectedValue.ToString());

            if (ThemSua == 1)
            {
                strMK = MyPublics.MaHoaPassword(txtTenTK.Text);
                cmdCommand.Parameters.AddWithValue("@MatKhau", strMK);
            }
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            dsUser.Clear();
            NhanDuLieu();
            cbMaTT.SelectedIndex = ViTriTT;
            GanDuLieu();
            ThemSua = 0;
            DieuKhienKhiBinhThuong();

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if ((txtTenTK.Text == "") || (cbMaTT.SelectedIndex == -1) || (cbQuyenSD.SelectedIndex == -1))
                MessageBox.Show("Lỗi nhập dữ liệu!");
            else
                if ((ThemSua == 1) && (MyPublics.TonTaiKhoaChinh(txtTenTK.Text, "TenTaiKhoan", "NguoiSuDung")))
                {
                    MessageBox.Show("Tên tài khoản đã có rồi!");
                    txtTenTK.Focus();
                }
                else
                {
                    ThucThiLuu();
                }

        }
        void DieuKhienKhiThem()
        {
            txtTenTK.Clear();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            txtTenTK.ReadOnly = false;
            cbMaTT.Enabled = false;
            cbQuyenSD.SelectedIndex = 0;
            txtTenTK.Focus();

        }

        void DieuKhienKhiBinhThuong()
        {
            if (MyPublics.StrQuyenSD == "AdminChinh" || (MyPublics.StrQuyenSD == "AdminTT") && (MyPublics.strTrungTam == cbMaTT.SelectedValue.ToString()))
            {
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                cbQuyenSD.Enabled = true;
            }
            else
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                cbQuyenSD.Enabled = false;
            }
            btnLuu.Enabled = false;
            btnKhongLuu.Enabled = false;
            btnDong.Enabled = true;
            txtTenTK.ReadOnly = true;
            txtTenTK.BackColor = Color.White;
            cbMaTT.Enabled = true;



        }

        void DieuKhienKhiChinhSua()
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnKhongLuu.Enabled = true;
            btnDong.Enabled = false;
            txtTenTK.ReadOnly = true;
            txtTenTK.BackColor = Color.White;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult blnDongY;
            blnDongY = MessageBox.Show("Bạn thật sự muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo);
            if (blnDongY == DialogResult.Yes)
            {
                string strDelete = "Delete NguoiSuDung where TenTaiKhoan = @TenTaiKhoan";
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

        private void btnKhongLuu_Click(object sender, EventArgs e)
        {
            ThemSua = 0;
            GanDuLieu();
            DieuKhienKhiBinhThuong();

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
