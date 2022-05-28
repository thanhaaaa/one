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
    public partial class QuanLy : Form
    {
        public QuanLy()
        {
            InitializeComponent();
        }

        private void QuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            contro_QLTX1.BringToFront();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnQuanLiTuyenXe_Click(object sender, EventArgs e)
        {
            contro_QLTX1.BringToFront();
        }

        private void btnQuanLyDonVi_Click(object sender, EventArgs e)
        {
            control_QLDV1.BringToFront();
        }

        private void contro_QLTX1_Load(object sender, EventArgs e)
        {

        }

        private void btnQuanLiXe_Click(object sender, EventArgs e)
        {
            control_QLXe1.BringToFront();
        }

        private void btnQuanLyTaiXe_Click(object sender, EventArgs e)
        {
            control_QLTaiXe1.BringToFront();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            controp_QLNhanVien1.BringToFront();
        }

        
    }
}
