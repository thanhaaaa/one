using BEL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Operation
    {
        public Dbconnection db = new Dbconnection();
        public TaiKhoan tk = new TaiKhoan();

        public DataTable login(TaiKhoan info)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaiKhoan where TenTaiKhoan='" + info.tenTaiKhoan + "' and MatKhau='" + info.matKhau + "'";
            return db.ExeReader(cmd);
        }

        public DataTable layTaiKhoanNhanVien()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaiKhoan where ChucVu='nhanvien'";
            return db.ExeReader(cmd);
        }

        public DataTable layTaiKhoan()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaiKhoan";
            return db.ExeReader(cmd);
        }

        public bool taoTaiKhoan(TaiKhoan tk)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into TaiKhoan(TenTaiKhoan,MatKhau,TenDayDu,NgayThangNamSinh,Email,SoDienThoai,ChucVu) values ('" + tk.tenTaiKhoan + "','" + tk.matKhau + "',N'"+tk.tenDayDu+"','"+tk.ngayThangNamSinh+"','"+tk.email+"','"+tk.soDienThoai+"','nhanvien')";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themTaiKhoan(String taiKhoan,String matKhau)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into TaiKhoan(TenTaiKhoan,MatKhau,ChucVu) values ('"+taiKhoan+"','"+matKhau+"','nhanvien')";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable layDuLieuTuyenXe()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TuyenXe order by MaTuyen";
            return db.ExeReader(cmd);
        }

        public DataTable layDuLieuDonVi()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DonViQLXe";
            return db.ExeReader(cmd);
        }

        public DataTable layDuLieuXe()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Xe";
            return db.ExeReader(cmd);
        }

        public DataTable layDuLieuTaiXe()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaiXe";
            return db.ExeReader(cmd);
        }

        public bool suaDuLieuTuyenXe(TuyenXe tuyenXe)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update TuyenXe set MaDonVi=N'"+tuyenXe.maDonVi+"',TenTuyen=N'"+tuyenXe.tenTuyen+"',ThoiGianBatDau=N'"+tuyenXe.thoiGianBatDau+"',ThoiGianKetThuc=N'"+tuyenXe.thoiGianKetThuc+"',ThoiGianGianCach=N'"+tuyenXe.thoiGianGianCach+"',LoTrinhLuotDi=N'"+tuyenXe.loTrinhLuotDi+"',LoTrinhLuotVe=N'"+tuyenXe.loTrinhLuotVe+"',LoaiTuyen=N'"+tuyenXe.loaiTuyen+"' where MaTuyen='"+tuyenXe.maTuyen+"'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool suaDuLieuDonVi(DonViQLXe dvql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update DonViQLXe set TenDonVi=N'" + dvql.tenDonVi + "',DiaChi=N'" + dvql.diaChi + "',SoDienThoai=N'" + dvql.soDienThoai + "',Email=N'" + dvql.email + "' where MaDonVi='" + dvql.maDonVi + "'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool suaDuLieuXe(Xe xe)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Xe set BienSo=N'" + xe.bienSo + "',LoaiXe=N'" + xe.loaiXe + "',SoGhe=N'" + xe.soGhe + "',CongSuat=N'" + xe.congSuat + "',NgaySX=N'"+xe.ngaySX+"',ChuKiBaoHanh=N'"+xe.chuKiBaoHanh+"',MaTuyen=N'"+xe.maTuyen+"' where MaXe='" + xe.maXe + "'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Boolean suaDuLieuTaiXe(TaiXe tx)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update TaiXe set HoVaTen=N'" + tx.hoVaTen + "',NgaySinh=N'" + tx.ngaySinh + "',GioiTinh=N'" + tx.gioiTinh + "',DiaChi=N'" + tx.diaChi + "',QueQuan=N'" + tx.queQuan + "',NgayBDHopDong=N'" + tx.ngayBDHopDong + "',Luong='"+tx.luong+"',BangLai=N'"+tx.bangLai+"',MaXe=N'"+tx.maXe+"' where MaTX='" + tx.maTaiXe + "'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Boolean themDuLieuTuyenXe(TuyenXe tx)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into TuyenXe(MaTuyen,MaDonVi,TenTuyen,ThoiGianBatDau,ThoiGianKetThuc,ThoiGianGianCach,LoTrinhLuotDi,LoTrinhLuotVe,LoaiTuyen) values (N'"+tx.maTuyen+"',N'"+tx.maDonVi+"',N'"+tx.tenTuyen+"',N'"+tx.thoiGianBatDau+"',N'"+tx.thoiGianKetThuc+"','"+tx.thoiGianGianCach+"',N'"+tx.loTrinhLuotDi+"',N'"+tx.loTrinhLuotVe+"',N'"+tx.loaiTuyen+"')";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean xoaDuLieuTyenXe(String maTuyen)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from TuyenXe where MaTuyen='"+maTuyen+"'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable timKiemTheoMaTuyenXe(String maXe)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TuyenXe where MaTuyen like '%"+maXe+ "%' or TenTuyen like N'%" + maXe + "%'";
            return db.ExeReader(cmd);
        }

        public DataTable timKiemTheoDonVi(String maDV)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from DonViQLXe where MaDonVi like '%" + maDV + "%' or TenDonVi like N'%" + maDV + "%'";
            return db.ExeReader(cmd);
        }

        public DataTable timKiemTheoMaXe(String maXe)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Xe where MaXe like '%" + maXe + "%' or MaTuyen like N'%" + maXe + "%'";
            return db.ExeReader(cmd);
        }

        public bool xoaDuLieuDonVi(String maDonVi)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from DonViQLXe where MaDonVi='" + maDonVi + "'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool themDonViQLXe(DonViQLXe dvql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into DonViQLXe(MaDonVi,TenDonVi,DiaChi,SoDienThoai,Email) values (N'"+dvql.maDonVi+"',N'"+dvql.tenDonVi+"',N'"+dvql.diaChi+"',N'"+dvql.soDienThoai+"',N'"+dvql.email+"')";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool xoaXe(String maxe)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Xe where MaXe='"+maxe+"'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool themDuLieuXe(Xe xe)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Xe values(N'"+xe.maXe+"',N'"+xe.bienSo+"',N'"+xe.loaiXe+"',N'"+xe.soGhe+"',N'"+xe.congSuat+"',N'"+xe.ngaySX+"',N'"+xe.chuKiBaoHanh+"',N'"+xe.maTuyen+"')";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool themTaiXe(TaiXe taiXe)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into TaiXe values(N'"+taiXe.maTaiXe+"',N'"+taiXe.hoVaTen+"',N'"+taiXe.ngaySinh+"',N'"+taiXe.gioiTinh+"',N'"+taiXe.diaChi+"',N'"+taiXe.queQuan+"',N'"+taiXe.ngayBDHopDong+"',N'"+taiXe.luong+"',N'"+taiXe.bangLai+"',N'"+taiXe.maXe+"')";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool xoaTaiXe(String maTaiXe)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from TaiXe where MaTX = '"+maTaiXe+"'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DataTable timKiemTheoMaTaiXe(String maTaiXe)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from TaiXe where MaTX like '%" + maTaiXe + "%' or HoVaTen like N'%" + maTaiXe + "%'";
            return db.ExeReader(cmd);
        }

        public bool xoaHetDuLieuNhanVien()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from TaiKhoan where ChucVu = 'nhanvien'";
                db.ExeNonQuery(cmd);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
