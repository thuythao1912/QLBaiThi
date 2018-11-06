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
    public partial class frmDangNhap : Form
    {
        int intSoLanDN;
        private frmMain fmain;


        
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public frmDangNhap(frmMain fm)
            : this()
        {
            fmain = fm;
        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            intSoLanDN = 0;
            txtMayChu.Text = @"thuythaobn\thuythao";
            txtMatKhau.PasswordChar = '*';
            txtTenTK.Text ="bntt";
            txtMatKhau.Text = txtTenTK.Text;
            txtTenTK.Focus();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlCommand cmdCommand;
            SqlDataReader drReader;
            string sqlselect, strPasswordSV;
            MyPublics.strServer = txtMayChu.Text;
            try
            {
                MyPublics.ConnectDatabase();
                if (MyPublics.conMyConnection.State == ConnectionState.Open)
                {
                    MyPublics.strTenTK = txtTenTK.Text;
                    strPasswordSV = txtMatKhau.Text;
                    sqlselect = "select MaTT, QuyenSD From NguoiSuDung Where TenTaiKhoan = @TenTaiKhoan And MatKhau = @MatKhau";
                    cmdCommand = new SqlCommand(sqlselect, MyPublics.conMyConnection);
                    cmdCommand.Parameters.AddWithValue("@TenTaiKhoan", txtTenTK.Text);
                    cmdCommand.Parameters.AddWithValue("@MatKhau", strPasswordSV);
                    drReader = cmdCommand.ExecuteReader();
                    if (drReader.HasRows)
                    {
                        drReader.Read();
                        MyPublics.strTrungTam = drReader.GetString(0);
                        MyPublics.StrQuyenSD = drReader.GetString(1);
                        
                        drReader.Close();

                        //fmain.mnuDuLieu.Enabled = true;
                        //fmain.mnuCapNhat.Enabled = true;
                        //fmain.mnuDangNhap.Enabled = true;
                        //fmain.mnuDoiMatKhau.Enabled = true;
                        //fmain.mnuThoatDangNhap.Enabled = true;
                        
                        MessageBox.Show("Đăng nhập thành công!!", "Thông báo");
                        MyPublics.conMyConnection.Close();
                        this.Close();
                    }
                    else
                    
                        if (intSoLanDN < 2)
                        {
                            MessageBox.Show("Tên Tài Khoản hoặc mật khẩu sai!!!", "Thông báo");
                            intSoLanDN++;
                            txtTenTK.Focus();
                            txtMatKhau.Clear();
                            txtTenTK.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi đăng nhập, From sẽ đóng! ", "Thông báo");
                            MyPublics.conMyConnection.Close();
                            //fmain.mnuDuLieu.Enabled = false;
                            //fmain.mnuCapNhat.Enabled = false;
                            //fmain.mnuDoiMatKhau.Enabled = false;
                            //fmain.mnuThoatDangNhap.Enabled = false;
                            this.Close();
                        }
                    

                }
                else
                {
                    MessageBox.Show("Kết nối không thành công", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi khi thực hiện kết nối", "Thông báo");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
