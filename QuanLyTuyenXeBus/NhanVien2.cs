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
    public partial class NhanVien2 : Form
    {
        public NhanVien2()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            control_NV_QLTX1.BringToFront();
        }

        private void NhanVien2_Load(object sender, EventArgs e)
        {
            control_NV_QLTX1.BringToFront();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            control_NV_QLDV1.BringToFront();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            control_NV_QLTaiXe1.BringToFront();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            control_NV_QLXe1.BringToFront();
        }
    }
}
