using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace QuanLyTuyenXeBus
{
    public partial class Controp_QLNhanVien : UserControl
    {
        public Controp_QLNhanVien()
        {
            InitializeComponent();
        }

        private void Controp_QLNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Operation opr = new Operation();
            dataGridView1.DataSource = opr.layTaiKhoanNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Không được bỏ trống");
            }
            else
            {
                Operation opr = new Operation();
                DataTable dt = opr.layTaiKhoan();
                List<String> taikhoan = new List<string>();
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    taikhoan.Add(dt.Rows[i][1].ToString());
                }
                if (taikhoan.Contains(txtTaiKhoan.Text))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại");
                }
                else
                {
                    bool check = opr.themTaiKhoan(txtTaiKhoan.Text, txtMatKhau.Text);
                    LoadData();
                }
                
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Operation opr = new Operation();
            opr.xoaHetDuLieuNhanVien();
            if (dataGridView1.Rows.Count == 1 )
            {

            }
            else
            {
                for(int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.tenTaiKhoan = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    tk.matKhau = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    tk.tenDayDu = dataGridView1.Rows[i].Cells["column4"].Value.ToString();
                    tk.ngayThangNamSinh = dataGridView1.Rows[i].Cells["column5"].Value.ToString();
                    tk.email = dataGridView1.Rows[i].Cells["column6"].Value.ToString();
                    tk.soDienThoai = dataGridView1.Rows[i].Cells["column7"].Value.ToString();
                    opr.taoTaiKhoan(tk);
                }
            }
            LoadData();
        }
    }
}
