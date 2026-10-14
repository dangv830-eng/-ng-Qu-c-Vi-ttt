
using System;
using System.Drawing;
using System.Windows.Forms;

namespace bt1

{
    public partial class Form1 : Form
    {
        TextBox txtDonGia = new TextBox();
        TextBox txtSoLuong = new TextBox();
        TextBox txtGiamGia = new TextBox();
        Label lblTongTien = new Label();

        public Form1()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            this.Text = "Máy tính cước dịch vụ";
            this.Size = new Size(450, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "MÁY TÍNH CƯỚC DỊCH VỤ";
            lblTieuDe.Location = new Point(70, 20);
            lblTieuDe.Size = new Size(300, 30);
            lblTieuDe.Font = new Font("Arial", 14, FontStyle.Bold);

            Label lblDonGia = new Label();
            lblDonGia.Text = "Đơn giá dịch vụ:";
            lblDonGia.Location = new Point(30, 75);
            lblDonGia.Size = new Size(130, 25);

            txtDonGia.Location = new Point(170, 72);
            txtDonGia.Size = new Size(200, 25);
            txtDonGia.TabIndex = 0;

            Label lblSoLuong = new Label();
            lblSoLuong.Text = "Số lượng khách:";
            lblSoLuong.Location = new Point(30, 115);
            lblSoLuong.Size = new Size(130, 25);

            txtSoLuong.Location = new Point(170, 112);
            txtSoLuong.Size = new Size(200, 25);
            txtSoLuong.TabIndex = 1;

            Label lblGiamGia = new Label();
            lblGiamGia.Text = "% giảm giá:";
            lblGiamGia.Location = new Point(30, 155);
            lblGiamGia.Size = new Size(130, 25);

            txtGiamGia.Location = new Point(170, 152);
            txtGiamGia.Size = new Size(200, 25);
            txtGiamGia.TabIndex = 2;

            Label lblKetQua = new Label();
            lblKetQua.Text = "Tổng tiền thanh toán:";
            lblKetQua.Location = new Point(30, 195);
            lblKetQua.Size = new Size(150, 25);

            lblTongTien.Text = "0 VNĐ";
            lblTongTien.Location = new Point(190, 195);
            lblTongTien.Size = new Size(200, 25);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Font = new Font("Arial", 10, FontStyle.Bold);

            Button btnTinhTien = new Button();
            btnTinhTien.Text = "Tính tiền";
            btnTinhTien.Location = new Point(100, 245);
            btnTinhTien.Size = new Size(100, 35);
            btnTinhTien.TabIndex = 3;
            btnTinhTien.Click += btnTinhTien_Click;

            Button btnLamMoi = new Button();
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.Location = new Point(230, 245);
            btnLamMoi.Size = new Size(100, 35);
            btnLamMoi.TabIndex = 4;
            btnLamMoi.Click += btnLamMoi_Click;

            this.Controls.Add(lblTieuDe);
            this.Controls.Add(lblDonGia);
            this.Controls.Add(txtDonGia);
            this.Controls.Add(lblSoLuong);
            this.Controls.Add(txtSoLuong);
            this.Controls.Add(lblGiamGia);
            this.Controls.Add(txtGiamGia);
            this.Controls.Add(lblKetQua);
            this.Controls.Add(lblTongTien);
            this.Controls.Add(btnTinhTien);
            this.Controls.Add(btnLamMoi);
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            double donGia, giamGia;
            int soLuong;

            if (txtDonGia.Text.Trim() == "" ||
                txtSoLuong.Text.Trim() == "" ||
                txtGiamGia.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            if (!double.TryParse(txtDonGia.Text, out donGia) ||
                !int.TryParse(txtSoLuong.Text, out soLuong) ||
                !double.TryParse(txtGiamGia.Text, out giamGia))
            {
                MessageBox.Show("Vui lòng nhập dữ liệu đúng kiểu số!");
                return;
            }

            if (donGia < 0 || soLuong <= 0 ||
                giamGia < 0 || giamGia > 100)
            {
                MessageBox.Show("Đơn giá phải >= 0, số lượng > 0 và giảm giá từ 0 đến 100%!");
                return;
            }

            double tongTien = donGia * soLuong * (100 - giamGia) / 100;

            lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            lblTongTien.Text = "0 VNĐ";
            txtDonGia.Focus();
        }
    }
}
