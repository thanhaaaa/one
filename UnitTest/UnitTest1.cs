using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BEL;
using System.Data;
using BAL;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Operation opr;
        [TestMethod]
        public void TestLogin()
        {
            opr = new Operation();
            TaiKhoan tk = new TaiKhoan();
            tk.tenTaiKhoan = "admin";
            tk.matKhau = "123456";
            DataTable dt = opr.login(tk);
            Assert.AreEqual("admin", dt.Rows[0][1].ToString());
        }

        [TestMethod]
        public void TestLogin1()
        {
            opr = new Operation();
            TaiKhoan tk = new TaiKhoan();
            tk.tenTaiKhoan = "taikhoantambay";
            tk.matKhau = "123456";
            DataTable dt = opr.login(tk);
            Assert.AreEqual(0,dt.Rows.Count );
        }

        [TestMethod]
        public void TestLayTaiKhoanNhanVien()
        {
            opr = new Operation();
            DataTable dt = opr.layTaiKhoanNhanVien();
            Assert.AreEqual("nhanvien", dt.Rows[0][7].ToString());
        }

        [TestMethod]
        public void TestLayTaiKhoan()
        {
            opr = new Operation();
            DataTable dt = opr.layTaiKhoan();
            int check = 0;
            if(dt.Rows.Count > 0)
            {
                check = 1000;
            }
            Assert.AreEqual(1000,check);
        }

        [TestMethod]
        public void TestTaoTaiKhoan()
        {
            opr = new Operation();
            TaiKhoan tk = new TaiKhoan();
            tk.tenTaiKhoan = "nhanvien2";
            tk.matKhau = "000000";
            bool kiemTraTaoTaiKhoan = opr.taoTaiKhoan(tk);
            bool kiemTraTaoTaiKhoan2 = opr.themTaiKhoan("nhanvien", "123456");
            Assert.AreEqual(true, kiemTraTaoTaiKhoan);
            Assert.AreEqual(true, kiemTraTaoTaiKhoan2);
            opr.xoaHetDuLieuNhanVien();
            opr.themTaiKhoan("nhanvien", "123456");
        }

        [TestMethod]
        public void TestLayDuLieuTuyenXe()
        {
            opr = new Operation();
            DataTable dt = opr.layDuLieuTuyenXe();
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestLayDuLieuDonVi()
        {
            opr = new Operation();
            DataTable dt = opr.layDuLieuDonVi();
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestLayDuLieuXe()
        {
            opr = new Operation();
            DataTable dt = opr.layDuLieuXe();
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
        }


        [TestMethod]
        public void TestLayDuTaiXe()
        {
            opr = new Operation();
            DataTable dt = opr.layDuLieuTaiXe();
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestTimKiemTheoMaXe()
        {
            opr = new Operation();
            DataTable dt = opr.timKiemTheoMaXe("X1"); //tuyen nay chac chan co trong database
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
            DataTable dt2 = opr.timKiemTheoMaXe("72098749028402"); //tuyen nay chac chan khong co
            Assert.AreEqual(false, dt2.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestTimKiemTheoMaTuyeXe()
        {
            opr = new Operation();
            DataTable dt = opr.timKiemTheoMaTuyenXe("86"); //tuyen nay chac chan co trong database
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
            DataTable dt2 = opr.timKiemTheoMaTuyenXe("72098749028402"); //tuyen nay chac chan khong co
            Assert.AreEqual(false, dt2.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestTimKiemTheoMaDonVi()
        {
            opr = new Operation();
            DataTable dt = opr.timKiemTheoDonVi("DV1"); //Đơn vị này chắc chắn có
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
            DataTable dt2 = opr.timKiemTheoDonVi("72098749028402"); //Đơn vị này chắc chắn không có
            Assert.AreEqual(false, dt2.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestTimKiemTheoMaTaiXe()
        {
            opr = new Operation();
            DataTable dt = opr.timKiemTheoMaTaiXe("TX1"); //tai Xe này có
            Assert.AreEqual(true, dt.Rows.GetEnumerator().MoveNext());
            DataTable dt2 = opr.timKiemTheoMaTaiXe("72098749028402"); //Tai Xe này không có
            Assert.AreEqual(false, dt2.Rows.GetEnumerator().MoveNext());
        }

        [TestMethod]
        public void TestThemTuyenXe()
        {
            opr = new Operation();
            TuyenXe tx = new TuyenXe();
            tx.maTuyen = "86";//đã tồn tại
            bool check = opr.themDuLieuTuyenXe(tx);
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TestXoaDuLieuTuyenXe()
        {
            opr = new Operation();
            bool check = opr.xoaDuLieuTyenXe("10000");
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestSuaDuLieuTuyenXe()
        {
            opr = new Operation();
            bool check = opr.suaDuLieuTuyenXe(new TuyenXe());
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestThemDuLieuDonVi()
        {
            opr = new Operation();
            DonViQLXe dvql = new DonViQLXe();
            dvql.maDonVi = "DV1"; //da co trong database
            bool check = opr.themDonViQLXe(dvql);
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TestXoaDuLieuDonVi()
        {
            opr = new Operation();
            bool check = opr.xoaDuLieuDonVi("abc");
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestSuaDuLieuDonVi()
        {
            opr = new Operation();
            bool check = opr.suaDuLieuDonVi(new DonViQLXe());
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestThemDULieuXe()
        {
            opr = new Operation();
            Xe xe = new Xe();
            xe.maXe = "X1"; //da ton tai
            bool check = opr.themDuLieuXe(xe);
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TestXoaDuLieuXe()
        {
            opr = new Operation();
            bool check = opr.xoaXe("9180293801293");
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestChinhSuaDuLieuXe()
        {
            opr = new Operation();
            Xe xe = new Xe();
            xe.maXe = "3804982304"; 
            bool check = opr.suaDuLieuXe(xe);
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestThemDuLieuTaiXe()
        {
            opr = new Operation();
            TaiXe xe = new TaiXe();
            xe.maTaiXe = "TX1"; //da ton tai
            bool check = opr.themTaiXe(xe);
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void TestXoaDuLieuTaiXe()
        {
            opr = new Operation();
            bool check = opr.xoaTaiXe("9180293801293");
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        public void TestChinhSuaDuLieuTaiXe()
        {
            opr = new Operation();
            TaiXe xe = new TaiXe();
            xe.maXe = "3804982304";
            bool check = opr.suaDuLieuTaiXe(xe);
            Assert.AreEqual(true, check);
        }


    }
}
