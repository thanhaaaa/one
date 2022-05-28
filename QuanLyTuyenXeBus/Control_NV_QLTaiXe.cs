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
    public partial class Control_NV_QLTaiXe : UserControl
    {
        public Control_NV_QLTaiXe()
        {
            InitializeComponent();
            cboGioiTinh.Items.Add("Nam");
            cboGioiTinh.Items.Add("Nữ");
        }

        private void LoadData()
        {
            Operation opr = new Operation();
            dataGridView1.DataSource = opr.layDuLieuTaiXe();
            DataTable dtMaXe = opr.layDuLieuXe();
            for (int i = 0; i < dtMaXe.Rows.Count; i++)
            {
                if (cboMaXe.Items.Contains(dtMaXe.Rows[i][0]) == false)
                {
                    cboMaXe.Items.Add(dtMaXe.Rows[i][0]);
                }
            }
        }

        private void Control_NV_QLTaiXe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTaiXe.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            mskNgaySinh.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cboGioiTinh.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQueQuan.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            mskNgayBDHopDong.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtLuong.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtBangLai.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            cboMaXe.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void cboGioiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTaiXe.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài xế muốn sửa thông tin");
            }
            else
            {
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Họ tên không được để trống");
                }
                else
                {
                    if (mskNgaySinh.Text.Length < 10)
                    {
                        MessageBox.Show("Ngày sinh phải có dạng XX/YY/ZZZZ");
                    }
                    else
                    {
                        List<String> listGioiTinh = new List<String>();
                        listGioiTinh.Add("Nam");
                        listGioiTinh.Add("Nữ");
                        if (listGioiTinh.Contains(cboGioiTinh.Text) == false)
                        {
                            MessageBox.Show("Giới tính phải là Nam hoặc Nữ");
                        }
                        else
                        {
                            if (txtDiaChi.Text == "")
                            {
                                MessageBox.Show("Địa chỉ không được bỏ trống");
                            }
                            else
                            {
                                if (txtQueQuan.Text == "")
                                {
                                    MessageBox.Show("Quê quán không được bỏ trống");
                                }
                                else
                                {
                                    if (mskNgayBDHopDong.Text.Length < 10)
                                    {
                                        MessageBox.Show("Ngày bắt đâu hợp đồng phải có dạng XX/YY/ZZZZ");
                                    }
                                    else
                                    {
                                        float luong;
                                        bool checkSalary = float.TryParse(txtLuong.Text, out luong);
                                        if (checkSalary == false || txtLuong.Text == "")
                                        {
                                            MessageBox.Show("Lương phải là số");
                                        }
                                        else
                                        {
                                            if (txtBangLai.Text == "")
                                            {
                                                MessageBox.Show("Bằng lái không được bỏ trống");
                                            }
                                            else
                                            {
                                                Operation opr = new Operation();
                                                DataTable dt = opr.layDuLieuXe();
                                                List<String> danhSachMaXe = new List<string>();
                                                for (int i = 0; i < dt.Rows.Count; i++)
                                                {
                                                    danhSachMaXe.Add(dt.Rows[i][0].ToString());
                                                }
                                                danhSachMaXe.Add("");
                                                if (danhSachMaXe.Contains(cboMaXe.Text) == false)
                                                {
                                                    MessageBox.Show("Không có xe có mã xe này");
                                                }
                                                else
                                                {
                                                    TaiXe tx = new TaiXe();
                                                    tx.maTaiXe = txtMaTaiXe.Text;
                                                    tx.hoVaTen = txtHoTen.Text;
                                                    tx.ngaySinh = mskNgaySinh.Text;
                                                    tx.gioiTinh = cboGioiTinh.Text;
                                                    tx.diaChi = txtDiaChi.Text;
                                                    tx.queQuan = txtQueQuan.Text;
                                                    tx.ngayBDHopDong = mskNgayBDHopDong.Text;
                                                    tx.luong = luong;
                                                    tx.bangLai = txtBangLai.Text;
                                                    tx.maXe = cboMaXe.Text;
                                                    bool checkUpdate = opr.suaDuLieuTaiXe(tx);
                                                    if (checkUpdate == true)
                                                    {
                                                        LoadData();
                                                        MessageBox.Show("Sửa dữ liệu tài xế thành công");
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Sửa dữ liệu thất bại");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                txtTimKiem.text = "Tìm theo mã tài xế, Họ và tên ....";
            }
        }

        private void txtTimKiem_OnTextChange(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                LoadData();
            }
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.text = "";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.text != "" && txtTimKiem.text != "Tìm theo mã tài xế, Họ và tên ....")
            {
                Operation opr = new Operation();
                dataGridView1.DataSource = opr.timKiemTheoMaTaiXe(txtTimKiem.text);
            }
        }
    }
}
