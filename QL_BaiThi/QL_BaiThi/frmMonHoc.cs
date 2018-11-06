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
    public partial class frmMonHoc : Form
    {
        DataSet dsMon = new DataSet();
        SqlDataAdapter daMon = new SqlDataAdapter();
        BindingSource bsMon = new BindingSource();
        bool blnThem = false;

        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From MonHoc";
            MyPublics.OpenData(strSelect, dsMon, "MonHoc", daMon);
            bsMon.DataSource = dsMon;
            bsMon.DataMember = "MonHoc";

            txtMaMon.MaxLength = 8;
            txtTenMon.MaxLength = 40;

            GanDuLieu();

            dgvMonHoc.DataSource = dsMon;
            dgvMonHoc.DataMember = "MonHoc";

            dgvMonHoc.Width = 450;
            dgvMonHoc.Columns[0].Width = 100;
            dgvMonHoc.Columns[0].HeaderText = "Mã môn";
            dgvMonHoc.Columns[1].Width = 200;
            dgvMonHoc.Columns[1].HeaderText = "Tên môn";
            dgvMonHoc.Columns[2].Width = 90;
            dgvMonHoc.Columns[2].HeaderText = "Số tín chỉ";

            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;

            dgvMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically;
            //DieuKhienKhiBinhThuong();
        }

        void GanDuLieu() { 
            txtMaMon.DataBindings.Add (new Binding ("Text", bsMon, "MaMon"));
            txtTenMon.DataBindings.Add(new Binding ("Text", bsMon, "TenMon"));
            txtSoTinChi.DataBindings.Add(new Binding("Text", bsMon, "SoTinChi"));
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bsMon.Position = dgvMonHoc.CurrentRow.Index;
        }
    }
}
