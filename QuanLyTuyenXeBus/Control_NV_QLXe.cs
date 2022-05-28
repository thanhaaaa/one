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
    public partial class Control_NV_QLXe : UserControl
    {
        public Control_NV_QLXe()
        {
            InitializeComponent();
        }

        private void Control_NV_QLXe_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Operation opr = new Operation();
            dataGridView1.DataSource = opr.layDuLieuXe();
            DataTable dt = opr.layDuLieuTuyenXe();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (cboMaTuyen.Items.Contains(dt.Rows[i][0]) == false)
                    cboMaTuyen.Items.Add(dt.Rows[i][0]);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaXe.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtBienSo.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLoaiXe.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoGhe.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtCongSuat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            mskNgaySanXuat.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtChuKiBaoHanh.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cboMaTuyen.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaXe.Text == "")
            {
                MessageBox.Show("vui lòng chọn xe muốn chỉnh sửa");
            }
            else
            {
                if (txtBienSo.Text == "")
                {
                    MessageBox.Show("Biển số xe không được bỏ trống");
                }
                else
                {
                    if (txtLoaiXe.Text == "")
                    {
                        MessageBox.Show("Loại xe không được bỏ trống");
                    }
                    else
                    {
                        int out_int;
                        bool checkNumber = int.TryParse(txtSoGhe.Text, out out_int);
                        if (checkNumber == false)
                        {
                            MessageBox.Show("Số ghế xe phải là số");
                        }
                        else
                        {
                            int out_int2;
                            bool checkNumber2 = int.TryParse(txtCongSuat.Text, out out_int2);
                            if (checkNumber2 == false)
                            {
                                MessageBox.Show("Công suất xe phải là số");
                            }
                            else
                            {
                                if (mskNgaySanXuat.Text.Length < 10)
                                {
                                    MessageBox.Show("Ngày sản xuất phải có dạng XX/ZZ/YYYY");
                                }
                                else
                                {
                                    int out_int3;
                                    bool checkNumber3 = int.TryParse(txtChuKiBaoHanh.Text, out out_int3);
                                    if (checkNumber3 == false)
                                    {
                                        MessageBox.Show("Chu kì bảo hành phải là số");
                                    }
                                    else
                                    {
                                        List<String> listMaTuyen = new List<String>();
                                        Operation opr = new Operation();
                                        DataTable dt = opr.layDuLieuTuyenXe();
                                        for (int i = 0; i < dt.Rows.Count; i++)
                                        {
                                            listMaTuyen.Add(dt.Rows[i][0].ToString());
                                        }
                                        if (cboMaTuyen.Text == "" || listMaTuyen.Contains(cboMaTuyen.Text) == false)
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
                                            xe.ngaySX = mskNgaySanXuat.Text;
                                            xe.chuKiBaoHanh = out_int3;
                                            xe.maTuyen = int.Parse(cboMaTuyen.Text);
                                            bool checkUpdate = opr.suaDuLieuXe(xe);
                                            if (checkUpdate == true)
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

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.text = "";
        }

        private void txtTimKiem_OnTextChange(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                LoadData();
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                txtTimKiem.text = "Tìm theo mã xe, mã tuyến ....";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.text != "" && txtTimKiem.text != "Tìm theo mã xe, mã tuyến ....")
            {
                Operation opr = new Operation();
                dataGridView1.DataSource = opr.timKiemTheoMaXe(txtTimKiem.text);
            }
        }
    }
}
