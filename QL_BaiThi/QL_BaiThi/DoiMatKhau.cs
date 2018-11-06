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
    public partial class frmDoiMatKhau : Form
    {
        DataSet dsNguoiSuDung = new DataSet();
        SqlDataAdapter daNguoiSuDung = new SqlDataAdapter();
        BindingSource bsNguoiSuDung = new BindingSource();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenTK.Text = MyPublics.strTenTK;
            txtTenTK.ReadOnly = true;
            txtMKMoi.PasswordChar = '*';
            txtMKCu.PasswordChar = '*';
            txtReMKMoi.PasswordChar = '*';
        }

        void KiemTraTaiKhoan() {
            if (txtMKCu.Text == "" || txtMKMoi.Text == "" || txtReMKMoi.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ các trường!");
            }
            else
                if (txtMKMoi.Text != txtReMKMoi.Text)
                {
                    MessageBox.Show("Hai MK không giống nhau");
                    txtMKMoi.Clear();
                    txtReMKMoi.Clear();
                }
                else
                {
                    string strSelect = "Select MatKhau from NguoiSuDung where TenTaiKhoan ='" + txtTenTK.Text + "'";
                    SqlCommand cmdCommand = new SqlCommand(strSelect, MyPublics.conMyConnection);
                    if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                        MyPublics.conMyConnection.Open();
                    SqlDataReader drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        MyPublics.strMK = drReader.GetString(0);
                        drReader.Close();
                        MyPublics.conMyConnection.Close();
                    }
                    
                    if (txtMKCu.Text != MyPublics.strMK)
                    {
                        MessageBox.Show("Mật khẩu cũ sai!");
                        txtMKCu.Clear();
                        txtMKMoi.Clear();
                        txtReMKMoi.Clear();
                    }
                    else
                    {
                        MyPublics.conMyConnection.Close();
                        CapNhatMK();

                    }
                    
                }
        }

        void CapNhatMK() {
            string strSql = "Update NguoiSuDung set MatKhau = '" + txtMKMoi.Text + "' where TenTaiKhoan = '" + txtTenTK.Text +"'";
            if (MyPublics.conMyConnection.State == ConnectionState.Closed)
                MyPublics.conMyConnection.Open();
            SqlCommand cmdCommand = new SqlCommand (strSql, MyPublics.conMyConnection);
            cmdCommand.Parameters.AddWithValue("@MatKhau", txtMKMoi.Text);
            cmdCommand.ExecuteNonQuery();
            MyPublics.conMyConnection.Close();
            MessageBox.Show("Cập nhật mật khẩu thành công! Vui lòng thoát và đăng nhập lại!");
            this.Close();
            //vô hiệu menustrip
        }

       
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            KiemTraTaiKhoan();
        }
    }
}
