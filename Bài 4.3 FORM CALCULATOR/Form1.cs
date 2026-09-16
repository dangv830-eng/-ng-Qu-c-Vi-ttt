using System;
using System.Windows.Forms;

namespace Bài_4._3_FORM_CALCULATOR
{
    public partial class Form1 : Form
    {
        // Khai báo các biến để lưu trữ giá trị và phép toán
        double ketQua = 0;
        string phepToan = "";
        bool dangNhapPhepToan = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. SỰ KIỆN CHUNG CHO 10 NÚT SỐ (Đúng với yêu cầu)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            // Nếu đang là số 0 hoặc vừa bấm phép toán xong thì xóa trắng màn hình để nhập số mới
            if (txtDisplay.Text == "0" || dangNhapPhepToan)
            {
                txtDisplay.Clear();
            }

            dangNhapPhepToan = false;

            // Ép kiểu sender về Button để lấy Text của nút vừa bấm
            Button btn = (Button)sender;
            
            // Nối chuỗi vào màn hình hiển thị
            txtDisplay.Text = txtDisplay.Text + btn.Text;
        }

        // 2. SỰ KIỆN CHUNG CHO CÁC NÚT PHÉP TOÁN (+, -, *, /)
        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            phepToan = btn.Text;
            ketQua = double.Parse(txtDisplay.Text);
            dangNhapPhepToan = true;
        }

        // 3. SỰ KIỆN CHO NÚT BẰNG (=)
        private void btnBang_Click(object sender, EventArgs e)
        {
            switch (phepToan)
            {
                case "+":
                    txtDisplay.Text = (ketQua + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (ketQua - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (ketQua * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    if (txtDisplay.Text != "0")
                        txtDisplay.Text = (ketQua / double.Parse(txtDisplay.Text)).ToString();
                    else
                        MessageBox.Show("Không thể chia cho 0!");
                    break;
            }
            // Cập nhật lại kết quả sau khi tính
            ketQua = double.Parse(txtDisplay.Text);
            phepToan = "";
        }

        // 4. SỰ KIỆN CHO NÚT CLEAR (C)
        private void btnC_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            ketQua = 0;
            phepToan = "";
        }
    }
}