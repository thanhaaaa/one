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
    public partial class Control_QLDV : UserControl
    {
        public Control_QLDV()
        {
            InitializeComponent();
        }

        private void Control_QLDV_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            Operation opr = new Operation();
            dataGridView1.DataSource = opr.layDuLieuDonVi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDonVi.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenDonVi.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtSoDienThoai.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.text = "";
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (txtTimKiem.text == "")
            {
                txtTimKiem.text = "Tìm theo mã đơn vị, tên đơn vị ....";
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.text != "" && txtTimKiem.text != "Tìm theo mã đơn vị, tên đơn vị ....")
            {
                Operation opr = new Operation();
                dataGridView1.DataSource = opr.timKiemTheoDonVi(txtTimKiem.text);
            }
        }

        private void txtTimKiem_OnTextChange(object sender, EventArgs e)
        {
            if(txtTimKiem.text == "")
            {
                LoadData();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn đơn vị cần chỉnh sửa");
            }
            else
            {
                if (txtTenDonVi.Text == "")
                {
                    MessageBox.Show("Tên đơn vị không được bỏ trống");
                }
                else
                {
                    if (txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập địa chỉ");
                    }
                    else
                    {
                        String sdt = txtSoDienThoai.Text;
                        int output = 0;
                        bool check = int.TryParse(sdt, out output);
                        if (check == false)
                        {
                            MessageBox.Show("Số điện thoại chưa đúng dạng");
                        }
                        else
                        {
                            if (txtEmail.Text == "")
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
                                if (checkUpdate == true)
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn đơn vị cần xóa");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn vị " + txtMaDonVi.Text, "Thông báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Operation opr = new Operation();
                    DataTable dt = opr.layDuLieuTuyenXe();
                    int soXeDangQuanLy = 0;
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        if(dt.Rows[i][1].ToString() == txtMaDonVi.Text)
                        {
                            soXeDangQuanLy++;
                        }
                    }
                    if(soXeDangQuanLy == 0)
                    {
                        bool check = opr.xoaDuLieuDonVi(txtMaDonVi.Text);
                        if (check == true)
                        {
                            LoadData();
                            MessageBox.Show("Xóa dữ liệu đơn vị thành công");
                        }
                        else
                        {
                            MessageBox.Show("Đơn vị không tồn tại");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Đơn vị này đang quản lý " + soXeDangQuanLy+" tuyến xe, không được phép xóa");
                    }   
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
               
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaDonVi.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn đơn vị cần chỉnh sửa");
            }
            else
            {
                if (txtTenDonVi.Text == "")
                {
                    MessageBox.Show("Tên đơn vị không được bỏ trống");
                }
                else
                {
                    if (txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Bạn chưa nhập địa chỉ");
                    }
                    else
                    {
                        String sdt = txtSoDienThoai.Text;
                        int output = 0;
                        bool check = int.TryParse(sdt, out output);
                        if (check == false)
                        {
                            MessageBox.Show("Số điện thoại chưa đúng dạng");
                        }
                        else
                        {
                            if (txtEmail.Text == "")
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
                                bool checkUpdate = opr.themDonViQLXe(updateDonViQLXe);
                                if (checkUpdate == true)
                                {
                                    LoadData();
                                    MessageBox.Show("Thêm đơn vị quản lý xe thành công");
                                }
                                else
                                {
                                    MessageBox.Show("Mã đơn vị đã tồn tại");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
