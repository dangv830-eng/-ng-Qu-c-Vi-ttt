
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace bt2
{
    public partial class Form1 : Form
    {
        TextBox txtMaPhieu = new TextBox();
        TextBox txtNguoiYeuCau = new TextBox();
        DateTimePicker dtpNgayGhiNhan = new DateTimePicker();

        RadioButton rdoThap = new RadioButton();
        RadioButton rdoTrungBinh = new RadioButton();
        RadioButton rdoKhanCap = new RadioButton();

        ComboBox cboLoaiSuCo = new ComboBox();

        CheckBox chkMayBan = new CheckBox();
        CheckBox chkLaptop = new CheckBox();
        CheckBox chkMayIn = new CheckBox();
        CheckBox chkDienThoai = new CheckBox();

        PictureBox picAnhLoi = new PictureBox();
        string duongDanAnh = "";

        public Form1()
        {
            InitializeComponent();
            TaoGiaoDien();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void TaoGiaoDien()
        {
            this.Controls.Clear();
            this.Text = "Tiếp nhận sự cố IT";
            this.ClientSize = new Size(600, 620);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScroll = true;

            Label lblTieuDe = new Label();
            lblTieuDe.Text = "PHIẾU TIẾP NHẬN SỰ CỐ IT";
            lblTieuDe.Font = new Font("Arial", 15, FontStyle.Bold);
            lblTieuDe.Location = new Point(100, 15);
            lblTieuDe.Size = new Size(400, 30);
            this.Controls.Add(lblTieuDe);

            ThemLabel("Mã phiếu:", 30, 65, 130);
            txtMaPhieu.Location = new Point(170, 62);
            txtMaPhieu.Size = new Size(250, 25);
            txtMaPhieu.TabIndex = 0;
            this.Controls.Add(txtMaPhieu);

            ThemLabel("Người yêu cầu:", 30, 105, 130);
            txtNguoiYeuCau.Location = new Point(170, 102);
            txtNguoiYeuCau.Size = new Size(250, 25);
            txtNguoiYeuCau.TabIndex = 1;
            this.Controls.Add(txtNguoiYeuCau);

            ThemLabel("Ngày ghi nhận:", 30, 145, 130);
            dtpNgayGhiNhan.Location = new Point(170, 142);
            dtpNgayGhiNhan.Size = new Size(200, 25);
            dtpNgayGhiNhan.Format = DateTimePickerFormat.Short;
            dtpNgayGhiNhan.TabIndex = 2;
            this.Controls.Add(dtpNgayGhiNhan);

            ThemLabel("Mức độ ưu tiên:", 30, 185, 130);

            rdoThap.Text = "Thấp";
            rdoThap.Location = new Point(170, 182);
            rdoThap.AutoSize = true;
            rdoThap.Checked = true;
            rdoThap.TabIndex = 3;

            rdoTrungBinh.Text = "Trung bình";
            rdoTrungBinh.Location = new Point(250, 182);
            rdoTrungBinh.AutoSize = true;
            rdoTrungBinh.TabIndex = 4;

            rdoKhanCap.Text = "Khẩn cấp";
            rdoKhanCap.Location = new Point(370, 182);
            rdoKhanCap.AutoSize = true;
            rdoKhanCap.TabIndex = 5;

            this.Controls.Add(rdoThap);
            this.Controls.Add(rdoTrungBinh);
            this.Controls.Add(rdoKhanCap);

            ThemLabel("Loại sự cố:", 30, 225, 130);
            cboLoaiSuCo.Location = new Point(170, 222);
            cboLoaiSuCo.Size = new Size(200, 25);
            cboLoaiSuCo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLoaiSuCo.Items.AddRange(new object[]
            {
                "Phần cứng", "Phần mềm", "Mạng", "Tài khoản"
            });
            cboLoaiSuCo.SelectedIndex = 0;
            cboLoaiSuCo.TabIndex = 6;
            this.Controls.Add(cboLoaiSuCo);

            ThemLabel("Thiết bị ảnh hưởng:", 30, 265, 140);

            chkMayBan.Text = "Máy tính bàn";
            chkMayBan.Location = new Point(170, 262);
            chkMayBan.AutoSize = true;
            chkMayBan.TabIndex = 7;

            chkLaptop.Text = "Laptop";
            chkLaptop.Location = new Point(310, 262);
            chkLaptop.AutoSize = true;
            chkLaptop.TabIndex = 8;

            chkMayIn.Text = "Máy in";
            chkMayIn.Location = new Point(170, 292);
            chkMayIn.AutoSize = true;
            chkMayIn.TabIndex = 9;

            chkDienThoai.Text = "Điện thoại";
            chkDienThoai.Location = new Point(310, 292);
            chkDienThoai.AutoSize = true;
            chkDienThoai.TabIndex = 10;

            this.Controls.Add(chkMayBan);
            this.Controls.Add(chkLaptop);
            this.Controls.Add(chkMayIn);
            this.Controls.Add(chkDienThoai);

            ThemLabel("Ảnh chụp lỗi:", 30, 335, 130);

            picAnhLoi.Location = new Point(170, 335);
            picAnhLoi.Size = new Size(250, 130);
            picAnhLoi.BorderStyle = BorderStyle.FixedSingle;
            picAnhLoi.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(picAnhLoi);

            Button btnTaiAnh = new Button();
            btnTaiAnh.Text = "Tải ảnh lỗi";
            btnTaiAnh.Location = new Point(170, 475);
            btnTaiAnh.Size = new Size(110, 32);
            btnTaiAnh.TabIndex = 11;
            btnTaiAnh.Click += btnTaiAnh_Click;
            this.Controls.Add(btnTaiAnh);

            Button btnGui = new Button();
            btnGui.Text = "Gửi yêu cầu";
            btnGui.Location = new Point(170, 535);
            btnGui.Size = new Size(120, 35);
            btnGui.TabIndex = 12;
            btnGui.Click += btnGui_Click;
            this.Controls.Add(btnGui);

            Button btnNhapLai = new Button();
            btnNhapLai.Text = "Nhập lại";
            btnNhapLai.Location = new Point(310, 535);
            btnNhapLai.Size = new Size(110, 35);
            btnNhapLai.TabIndex = 13;
            btnNhapLai.Click += btnNhapLai_Click;
            this.Controls.Add(btnNhapLai);
        }

        private void ThemLabel(string noiDung, int x, int y, int rong)
        {
            Label lbl = new Label();
            lbl.Text = noiDung;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(rong, 25);
            this.Controls.Add(lbl);
        }

        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh chụp lỗi";
                ofd.Filter = "Ảnh JPG hoặc PNG|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (Image anh = Image.FromFile(ofd.FileName))
                        {
                            Image anhMoi = new Bitmap(anh);

                            if (picAnhLoi.Image != null)
                                picAnhLoi.Image.Dispose();

                            picAnhLoi.Image = anhMoi;
                        }

                        duongDanAnh = ofd.FileName;
                    }
                    catch
                    {
                        MessageBox.Show("Không thể mở ảnh đã chọn!");
                    }
                }
            }
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text.Trim() == "" ||
                txtNguoiYeuCau.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã phiếu và người yêu cầu!");
                return;
            }

            string mucDo = "Thấp";

            if (rdoTrungBinh.Checked)
                mucDo = "Trung bình";
            else if (rdoKhanCap.Checked)
                mucDo = "Khẩn cấp";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("THÔNG TIN PHIẾU TIẾP NHẬN");
            sb.AppendLine("------------------------------");
            sb.AppendLine("Mã phiếu: " + txtMaPhieu.Text);
            sb.AppendLine("Người yêu cầu: " + txtNguoiYeuCau.Text);
            sb.AppendLine("Ngày ghi nhận: " +
                dtpNgayGhiNhan.Value.ToShortDateString());
            sb.AppendLine("Mức độ ưu tiên: " + mucDo);
            sb.AppendLine("Loại sự cố: " + cboLoaiSuCo.Text);

            sb.Append("Thiết bị ảnh hưởng: ");
            bool coThietBi = false;

            if (chkMayBan.Checked)
            {
                sb.Append("Máy tính bàn, ");
                coThietBi = true;
            }

            if (chkLaptop.Checked)
            {
                sb.Append("Laptop, ");
                coThietBi = true;
            }

            if (chkMayIn.Checked)
            {
                sb.Append("Máy in, ");
                coThietBi = true;
            }

            if (chkDienThoai.Checked)
            {
                sb.Append("Điện thoại, ");
                coThietBi = true;
            }

            if (!coThietBi)
                sb.Append("Chưa chọn");

            sb.AppendLine();
            sb.AppendLine("Ảnh lỗi: " +
                (duongDanAnh == "" ? "Chưa tải ảnh" : duongDanAnh));

            MessageBox.Show(sb.ToString(), "Thông tin yêu cầu");
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtNguoiYeuCau.Clear();
            dtpNgayGhiNhan.Value = DateTime.Now;

            rdoThap.Checked = true;
            cboLoaiSuCo.SelectedIndex = 0;

            chkMayBan.Checked = false;
            chkLaptop.Checked = false;
            chkMayIn.Checked = false;
            chkDienThoai.Checked = false;

            if (picAnhLoi.Image != null)
            {
                picAnhLoi.Image.Dispose();
                picAnhLoi.Image = null;
            }

            duongDanAnh = "";
            txtMaPhieu.Focus();
        }
    }
}
