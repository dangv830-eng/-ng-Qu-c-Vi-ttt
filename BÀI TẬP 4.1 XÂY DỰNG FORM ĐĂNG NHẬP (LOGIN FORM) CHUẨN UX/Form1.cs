using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BÀI_TẬP_4._1_XÂY_DỰNG_FORM_ĐĂNG_NHẬP__LOGIN_FORM__CHUẨN_UX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // Tick chọn thì hiện, bỏ tick thì ẩn mật khẩu
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValid = true;

            // Xóa các thông báo lỗi cũ
            errorProvider.Clear();

            // Kiểm tra Tên đăng nhập
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider.SetError(txtUsername, "Tên đăng nhập không được để trống!");
                isValid = false;
            }

            // Kiểm tra Mật khẩu
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Mật khẩu không được để trống!");
                isValid = false;
            }

            // Nếu thông tin hợp lệ
            if (isValid)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận thoát
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Gán phím tắt: Enter kích hoạt nút Đăng nhập, Esc kích hoạt nút Thoát
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;

            // Ẩn mật khẩu mặc định khi vừa load Form lên
            txtPassword.UseSystemPasswordChar = true;
        }
    }
}