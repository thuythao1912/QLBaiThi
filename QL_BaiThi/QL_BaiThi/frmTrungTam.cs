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
    public partial class frmTrungTam : Form
    {
        DataSet dsTT = new DataSet();
        SqlDataAdapter daTT = new SqlDataAdapter();
        BindingSource bsTT = new BindingSource();
        bool blnThem = false;

        public frmTrungTam()
        {
            InitializeComponent();
        }

        private void frmTrungTam_Load(object sender, EventArgs e)
        {
            string strSelect = "Select * From TrungTam";
            MyPublics.OpenData(strSelect, dsTT, "TrungTam", daTT);
            bsTT.DataSource = dsTT;
            bsTT.DataMember = "TrungTam";

            txtMaTT.MaxLength = 8;
            txtTinh.MaxLength = 40;
            txtTT.MaxLength = 40;

            GanDuLieu();

            dgvTrungTam.DataSource = dsTT;
            dgvTrungTam.DataMember = "TrungTam";

            dgvTrungTam.Width = 450;
            dgvTrungTam.Columns[0].Width = 100;
            dgvTrungTam.Columns[0].HeaderText = "Mã trung tâm";
            dgvTrungTam.Columns[1].Width = 200;
            dgvTrungTam.Columns[1].HeaderText = "Tên trung tâm";
            dgvTrungTam.Columns[2].Width = 90;
            dgvTrungTam.Columns[2].HeaderText = "Tỉnh";

            dgvTrungTam.AllowUserToAddRows = false;
            dgvTrungTam.AllowUserToDeleteRows = false;

            dgvTrungTam.EditMode = DataGridViewEditMode.EditProgrammatically;

            //DieuKhienKhiBinhThuong();
        }

        void GanDuLieu() { 
            txtMaTT.DataBindings.Add(new Binding("Text", bsTT, "MaTT"));
            txtTT.DataBindings.Add(new Binding("Text", bsTT, "TenTT"));
            txtTinh.DataBindings.Add(new Binding("Text", bsTT, "Tinh"));
        }

        private void dgvTrungTam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bsTT.Position = dgvTrungTam.CurrentRow.Index;
        }
    }
}
