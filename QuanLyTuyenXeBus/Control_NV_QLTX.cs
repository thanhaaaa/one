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
    public partial class Control_NV_QLTX : UserControl
    {
        public Control_NV_QLTX()
        {
            InitializeComponent();
        }

        private void Control_NV_QLTX_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Operation opr = new Operation();
            dataGridView1.DataSource = opr.layDuLieuTuyenXe();
            DataTable dt = opr.layDuLieuDonVi();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cboMaDonVi.Items.Contains(dt.Rows[i][0]) == false)
                    cboMaDonVi.Items.Add(dt.Rows[i][0]);
            }
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaTuyen.Text == "")
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
                if (listMaDonVi.Contains(cboMaDonVi.Text) == false)
                {
                    MessageBox.Show("Đơn vị quản lý tuyến xe không tồn tại");
                }
                else
                {
                    if (txtTenTuyen.Text == "")
                    {
                        MessageBox.Show("Tên tuyến xe không hợp lệ");
                    }
                    else
                    {
                        if (mskTgBatDau.Text.Length <= 7)
                        {
                            MessageBox.Show("Thời gian bắt đầu không hợp lệ");
                        }
                        else
                        {
                            if (mskTgKetThuc.Text.Length <= 7)
                            {
                                MessageBox.Show("Thời gian kết thúc không hợp lệ");
                            }
                            else
                            {
                                if (mskTgGianCach.Text[0] == ' ' || mskTgGianCach.Text[1] == ' ')
                                {
                                    MessageBox.Show("Thời gian giãn cách không hợp lệ");
                                }
                                else
                                {
                                    if (rtfLoTrinhLuotDi.Text == "")
                                    {
                                        MessageBox.Show("Lộ trình lượt đi không được bỏ trống");
                                    }
                                    else
                                    {
                                        if (rtfLoTrinhLuotVe.Text == "")
                                        {
                                            MessageBox.Show("Lộ trình lượt về không được bỏ trống");
                                        }
                                        else
                                        {
                                            if (txtLoaiTuyen.Text == "")
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
                                                if (result == true)
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

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.text = "";
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                txtTimKiem.text = "Tìm theo mã tuyến,tên tuyến ....";
            }
        }

        private void txtTimKiem_OnTextChange(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                LoadData();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.text != "" && txtTimKiem.text != "Tìm theo mã tuyến,tên tuyến ....")
            {
                Operation opr = new Operation();
                dataGridView1.DataSource = opr.timKiemTheoMaTuyenXe(txtTimKiem.text);
            }
        }
    }
}