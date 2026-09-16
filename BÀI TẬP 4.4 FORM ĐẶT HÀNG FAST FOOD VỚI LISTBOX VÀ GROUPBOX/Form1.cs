using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BÀI_TẬP_4._4_FORM_ĐẶT_HÀNG_FAST_FOOD_VỚI_LISTBOX_VÀ_GROUPBOX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Tạo class chứa thông tin món ăn (Viết bên trong class Form1)
        public class MonAn
        {
            public string TenMon { get; set; }
            public int Gia { get; set; }

            // Ghi đè hàm hiển thị để ListBox tự in ra chuỗi đẹp mắt
            public override string ToString()
            {
                return $"{TenMon}: {Gia}k";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Nạp dữ liệu ban đầu vào lstMenu
            lstMenu.Items.Add(new MonAn() { TenMon = "Hamburger", Gia = 50 });
            lstMenu.Items.Add(new MonAn() { TenMon = "Pizza", Gia = 120 });
            lstMenu.Items.Add(new MonAn() { TenMon = "Gà Rán", Gia = 35 });
            lstMenu.Items.Add(new MonAn() { TenMon = "Pepsi", Gia = 15 });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem != null)
            {
                lstSelected.Items.Remove(lstSelected.SelectedItem);
                CapNhatTongTien();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Nếu có chọn món bên danh sách Menu thì mới chuyển
            if (lstMenu.SelectedItem != null)
            {
                lstSelected.Items.Add(lstMenu.SelectedItem);
                CapNhatTongTien();
            }
        }
        // Hàm dùng chung để tính tiền
        private void CapNhatTongTien()
        {
            int tongTien = 0;
            // Lặp qua tất cả các món đang có trong giỏ hàng (lstSelected)
            foreach (MonAn mon in lstSelected.Items)
            {
                tongTien += mon.Gia;
            }
            lblTotal.Text = $"Tổng tiền: {tongTien}k";
        }
    }
}
