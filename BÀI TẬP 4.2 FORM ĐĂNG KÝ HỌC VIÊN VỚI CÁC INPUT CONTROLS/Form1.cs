using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BÀI_TẬP_4._2_FORM_ĐĂNG_KÝ_HỌC_VIÊN_VỚI_CÁC_INPUT_CONTROLS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class KhoaHoc
        {
            public string MaKH { get; set; }
            public string TenKH { get; set; }
        }
        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tạo danh sách khóa học
            List<KhoaHoc> danhSachKH = new List<KhoaHoc>()
            {
                new KhoaHoc() { MaKH = "KH01", TenKH = "Lập trình C# cơ bản" },
                new KhoaHoc() { MaKH = "KH02", TenKH = "Lập trình Web ASP.NET" },
                new KhoaHoc() { MaKH = "KH03", TenKH = "Cơ sở dữ liệu SQL Server" }
            };

            // Tiến hành Binding Data
            cboCourse.DataSource = danhSachKH;
            cboCourse.DisplayMember = "TenKH"; // Hiển thị tên khóa học cho người dùng xem
            cboCourse.ValueMember = "MaKH";    // Giữ lại mã khóa học để code xử lý ngầm
        }

       

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            string sdt = mtxtPhone.Text;
            string ngaySinh = dtpBirthDate.Value.ToString("dd/MM/yyyy");

            // Lấy tên khóa học được chọn (DisplayMember)
            string khoaHoc = cboCourse.Text;

            // Nếu bạn có dùng RadioButton (ví dụ radNam.Checked) thì kiểm tra thêm ở đây

            // Tổng hợp thành một chuỗi
            string thongTin = "XÁC NHẬN THÔNG TIN ĐĂNG KÝ:\n\n";
            thongTin += $"- Số điện thoại: {sdt}\n";
            thongTin += $"- Ngày sinh: {ngaySinh}\n";
            thongTin += $"- Khóa học đăng ký: {khoaHoc}";

            // In lên MessageBox
            MessageBox.Show(thongTin, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
