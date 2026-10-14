
using System;
using System.Drawing;
using System.Windows.Forms;

namespace bt4
{
    public partial class Form1 : Form
    {
        TableLayoutPanel bangViTri = new TableLayoutPanel();
        ComboBox cboKhungGio = new ComboBox();
        Label lblSoLuong = new Label();
        Label lblTamTinh = new Label();
        Button btnXacNhan = new Button();
        Button btnHuyTatCa = new Button();

        int giaTien = 100000;
        const int soHang = 4;
        const int soCot = 5;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TaoGiaoDien();
            TaoViTri();
            CapNhatThongTin();
        }

        private void TaoGiaoDien()
        {
            this.Text = "Sơ đồ chọn vị trí";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(700, 600);
            this.BackColor = Color.WhiteSmoke;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "SƠ ĐỒ CHỌN VỊ TRÍ";
            lblTieuDe.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;
            lblTieuDe.Location = new Point(150, 15);
            lblTieuDe.Size = new Size(400, 35);
            this.Controls.Add(lblTieuDe);

            Label lblGio = new Label();
            lblGio.Text = "Khung giờ:";
            lblGio.Location = new Point(40, 70);
            lblGio.Size = new Size(100, 25);
            this.Controls.Add(lblGio);

            cboKhungGio.Location = new Point(140, 67);
            cboKhungGio.Size = new Size(180, 30);
            cboKhungGio.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhungGio.Items.Add("Sáng - 100.000đ");
            cboKhungGio.Items.Add("Tối - 150.000đ");
            cboKhungGio.SelectedIndex = 0;
            cboKhungGio.SelectedIndexChanged += cboKhungGio_SelectedIndexChanged;
            this.Controls.Add(cboKhungGio);

            bangViTri.Location = new Point(40, 120);
            bangViTri.Size = new Size(620, 280);
            bangViTri.RowCount = soHang;
            bangViTri.ColumnCount = soCot;
            bangViTri.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            bangViTri.Padding = new Padding(5);

            for (int i = 0; i < soCot; i++)
                bangViTri.ColumnStyles.Add(
                    new ColumnStyle(SizeType.Percent, 100f / soCot));

            for (int i = 0; i < soHang; i++)
                bangViTri.RowStyles.Add(
                    new RowStyle(SizeType.Percent, 100f / soHang));

            this.Controls.Add(bangViTri);

            lblSoLuong.Location = new Point(40, 420);
            lblSoLuong.Size = new Size(280, 30);
            lblSoLuong.Font = new Font("Arial", 11);
            this.Controls.Add(lblSoLuong);

            lblTamTinh.Location = new Point(40, 460);
            lblTamTinh.Size = new Size(350, 30);
            lblTamTinh.Font = new Font("Arial", 11, FontStyle.Bold);
            this.Controls.Add(lblTamTinh);

            Label lblChuThich = new Label();
            lblChuThich.Text = "Trống: Trắng/Xám   Đang chọn: Xanh lá   Đã khóa: Đỏ";
            lblChuThich.Location = new Point(40, 505);
            lblChuThich.Size = new Size(600, 25);
            this.Controls.Add(lblChuThich);

            btnXacNhan.Text = "Xác nhận đặt";
            btnXacNhan.Location = new Point(390, 545);
            btnXacNhan.Size = new Size(125, 35);
            btnXacNhan.Click += btnXacNhan_Click;
            this.Controls.Add(btnXacNhan);

            btnHuyTatCa.Text = "Hủy chọn tất cả";
            btnHuyTatCa.Location = new Point(525, 545);
            btnHuyTatCa.Size = new Size(135, 35);
            btnHuyTatCa.Click += btnHuyTatCa_Click;
            this.Controls.Add(btnHuyTatCa);
        }

        private void TaoViTri()
        {
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    Button btn = new Button();
                    int soViTri = i * soCot + j + 1;

                    btn.Text = "Vị trí " + soViTri;
                    btn.Dock = DockStyle.Fill;
                    btn.Margin = new Padding(5);
                    btn.BackColor = Color.LightGray;
                    btn.Tag = "Trong";
                    btn.Font = new Font("Arial", 9);

                    btn.Click += btnViTri_Click;

                    bangViTri.Controls.Add(btn, j, i);
                }
            }

            Button viTriKhoa1 = (Button)bangViTri.GetControlFromPosition(4, 0);
            Button viTriKhoa2 = (Button)bangViTri.GetControlFromPosition(4, 1);

            viTriKhoa1.Tag = "DaKhoa";
            viTriKhoa1.BackColor = Color.Red;
            viTriKhoa1.ForeColor = Color.White;

            viTriKhoa2.Tag = "DaKhoa";
            viTriKhoa2.BackColor = Color.Red;
            viTriKhoa2.ForeColor = Color.White;

            viTriKhoa1.Text += "\nĐã khóa";
            viTriKhoa2.Text += "\nĐã khóa";
        }

        private void btnViTri_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Tag.ToString() == "DaKhoa" ||
                btn.Tag.ToString() == "DaDat")
            {
                MessageBox.Show("Vị trí này đã có người đặt hoặc bị khóa!");
                return;
            }

            if (btn.Tag.ToString() == "Trong")
            {
                btn.Tag = "DangChon";
                btn.BackColor = Color.Green;
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.Tag = "Trong";
                btn.BackColor = Color.LightGray;
                btn.ForeColor = Color.Black;
            }

            CapNhatThongTin();
        }

        private void cboKhungGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            giaTien = cboKhungGio.SelectedIndex == 0 ? 100000 : 150000;
            CapNhatThongTin();
        }

        private void CapNhatThongTin()
        {
            int dem = 0;

            foreach (Control control in bangViTri.Controls)
            {
                Button btn = control as Button;

                if (btn != null && btn.Tag.ToString() == "DangChon")
                    dem++;
            }

            lblSoLuong.Text = "Số vị trí đang chọn: " + dem;
            lblTamTinh.Text = "Tạm tính tiền: " +
                (dem * giaTien).ToString("N0") + "đ";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            int dem = 0;

            foreach (Control control in bangViTri.Controls)
            {
                Button btn = control as Button;

                if (btn != null && btn.Tag.ToString() == "DangChon")
                {
                    btn.Tag = "DaDat";
                    btn.BackColor = Color.Red;
                    btn.ForeColor = Color.White;
                    btn.Text += "\nĐã đặt";
                    dem++;
                }
            }

            if (dem == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí nào!");
                return;
            }

            MessageBox.Show(
                "Đặt thành công " + dem + " vị trí.\nTổng tiền: " +
                (dem * giaTien).ToString("N0") + "đ",
                "Thông báo");

            CapNhatThongTin();
        }

        private void btnHuyTatCa_Click(object sender, EventArgs e)
        {
            foreach (Control control in bangViTri.Controls)
            {
                Button btn = control as Button;

                if (btn != null && btn.Tag.ToString() == "DangChon")
                {
                    btn.Tag = "Trong";
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }

            CapNhatThongTin();
        }
    }
}
