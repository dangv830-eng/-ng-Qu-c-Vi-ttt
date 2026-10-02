using System;
using System.Collections.Generic;
using System.Linq;

namespace LogisticsAutoSpeed
{
    // ==========================================
    // 1. ABSTRACT CLASS: PhuongTien (Trừu tượng & Đóng gói)
    // ==========================================
    public abstract class PhuongTien
    {
        // Private Fields
        private string _maPT;
        private string _tenHang;
        private int _namSanXuat;
        private decimal _giaGoc;

        // Properties với Validation Encapsulation
        public string MaPT
        {
            get => _maPT;
            set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value.Trim();
        }

        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống!");
                _tenHang = value.Trim();
            }
        }

        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value < 1900 || value > currentYear)
                {
                    throw new ArgumentException($"Năm sản xuất không hợp lệ! (Phải từ 1900 đến {currentYear})");
                }
                _namSanXuat = value;
            }
        }

        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");
                _giaGoc = value;
            }
        }

        // Constructor khởi tạo đầy đủ
        protected PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat; // Kích hoạt validation trong setter
            GiaGoc = giaGoc;
        }

        // Abstract Method (Đa hình)
        public abstract decimal TinhGiaLanBanh();

        // Virtual Method
        public virtual string GetInfo()
        {
            return $"Mã PT: {MaPT} | Hãng: {TenHang} | Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc:N0} VNĐ";
        }
    }

    // ==========================================
    // 2. CLASS DERIVED: OTo (Kế thừa từ PhuongTien)
    // ==========================================
    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
                _dungTichDongCo = value;
            }
        }

        public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int soChoNgoi, double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        // Ghi đè phương thức TinhGiaLanBanh()
        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
            {
                // Giá = Giá gốc + 12% Lệ phí trước bạ + 30% Thuế TTĐB
                return GiaGoc + (0.12m * GiaGoc) + (0.30m * GiaGoc);
            }
            else
            {
                // Giá = Giá gốc + 10% Lệ phí trước bạ
                return GiaGoc + (0.10m * GiaGoc);
            }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} | Số chỗ: {SoChoNgoi} | Dung tích động cơ: {DungTichDongCo}L | Giá lăn bánh: {TinhGiaLanBanh():N0} VNĐ";
        }
    }

    // ==========================================
    // 3. CLASS DERIVED: XeMay (Kế thừa từ PhuongTien)
    // ==========================================
    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xylanh phải lớn hơn 0 cc!");
                _dungTichXylanh = value;
            }
        }

        public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        // Ghi đè phương thức TinhGiaLanBanh()
        public override decimal TinhGiaLanBanh()
        {
            if (DungTichXylanh < 175)
            {
                // Thuế trước bạ 2%
                return GiaGoc + (0.02m * GiaGoc);
            }
            else
            {
                // Thuế trước bạ 5%
                return GiaGoc + (0.05m * GiaGoc);
            }
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} | Dung tích xylanh: {DungTichXylanh} cc | Giá lăn bánh: {TinhGiaLanBanh():N0} VNĐ";
        }
    }

    // ==========================================
    // 4. CLASS: QuanLyPhuongTien (Quản lý tập hợp)
    // ==========================================
    public class QuanLyPhuongTien
    {
        private readonly List<PhuongTien> _danhSachPT = new List<PhuongTien>();

        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt != null)
            {
                _danhSachPT.Add(pt);
            }
        }

        public void DisplayAll()
        {
            Console.WriteLine("\n=== DANH SÁCH TOÀN BỘ PHƯƠNG TIỆN ===");
            if (_danhSachPT.Count == 0)
            {
                Console.WriteLine("Danh sách trống!");
                return;
            }

            foreach (var pt in _danhSachPT)
            {
                Console.WriteLine(pt.GetInfo());
            }
        }

        // Tìm phương tiện có Giá lăn bánh cao nhất bằng LINQ
        public PhuongTien FindMaxGiaLanBanh()
        {
            if (_danhSachPT.Count == 0) return null;
            return _danhSachPT.MaxBy(pt => pt.TinhGiaLanBanh());
        }

        // Tìm kiếm theo tên hãng (không phân biệt chữ hoa/thường) bằng LINQ
        public List<PhuongTien> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<PhuongTien>();

            return _danhSachPT
                .Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

    // ==========================================
    // 5. KỊCH BẢN KIỂM THỬ (TEST CASES RUNNER)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            QuanLyPhuongTien qlpt = new QuanLyPhuongTien();

            Console.WriteLine("==================================================");
            Console.WriteLine("   HỆ THỐNG QUẢN LÝ PHƯƠNG TIỆN - AUTOSPEED");
            Console.WriteLine("==================================================\n");

            // ----------------------------------------------------
            // TC01: Kiểm tra Validation Năm sản xuất
            // ----------------------------------------------------
            Console.WriteLine("--- RUNNING TEST CASE TC01 ---");
            try
            {
                Console.WriteLine("Thử khởi tạo Ô tô có NamSanXuat = 1850...");
                OTo otoLoi = new OTo("OTO001", "Toyota", 1850, 500000000m, 5, 2.0);
                qlpt.AddPhuongTien(otoLoi);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[BẮT NGOẠI LỆ THÀNH CÔNG]: {ex.Message}");
            }

            // ----------------------------------------------------
            // TC02: Kiểm tra Tính Giá Lăn Bánh Ô tô (5 chỗ)
            // ----------------------------------------------------
            Console.WriteLine("\n--- RUNNING TEST CASE TC02 ---");
            OTo oto5Cho = new OTo("OTO002", "Mercedes", 2023, 1000000000m, 5, 2.0);
            qlpt.AddPhuongTien(oto5Cho);

            decimal giaLanBanhOto = oto5Cho.TinhGiaLanBanh();
            Console.WriteLine($"Ô tô 5 chỗ - Giá gốc: 1,000,000,000 VNĐ");
            Console.WriteLine($"Tính toán Giá lăn bánh: {giaLanBanhOto:N0} VNĐ");
            Console.WriteLine($"Kỳ vọng: 1,420,000,000 VNĐ -> {(giaLanBanhOto == 1420000000m ? "PASSED" : "FAILED")}");

            // ----------------------------------------------------
            // TC03: Kiểm tra Tính Giá Lăn Bánh Xe máy (150cc)
            // ----------------------------------------------------
            Console.WriteLine("\n--- RUNNING TEST CASE TC03 ---");
            XeMay xeMay150 = new XeMay("XM001", "Honda", 2022, 50000000m, 150);
            qlpt.AddPhuongTien(xeMay150);

            decimal giaLanBanhXeMay = xeMay150.TinhGiaLanBanh();
            Console.WriteLine($"Xe máy 150cc - Giá gốc: 50,000,000 VNĐ");
            Console.WriteLine($"Tính toán Giá lăn bánh: {giaLanBanhXeMay:N0} VNĐ");
            Console.WriteLine($"Kỳ vọng: 51,000,000 VNĐ -> {(giaLanBanhXeMay == 51000000m ? "PASSED" : "FAILED")}");

            // ----------------------------------------------------
            // TC04: Kiểm tra Đa hình trong List<PhuongTien>
            // ----------------------------------------------------
            Console.WriteLine("\n--- RUNNING TEST CASE TC04 ---");
            Console.WriteLine("Duyệt List<PhuongTien> và gọi TinhGiaLanBanh() đa hình:");
            qlpt.DisplayAll();

            // ----------------------------------------------------
            // TC05: Kiểm tra Tìm Giá Lăn Bánh Max
            // ----------------------------------------------------
            Console.WriteLine("\n--- RUNNING TEST CASE TC05 ---");
            PhuongTien ptMax = qlpt.FindMaxGiaLanBanh();
            if (ptMax != null)
            {
                Console.WriteLine($"Phương tiện có giá lăn bánh lớn nhất tìm được:");
                Console.WriteLine(ptMax.GetInfo());
                bool isCorrectMax = ptMax.MaPT == "OTO002" && ptMax.TinhGiaLanBanh() == 1420000000m;
                Console.WriteLine($"Kỳ vọng là Ô tô 5 chỗ (1.42 tỷ VNĐ) -> {(isCorrectMax ? "PASSED" : "FAILED")}");
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine("          HOÀN THÀNH KIỂM THỬ TẤT CẢ TC");
            Console.WriteLine("==================================================");
        }
    }
}