
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace bt3
{
    public partial class Form1 : Form
    {
        TextBox txtMaVT = new TextBox();
        TextBox txtTenVT = new TextBox();
        ComboBox cboDonVi = new ComboBox();
        TextBox txtDonGia = new TextBox();
        ListView lvVatTu = new ListView();

        Button btnThem = new Button();
        Button btnCapNhat = new Button();
        Button btnXoaDong = new Button();
        Button btnXoaTatCa = new Button();

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
            this.Text = "Quản lý danh mục vật tư";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1000, 580);
            this.MinimumSize = new Size(850, 500);

            GroupBox grpNhap = new GroupBox();
            grpNhap.Text = "Thông tin vật tư";
            grpNhap.Location = new Point(15, 20);
            grpNhap.Size = new Size(300, 300);
            this.Controls.Add(grpNhap);

            ThemLabel(grpNhap, "Mã vật tư:", 15, 35, 100);
            txtMaVT.Location = new Point(120, 32);
            txtMaVT.Size = new Size(155, 25);
            grpNhap.Controls.Add(txtMaVT);

            ThemLabel(grpNhap, "Tên vật tư:", 15, 80, 100);
            txtTenVT.Location = new Point(120, 77);
            txtTenVT.Size = new Size(155, 25);
            grpNhap.Controls.Add(txtTenVT);

            ThemLabel(grpNhap, "Đơn vị tính:", 15, 125, 100);
            cboDonVi.Location = new Point(120, 122);
            cboDonVi.Size = new Size(155, 25);
            cboDonVi.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDonVi.Items.AddRange(new object[]
            {
                "Cái", "Bộ", "Kg", "Mết"
            });
            cboDonVi.SelectedIndex = 0;
            grpNhap.Controls.Add(cboDonVi);

            ThemLabel(grpNhap, "Đơn giá nhập:", 15, 170, 100);
            txtDonGia.Location = new Point(120, 167);
            txtDonGia.Size = new Size(155, 25);
            grpNhap.Controls.Add(txtDonGia);

            btnThem.Text = "Thêm mới";
            btnThem.Location = new Point(15, 220);
            btnThem.Size = new Size(125, 32);
            btnThem.Click += btnThem_Click;
            grpNhap.Controls.Add(btnThem);

            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.Location = new Point(150, 220);
            btnCapNhat.Size = new Size(125, 32);
            btnCapNhat.Click += btnCapNhat_Click;
            grpNhap.Controls.Add(btnCapNhat);

            GroupBox grpDanhSach = new GroupBox();
            grpDanhSach.Text = "Danh sách vật tư";
            grpDanhSach.Location = new Point(330, 20);
            grpDanhSach.Size = new Size(650, 450);
            this.Controls.Add(grpDanhSach);

            lvVatTu.Location = new Point(15, 30);
            lvVatTu.Size = new Size(620, 400);
            lvVatTu.View = View.Details;
            lvVatTu.FullRowSelect = true;
            lvVatTu.GridLines = true;
            lvVatTu.MultiSelect = false;
            lvVatTu.HideSelection = false;

            lvVatTu.Columns.Add("Mã VT", 100);
            lvVatTu.Columns.Add("Tên VT", 200);
            lvVatTu.Columns.Add("Đơn vị tính", 110);
            lvVatTu.Columns.Add("Đơn giá", 150);

            lvVatTu.SelectedIndexChanged += lvVatTu_SelectedIndexChanged;
            grpDanhSach.Controls.Add(lvVatTu);

            btnXoaDong.Text = "Xóa dòng";
            btnXoaDong.Location = new Point(330, 490);
            btnXoaDong.Size = new Size(130, 35);
            btnXoaDong.Click += btnXoaDong_Click;
            this.Controls.Add(btnXoaDong);

            btnXoaTatCa.Text = "Xóa toàn bộ";
            btnXoaTatCa.Location = new Point(480, 490);
            btnXoaTatCa.Size = new Size(140, 35);
            btnXoaTatCa.Click += btnXoaTatCa_Click;
            this.Controls.Add(btnXoaTatCa);
        }

        private void ThemLabel(Control cha, string noiDung,
            int x, int y, int rong)
        {
            Label lbl = new Label();
            lbl.Text = noiDung;
            lbl.Location = new Point(x, y);
            lbl.Size = new Size(rong, 25);
            cha.Controls.Add(lbl);
        }

        private bool KiemTraDuLieu()
        {
            double donGia;

            if (txtMaVT.Text.Trim() == "" ||
                txtTenVT.Text.Trim() == "" ||
                txtDonGia.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return false;
            }

            if (!double.TryParse(txtDonGia.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture, out donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá phải là số không âm!");
                return false;
            }

            return true;
        }

        private bool MaVatTuTonTai(string ma, ListViewItem boQua = null)
        {
            foreach (ListViewItem item in lvVatTu.Items)
            {
                if (item != boQua &&
                    string.Equals(item.Text.Trim(), ma.Trim(),
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu())
                return;

            if (MaVatTuTonTai(txtMaVT.Text))
            {
                MessageBox.Show("Mã vật tư đã tồn tại!");
                txtMaVT.Focus();
                return;
            }

            double donGia = double.Parse(txtDonGia.Text.Trim());

            ListViewItem item = new ListViewItem(txtMaVT.Text.Trim());
            item.SubItems.Add(txtTenVT.Text.Trim());
            item.SubItems.Add(cboDonVi.Text);
            item.SubItems.Add(donGia.ToString("N0"));

            lvVatTu.Items.Add(item);

            LamMoi();
            MessageBox.Show("Thêm vật tư thành công!");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vật tư cần cập nhật!");
                return;
            }

            if (!KiemTraDuLieu())
                return;

            ListViewItem item = lvVatTu.SelectedItems[0];

            if (MaVatTuTonTai(txtMaVT.Text, item))
            {
                MessageBox.Show("Mã vật tư đã tồn tại ở dòng khác!");
                return;
            }

            double donGia = double.Parse(txtDonGia.Text.Trim());

            item.Text = txtMaVT.Text.Trim();
            item.SubItems[1].Text = txtTenVT.Text.Trim();
            item.SubItems[2].Text = cboDonVi.Text;
            item.SubItems[3].Text = donGia.ToString("N0");

            MessageBox.Show("Cập nhật vật tư thành công!");
            LamMoi();
        }

        private void lvVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count > 0)
            {
                ListViewItem item = lvVatTu.SelectedItems[0];

                txtMaVT.Text = item.Text;
                txtTenVT.Text = item.SubItems[1].Text;
                cboDonVi.SelectedItem = item.SubItems[2].Text;
                txtDonGia.Text = item.SubItems[3].Text;
            }
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (lvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa vật tư này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQua == DialogResult.Yes)
            {
                lvVatTu.Items.Remove(lvVatTu.SelectedItems[0]);
                LamMoi();
                MessageBox.Show("Đã xóa vật tư!");
            }
        }

        private void btnXoaTatCa_Click(object sender, EventArgs e)
        {
            if (lvVatTu.Items.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống!");
                return;
            }

            DialogResult ketQua = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa toàn bộ vật tư không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (ketQua == DialogResult.Yes)
            {
                lvVatTu.Items.Clear();
                LamMoi();
            }
        }

        private void LamMoi()
        {
            txtMaVT.Clear();
            txtTenVT.Clear();
            txtDonGia.Clear();
            cboDonVi.SelectedIndex = 0;
            lvVatTu.SelectedItems.Clear();
            txtMaVT.Focus();
        }
    }
}
