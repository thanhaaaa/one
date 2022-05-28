using BAL;
using BEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTuyenXeBus
{
    public partial class frmDangNhap : Form
    {
        public TaiKhoan taiKhoan = new TaiKhoan();
        public frmDangNhap()
        {
            InitializeComponent();
            txtPassWord.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassWord.Text == "")
            {
                MessageBox.Show("Nhập thiếu tên đăng nhập hoặc khẩu");
            }
            else
            {
                taiKhoan.tenTaiKhoan = txtUserName.Text;
                taiKhoan.matKhau = txtPassWord.Text;
                DataTable dt = new DataTable();
                Operation opr = new Operation();
                dt = opr.login(taiKhoan);
                if (dt.Rows.Count > 0)
                {
                    String phanQuyen = dt.Rows[0][7].ToString();
                    if (phanQuyen.Equals("quanly"))
                    {
                        this.Hide();
                        QuanLy ql = new QuanLy();
                        ql.Show();
                        
                    }
                    else if (phanQuyen.Equals("nhanvien"))
                    {
                        this.Hide();
                        NhanVien2 nv = new NhanVien2();
                        nv.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
        }

        private void frmDangNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtUserName;
        }

    }
}
