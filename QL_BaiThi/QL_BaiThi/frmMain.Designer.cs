namespace QL_BaiThi
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuDuLieu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLopHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrungTam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCapNhat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTheoDoiBaiThi = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBTTheoLop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBTTheoHocKy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNguoiSuDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTienIch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoatDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGioiThieu = new System.Windows.Forms.ToolStripMenuItem();
            this.thoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraCuu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTCTrungTam = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTCMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDuLieu,
            this.mnuCapNhat,
            this.mnuTienIch,
            this.mnuTraCuu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(504, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuDuLieu
            // 
            this.mnuDuLieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLopHoc,
            this.mnuMonHoc,
            this.mnuTrungTam});
            this.mnuDuLieu.Name = "mnuDuLieu";
            this.mnuDuLieu.Size = new System.Drawing.Size(77, 25);
            this.mnuDuLieu.Text = "Dữ Liệu";
            // 
            // mnuLopHoc
            // 
            this.mnuLopHoc.Name = "mnuLopHoc";
            this.mnuLopHoc.Size = new System.Drawing.Size(155, 26);
            this.mnuLopHoc.Text = "Lớp Học";
            // 
            // mnuMonHoc
            // 
            this.mnuMonHoc.Name = "mnuMonHoc";
            this.mnuMonHoc.Size = new System.Drawing.Size(155, 26);
            this.mnuMonHoc.Text = "Môn Học";
            this.mnuMonHoc.Click += new System.EventHandler(this.mnuMonHoc_Click);
            // 
            // mnuTrungTam
            // 
            this.mnuTrungTam.Name = "mnuTrungTam";
            this.mnuTrungTam.Size = new System.Drawing.Size(155, 26);
            this.mnuTrungTam.Text = "Trung Tâm";
            this.mnuTrungTam.Click += new System.EventHandler(this.mnuTrungTam_Click);
            // 
            // mnuCapNhat
            // 
            this.mnuCapNhat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTheoDoiBaiThi,
            this.mnuNguoiSuDung});
            this.mnuCapNhat.Name = "mnuCapNhat";
            this.mnuCapNhat.Size = new System.Drawing.Size(89, 25);
            this.mnuCapNhat.Text = "Cập Nhật";
            // 
            // mnuTheoDoiBaiThi
            // 
            this.mnuTheoDoiBaiThi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBTTheoLop,
            this.mnuBTTheoHocKy});
            this.mnuTheoDoiBaiThi.Name = "mnuTheoDoiBaiThi";
            this.mnuTheoDoiBaiThi.Size = new System.Drawing.Size(198, 26);
            this.mnuTheoDoiBaiThi.Text = "Theo Dõi Bài Thi";
            // 
            // mnuBTTheoLop
            // 
            this.mnuBTTheoLop.Name = "mnuBTTheoLop";
            this.mnuBTTheoLop.Size = new System.Drawing.Size(251, 26);
            this.mnuBTTheoLop.Text = "Theo Lớp";
            this.mnuBTTheoLop.Click += new System.EventHandler(this.mnuBTTheoLop_Click);
            // 
            // mnuBTTheoHocKy
            // 
            this.mnuBTTheoHocKy.Name = "mnuBTTheoHocKy";
            this.mnuBTTheoHocKy.Size = new System.Drawing.Size(251, 26);
            this.mnuBTTheoHocKy.Text = "Theo Học Kỳ/ Năm Học";
            // 
            // mnuNguoiSuDung
            // 
            this.mnuNguoiSuDung.Name = "mnuNguoiSuDung";
            this.mnuNguoiSuDung.Size = new System.Drawing.Size(198, 26);
            this.mnuNguoiSuDung.Text = "Người Sử Dụng";
            this.mnuNguoiSuDung.Click += new System.EventHandler(this.mnuNguoiSuDung_Click);
            // 
            // mnuTienIch
            // 
            this.mnuTienIch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuThoatDangNhap,
            this.mnuDoiMatKhau,
            this.mnuGioiThieu,
            this.thoat});
            this.mnuTienIch.Name = "mnuTienIch";
            this.mnuTienIch.Size = new System.Drawing.Size(79, 25);
            this.mnuTienIch.Text = "Tiện Ích";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(207, 26);
            this.mnuDangNhap.Text = "Đăng Nhập";
            this.mnuDangNhap.Click += new System.EventHandler(this.mnuDangNhap_Click);
            // 
            // mnuThoatDangNhap
            // 
            this.mnuThoatDangNhap.Name = "mnuThoatDangNhap";
            this.mnuThoatDangNhap.Size = new System.Drawing.Size(207, 26);
            this.mnuThoatDangNhap.Text = "Thoát Đăng Nhập";
            this.mnuThoatDangNhap.Click += new System.EventHandler(this.thoátĐăngNhậpToolStripMenuItem_Click);
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(207, 26);
            this.mnuDoiMatKhau.Text = "Đổi Mật Khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuGioiThieu
            // 
            this.mnuGioiThieu.Name = "mnuGioiThieu";
            this.mnuGioiThieu.Size = new System.Drawing.Size(207, 26);
            this.mnuGioiThieu.Text = "Giới Thiệu";
            // 
            // thoat
            // 
            this.thoat.Name = "thoat";
            this.thoat.Size = new System.Drawing.Size(207, 26);
            this.thoat.Text = "Thoát";
            this.thoat.Click += new System.EventHandler(this.thaoToolStripMenuItem_Click);
            // 
            // mnuTraCuu
            // 
            this.mnuTraCuu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTCTrungTam,
            this.mnuTCMonHoc});
            this.mnuTraCuu.Name = "mnuTraCuu";
            this.mnuTraCuu.Size = new System.Drawing.Size(77, 25);
            this.mnuTraCuu.Text = "Tra Cứu";
            // 
            // mnuTCTrungTam
            // 
            this.mnuTCTrungTam.Name = "mnuTCTrungTam";
            this.mnuTCTrungTam.Size = new System.Drawing.Size(155, 26);
            this.mnuTCTrungTam.Text = "Trung Tâm";
            // 
            // mnuTCMonHoc
            // 
            this.mnuTCMonHoc.Name = "mnuTCMonHoc";
            this.mnuTCMonHoc.Size = new System.Drawing.Size(155, 26);
            this.mnuTCMonHoc.Text = "Môn Học";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QL_BaiThi.Properties.Resources.hinh_anh_3d_4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(504, 264);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem mnuLopHoc;
        public System.Windows.Forms.ToolStripMenuItem mnuMonHoc;
        public System.Windows.Forms.ToolStripMenuItem mnuDuLieu;
        public System.Windows.Forms.ToolStripMenuItem mnuTheoDoiBaiThi;
        public System.Windows.Forms.ToolStripMenuItem mnuCapNhat;
        public System.Windows.Forms.ToolStripMenuItem mnuTienIch;
        public System.Windows.Forms.ToolStripMenuItem mnuTrungTam;
        public System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        public System.Windows.Forms.ToolStripMenuItem mnuThoatDangNhap;
        public System.Windows.Forms.ToolStripMenuItem mnuDoiMatKhau;
        public System.Windows.Forms.ToolStripMenuItem mnuGioiThieu;
        public System.Windows.Forms.ToolStripMenuItem thoat;
        public System.Windows.Forms.ToolStripMenuItem mnuBTTheoLop;
        public System.Windows.Forms.ToolStripMenuItem mnuBTTheoHocKy;
        public System.Windows.Forms.ToolStripMenuItem mnuNguoiSuDung;
        public System.Windows.Forms.ToolStripMenuItem mnuTraCuu;
        public System.Windows.Forms.ToolStripMenuItem mnuTCTrungTam;
        public System.Windows.Forms.ToolStripMenuItem mnuTCMonHoc;
    }
}