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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            Operation opr = new Operation();
            DataTable dt = opr.layDuLieuDonVi();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                cboMaDonVi.Items.Add(dt.Rows[i][0]);
            }

            DataTable dt2 = opr.layDuLieuTuyenXe();
            for(int i = 0;i< dt2.Rows.Count; i++)
            {
                cboMaTuyen.Items.Add(dt2.Rows[i][0]);
            }
            DataTable dt3 = opr.layDuLieuXe();
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                cboMaXe.Items.Add(dt3.Rows[i][0]);
            }
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            Operation opr = new Operation();
            dt = opr.layDuLieuTuyenXe();
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = opr.layDuLieuDonVi();
            dataGridView3.DataSource = opr.layDuLieuXe();
            dataGridView4.DataSource = opr.layDuLieuTaiXe();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTuyen.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            cboMaDonVi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenTuyen.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            mskTgBatDau.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            mskTgKetThuc.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            mskTgGianCach.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            rtfLoTrinhLuotDi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            rtfLoTrinhLuotVe.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtLoaiTuyen.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaTuyen.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn tuyến");
            }
            else
            {
                Operation opr = new Operation();
                DataTable dt = opr.layDuLieuDonVi();
                List<String> listMaDonVi = new List<String>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listMaDonVi.Add(dt.Rows[i][0].ToString());
                }
                if(listMaDonVi.Contains(cboMaDonVi.Text) == false)
                {
                    MessageBox.Show("Đơn vị quản lý tuyến xe không tồn tại");
                }
                else
                {
                    if(txtTenTuyen.Text == "")
                    {
                        MessageBox.Show("Tên tuyến xe không hợp lệ");
                    }
                    else
                    {
                        if(mskTgBatDau.Text.Length <= 7)
                        {
                            MessageBox.Show("Thời gian bắt đầu không hợp lệ");
                        }
                        else
                        {
                            if(mskTgKetThuc.Text.Length <= 7)
                            {
                                MessageBox.Show("Thời gian kết thúc không hợp lệ");
                            }
                            else
                            {
                                if(mskTgGianCach.Text[0] == ' ' || mskTgGianCach.Text[1] == ' ')
                                {
                                    MessageBox.Show("Thời gian giãn cách không hợp lệ");
                                }
                                else
                                {
                                    if(rtfLoTrinhLuotDi.Text == "")
                                    {
                                        MessageBox.Show("Lộ trình lượt đi không được bỏ trống");
                                    }
                                    else
                                    {
                                        if(rtfLoTrinhLuotVe.Text == "")
                                        {
                                            MessageBox.Show("Lộ trình lượt về không được bỏ trống");
                                        }
                                        else
                                        {
                                            if(txtLoaiTuyen.Text == "")
                                            {
                                                MessageBox.Show("Loại tuyến không hợp lệ");
                                            }
                                            else
                                            {
                                                //updata data 
                                                TuyenXe updateTuyenXe = new TuyenXe();
                                                updateTuyenXe.maTuyen = txtMaTuyen.Text;
                                                updateTuyenXe.maDonVi = cboMaDonVi.Text;
                                                updateTuyenXe.tenTuyen = txtTenTuyen.Text;
                                                updateTuyenXe.thoiGianBatDau = mskTgBatDau.Text;
                                                updateTuyenXe.thoiGianKetThuc = mskTgKetThuc.Text;
                                                updateTuyenXe.thoiGianGianCach = int.Parse(mskTgGianCach.Text[0].ToString() + mskTgGianCach.Text[1].ToString());
                                                updateTuyenXe.loTrinhLuotDi = rtfLoTrinhLuotDi.Text;
                                                updateTuyenXe.loTrinhLuotVe = rtfLoTrinhLuotVe.Text;
                                                updateTuyenXe.loaiTuyen = txtLoaiTuyen.Text;
                                                bool result = opr.suaDuLieuTuyenXe(updateTuyenXe);
                                                if(result == true)
                                                {
                                                    LoadData();
                                                    MessageBox.Show("Chỉnh sửa thông tin tuyến xe thành công");
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Chỉnh sửa thông tin tuyến xe thất bại");
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

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDonVi.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenDonVi.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoDienThoai.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnThoat1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            if(txtMaDonVi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn đơn vị cần chỉnh sửa");
            }
            else
            {
                if(txtTenDonVi.Text == "")
                {
                    MessageBox.Show("Tên đơn vị không được bỏ trống");
                }
                else
                {
                    if(txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập địa chỉ");
                    }
                    else
                    {
                        String sdt = txtSoDienThoai.Text;
                        int output = 0;
                        bool check = int.TryParse(sdt,out output);
                        if(check == false)
                        {
                            MessageBox.Show("Số điện thoại chưa đúng dạng");
                        }
                        else
                        {
                            if(txtEmail.Text == "")
                            {
                                MessageBox.Show("Chưa nhập email");
                            }
                            else
                            {
                                DonViQLXe updateDonViQLXe = new DonViQLXe();
                                updateDonViQLXe.maDonVi = txtMaDonVi.Text;
                                updateDonViQLXe.tenDonVi = txtTenDonVi.Text;
                                updateDonViQLXe.diaChi = txtDiaChi.Text;
                                updateDonViQLXe.soDienThoai = output;
                                updateDonViQLXe.email = txtEmail.Text;
                                Operation opr = new Operation();
                                bool checkUpdate = opr.suaDuLieuDonVi(updateDonViQLXe);
                                if(checkUpdate == true)
                                {
                                    LoadData();
                                    MessageBox.Show("Chỉnh sửa dữ liệu đơn vị quản lý xe thành công");
                                }
                                else
                                {
                                    MessageBox.Show("Chỉnh sửa thất bại");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaXe.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBienSo.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLoaiXe.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoGhe.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCongSuat.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtNgaySX.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtChuKiBaoHanh.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
            cboMaTuyen.Text = dataGridView3.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnThoat3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLuu3_Click(object sender, EventArgs e)
        {
            if(txtMaXe.Text == "")
            {
                MessageBox.Show("vui lòng chọn xe muốn chỉnh sửa");
            }
            else
            {
                if(txtBienSo.Text == "")
                {
                    MessageBox.Show("Biển số xe không được bỏ trống");
                }
                else
                {
                    if(txtLoaiXe.Text == "")
                    {
                        MessageBox.Show("Loại xe không được bỏ trống");
                    }
                    else
                    {
                        int out_int;
                        bool checkNumber = int.TryParse(txtSoGhe.Text, out out_int);
                        if(checkNumber == false)
                        {
                            MessageBox.Show("Số ghế xe phải là số");
                        }
                        else
                        {
                            int out_int2;
                            bool checkNumber2 = int.TryParse(txtCongSuat.Text, out out_int2);
                            if(checkNumber2 == false)
                            {
                                MessageBox.Show("Công suất xe phải là số");
                            }
                            else
                            {
                                if(txtNgaySX.Text.Length < 10)
                                {
                                    MessageBox.Show("Ngày sản xuất phải có dạng XX/ZZ/YYYY");
                                }
                                else
                                {
                                    int out_int3;
                                    bool checkNumber3 = int.TryParse(txtChuKiBaoHanh.Text, out out_int3);
                                    if(checkNumber3 == false)
                                    {
                                        MessageBox.Show("Chu kì bảo hành phải là số");
                                    }
                                    else
                                    {
                                        List<String> listMaTuyen = new List<String>();
                                        Operation opr = new Operation();
                                        DataTable dt = opr.layDuLieuTuyenXe();
                                        for(int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            listMaTuyen.Add(dt.Rows[i][0].ToString());
                                        }
                                        if(cboMaTuyen.Text == "" || listMaTuyen.Contains(cboMaTuyen.Text) == false)
                                        {
                                            MessageBox.Show("Mã tuyến không hợp lệ");
                                        }
                                        else
                                        {
                                            Xe xe = new Xe();
                                            xe.maXe = txtMaXe.Text;
                                            xe.loaiXe = txtLoaiXe.Text;
                                            xe.bienSo = txtBienSo.Text;
                                            xe.soGhe = out_int;
                                            xe.congSuat = out_int2;
                                            xe.ngaySX = txtNgaySX.Text;
                                            xe.chuKiBaoHanh = out_int3;
                                            xe.maTuyen = int.Parse(cboMaTuyen.Text);
                                            bool checkUpdate = opr.suaDuLieuXe(xe);
                                            if(checkUpdate == true)
                                            {
                                                LoadData();
                                                MessageBox.Show("Chỉnh sửa dữ liệu xe thành công");
                                            }
                                            else
                                            {
                                                MessageBox.Show("Chỉnh sửa dữ liệu xe thất bại");
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

        private void btnThoat4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTaiXe.Text = dataGridView4.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView4.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtNgaySinh.Text = dataGridView4.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtGioiTinh.Text = dataGridView4.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtDiaChiTX.Text = dataGridView4.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtQueQuan.Text = dataGridView4.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtNgayBDHD.Text = dataGridView4.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtLuong.Text = dataGridView4.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtBangLai.Text = dataGridView4.Rows[e.RowIndex].Cells[8].Value.ToString();
            cboMaXe.Text = dataGridView4.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btnLuu4_Click(object sender, EventArgs e)
        {
            if (txtMaTaiXe.Text == "")
            {
                MessageBox.Show("Vui lòng chọn tài xế muốn sửa thông tin");
            }
            else
            {
                if(txtHoTen.Text == "")
                {
                    MessageBox.Show("Họ tên không được để trống");
                }
                else
                {
                    if(txtNgaySinh.Text.Length < 10)
                    {
                        MessageBox.Show("Ngày sinh phải có dạng XX/YY/ZZZZ");
                    }
                    else
                    {
                        List<String> listGioiTinh = new List<String>();
                        listGioiTinh.Add("Nam");
                        listGioiTinh.Add("Nữ");
                        if(listGioiTinh.Contains(txtGioiTinh.Text)==false)
                        {
                            MessageBox.Show("Giới tính phải là Nam hoặc Nữ");
                        }
                        else
                        {
                            if(txtDiaChiTX.Text == "")
                            {
                                MessageBox.Show("Địa chỉ không được bỏ trống");
                            }
                            else
                            {
                                if(txtQueQuan.Text == "")
                                {
                                    MessageBox.Show("Quê quán không được bỏ trống");
                                }
                                else
                                {
                                    if(txtNgayBDHD.Text.Length < 10)
                                    {
                                        MessageBox.Show("Ngày bắt đâu hợp đồng phải có dạng XX/YY/ZZZZ");
                                    }
                                    else
                                    {
                                        float luong;
                                        bool checkSalary = float.TryParse(txtLuong.Text, out luong);
                                        if(checkSalary == false || txtLuong.Text == "")
                                        {
                                            MessageBox.Show("Lương phải là số");
                                        }
                                        else
                                        {
                                            if(txtBangLai.Text == "")
                                            {
                                                MessageBox.Show("Bằng lái không được bỏ trống");
                                            }
                                            else
                                            {
                                                Operation opr = new Operation();
                                                DataTable dt = opr.layDuLieuXe();
                                                List<String> danhSachMaXe = new List<string>();
                                                for(int i = 0; i < dt.Rows.Count; i++)
                                                {
                                                    danhSachMaXe.Add(dt.Rows[i][0].ToString());
                                                }
                                                danhSachMaXe.Add("");
                                                if(danhSachMaXe.Contains(cboMaXe.Text)==false)
                                                {
                                                    MessageBox.Show("Mã xe không hợp lệ");
                                                }
                                                else
                                                {
                                                    TaiXe tx = new TaiXe();
                                                    tx.maTaiXe = txtMaTaiXe.Text;
                                                    tx.hoVaTen = txtHoTen.Text;
                                                    tx.ngaySinh = txtNgaySinh.Text;
                                                    tx.gioiTinh = txtGioiTinh.Text;
                                                    tx.diaChi = txtDiaChiTX.Text;
                                                    tx.queQuan = txtQueQuan.Text;
                                                    tx.ngayBDHopDong = txtNgayBDHD.Text;
                                                    tx.luong = luong;
                                                    tx.bangLai = txtBangLai.Text;
                                                    tx.maXe = cboMaXe.Text;
                                                    bool checkUpdate = opr.suaDuLieuTaiXe(tx);
                                                    if(checkUpdate == true)
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
    }
}
