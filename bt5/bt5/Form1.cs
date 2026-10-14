
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace bt5
{
    public partial class Form1 : Form
    {
        SplitContainer split = new SplitContainer();
        TabControl tabControl = new TabControl();
        TabPage tabKhachHang = new TabPage("Khách hàng");
        TabPage tabVanChuyen = new TabPage("Vận chuyển");

        TextBox txtMaDon = new TextBox();
        TextBox txtTenKhach = new TextBox();
        TextBox txtSDT = new TextBox();
        TextBox txtDiaChi = new TextBox();
        ComboBox cboVanChuyen = new ComboBox();

        DataGridView dgvHangHoa = new DataGridView();

        StatusStrip statusStrip = new StatusStrip();
        ToolStripStatusLabel lblThoiGian = new ToolStripStatusLabel();
        ToolStripStatusLabel lblSoLuong = new ToolStripStatusLabel();
        ToolStripStatusLabel lblTrongLuong = new ToolStripStatusLabel();
        ToolStripStatusLabel lblTongTien = new ToolStripStatusLabel();

        Timer timer = new Timer();
        ErrorProvider errorProvider = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TaoGiaoDien();
            TaoBangHangHoa();
            CapNhatThongKe();

            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }

        private void TaoGiaoDien()
        {
            this.Text = "Quản lý đơn giao hàng";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(1200, 700);

            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Vertical;
            split.SplitterDistance = 350;
            split.FixedPanel = FixedPanel.Panel1;
            this.Controls.Add(split);

            tabControl.Dock = DockStyle.Fill;
            tabControl.TabPages.Add(tabKhachHang);
            tabControl.TabPages.Add(tabVanChuyen);
            split.Panel1.Controls.Add(tabControl);

            ThemLabel(tabKhachHang, "Mã đơn hàng:", 20, 30, 110);
            txtMaDon.Location = new Point(135, 27);
            txtMaDon.Width = 170;
            tabKhachHang.Controls.Add(txtMaDon);

            ThemLabel(tabKhachHang, "Tên khách hàng:", 20, 75, 110);
            txtTenKhach.Location = new Point(135, 72);
            txtTenKhach.Width = 170;
            tabKhachHang.Controls.Add(txtTenKhach);

            ThemLabel(tabKhachHang, "Số điện thoại:", 20, 120, 110);
            txtSDT.Location = new Point(135, 117);
            txtSDT.Width = 170;
            tabKhachHang.Controls.Add(txtSDT);

            ThemLabel(tabKhachHang, "Địa chỉ:", 20, 165, 110);
            txtDiaChi.Location = new Point(135, 162);
            txtDiaChi.Width = 170;
            tabKhachHang.Controls.Add(txtDiaChi);

            ThemLabel(tabVanChuyen, "Loại vận chuyển:", 20, 35, 120);
            cboVanChuyen.Location = new Point(145, 32);
            cboVanChuyen.Width = 160;
            cboVanChuyen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboVanChuyen.Items.AddRange(new object[]
            {
                "Tiêu chuẩn", "Nhanh", "Hỏa tốc"
            });
            cboVanChuyen.SelectedIndex = 0;
            tabVanChuyen.Controls.Add(cboVanChuyen);

            Button btnThemDong = new Button();
            btnThemDong.Text = "Thêm dòng (F2)";
            btnThemDong.Location = new Point(20, 230);
            btnThemDong.Size = new Size(140, 35);
            btnThemDong.Click += btnThemDong_Click;
            tabVanChuyen.Controls.Add(btnThemDong);

            Button btnXoaDong = new Button();
            btnXoaDong.Text = "Xóa dòng (Del)";
            btnXoaDong.Location = new Point(170, 230);
            btnXoaDong.Size = new Size(140, 35);
            btnXoaDong.Click += btnXoaDong_Click;
            tabVanChuyen.Controls.Add(btnXoaDong);

            dgvHangHoa.Dock = DockStyle.Fill;
            dgvHangHoa.AllowUserToAddRows = false;
            dgvHangHoa.AllowUserToDeleteRows = false;
            dgvHangHoa.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvHangHoa.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.MultiSelect = false;
            dgvHangHoa.RowHeadersVisible = false;
            split.Panel2.Controls.Add(dgvHangHoa);

            statusStrip.Items.Add(lblThoiGian);
            statusStrip.Items.Add(new ToolStripStatusLabel(" | "));
            statusStrip.Items.Add(lblSoLuong);
            statusStrip.Items.Add(new ToolStripStatusLabel(" | "));
            statusStrip.Items.Add(lblTrongLuong);
            statusStrip.Items.Add(new ToolStripStatusLabel(" | "));
            statusStrip.Items.Add(lblTongTien);

            this.Controls.Add(statusStrip);
            statusStrip.Dock = DockStyle.Bottom;
        }

        private void TaoBangHangHoa()
        {
            dgvHangHoa.Columns.Clear();

            dgvHangHoa.Columns.Add("TenHang", "Tên hàng");
            dgvHangHoa.Columns.Add("SoLuong", "Số lượng");
            dgvHangHoa.Columns.Add("TrongLuong", "Trọng lượng (kg)");
            dgvHangHoa.Columns.Add("DonGia", "Đơn giá");

            DataGridViewTextBoxColumn thanhTien =
                new DataGridViewTextBoxColumn();

            thanhTien.Name = "ThanhTien";
            thanhTien.HeaderText = "Thành tiền";
            thanhTien.ReadOnly = true;
            dgvHangHoa.Columns.Add(thanhTien);

            dgvHangHoa.Columns["TenHang"].FillWeight = 140;
            dgvHangHoa.Columns["SoLuong"].FillWeight = 70;
            dgvHangHoa.Columns["TrongLuong"].FillWeight = 100;
            dgvHangHoa.Columns["DonGia"].FillWeight = 100;
            dgvHangHoa.Columns["ThanhTien"].FillWeight = 110;

            dgvHangHoa.CellValueChanged += dgvHangHoa_CellValueChanged;
            dgvHangHoa.CurrentCellDirtyStateChanged +=
                dgvHangHoa_CurrentCellDirtyStateChanged;
            dgvHangHoa.CellValidating += dgvHangHoa_CellValidating;
            dgvHangHoa.CellEndEdit += dgvHangHoa_CellEndEdit;
            dgvHangHoa.DataError += dgvHangHoa_DataError;

            dgvHangHoa.Rows.Add("Bàn phím", 2, 1.5, 250000, 500000);
            dgvHangHoa.Rows.Add("Chuột máy tính", 3, 0.3, 150000, 450000);

            TinhThanhTien();
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

        private void btnThemDong_Click(object sender, EventArgs e)
        {
            ThemDongMoi();
        }

        private void ThemDongMoi()
        {
            int index = dgvHangHoa.Rows.Add();
            dgvHangHoa.CurrentCell = dgvHangHoa.Rows[index].Cells[0];
            dgvHangHoa.BeginEdit(true);
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            XoaDongDangChon();
        }

        private void XoaDongDangChon()
        {
            if (dgvHangHoa.CurrentRow == null ||
                dgvHangHoa.CurrentRow.IsNewRow)
                return;

            dgvHangHoa.Rows.Remove(dgvHangHoa.CurrentRow);
            CapNhatThongKe();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                ThemDongMoi();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete &&
                     !dgvHangHoa.IsCurrentCellInEditMode)
            {
                XoaDongDangChon();
                e.Handled = true;
            }
        }

        private void dgvHangHoa_CurrentCellDirtyStateChanged(
            object sender, EventArgs e)
        {
            if (dgvHangHoa.IsCurrentCellDirty)
                dgvHangHoa.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
        }

        private void dgvHangHoa_CellValueChanged(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TinhThanhTien();
                CapNhatThongKe();
            }
        }

        private void dgvHangHoa_CellValidating(
            object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string tenCot = dgvHangHoa.Columns[e.ColumnIndex].Name;
            string giaTri = Convert.ToString(e.FormattedValue);
            string loi = "";

            if (tenCot == "SoLuong" || tenCot == "TrongLuong")
            {
                double so;

                if (!double.TryParse(giaTri, out so) || so <= 0)
                    loi = tenCot == "SoLuong"
                        ? "Số lượng phải lớn hơn 0."
                        : "Trọng lượng phải lớn hơn 0.";
            }
            else if (tenCot == "DonGia")
            {
                double gia;

                if (!double.TryParse(giaTri, out gia) || gia < 0)
                    loi = "Đơn giá phải là số không âm.";
            }

            errorProvider.SetError(dgvHangHoa, loi);

            if (loi != "")
            {
                MessageBox.Show(loi);
                e.Cancel = true;
            }
        }

        private void dgvHangHoa_CellEndEdit(
            object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.SetError(dgvHangHoa, "");
        }

        private void dgvHangHoa_DataError(
            object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            MessageBox.Show("Dữ liệu nhập không hợp lệ!");
        }

        private void TinhThanhTien()
        {
            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                double soLuong, donGia;

                bool slHopLe = double.TryParse(
                    Convert.ToString(row.Cells["SoLuong"].Value),
                    out soLuong);

                bool giaHopLe = double.TryParse(
                    Convert.ToString(row.Cells["DonGia"].Value),
                    out donGia);

                if (slHopLe && giaHopLe)
                {
                    row.Cells["ThanhTien"].Value =
                        (soLuong * donGia).ToString("N0");
                }
                else
                {
                    row.Cells["ThanhTien"].Value = "0";
                }
            }
        }

        private void CapNhatThongKe()
        {
            double tongSoLuong = 0;
            double tongTrongLuong = 0;
            double tongTien = 0;

            foreach (DataGridViewRow row in dgvHangHoa.Rows)
            {
                if (row.IsNewRow)
                    continue;

                double sl, tl, gia;

                double.TryParse(
                    Convert.ToString(row.Cells["SoLuong"].Value), out sl);

                double.TryParse(
                    Convert.ToString(row.Cells["TrongLuong"].Value), out tl);

                double.TryParse(
                    Convert.ToString(row.Cells["DonGia"].Value), out gia);

                tongSoLuong += sl;
                tongTrongLuong += sl * tl;
                tongTien += sl * gia;
            }

            lblSoLuong.Text = "Tổng số lượng: " +
                tongSoLuong.ToString("N0");

            lblTrongLuong.Text = "Tổng trọng lượng: " +
                tongTrongLuong.ToString("N2") + " kg";

            lblTongTien.Text = "Tổng tiền: " +
                tongTien.ToString("N0") + " đ";
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = "Thời gian: " +
                DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
        }
    }
}
