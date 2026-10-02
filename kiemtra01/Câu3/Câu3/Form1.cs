using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Câu3
{
    public partial class Form1 : Form
    {
        // 1. Khai báo các Controls
        private TableLayoutPanel tlpMain;
        private Panel pnlLeft, pnlRight;
        private TextBox txtProductId, txtProductName, txtUnitPrice, txtQuantity, txtSearch;
        private ComboBox cboCategory;
        private PictureBox picAvatar;
        private Button btnChooseImage, btnAdd, btnUpdate, btnDelete;
        private DataGridView dgvProducts;
        private ErrorProvider errorProvider;
        private MenuStrip menuStrip;
        private ToolStripMenuItem menuFile, menuExport, menuExit;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatusCount;

        // 2. Data và Binding
        private BindingList<Product> productsList;
        private BindingSource bindingSource;
        private string currentImagePath = "";

        public Form1()
        {
            InitializeCustomComponent();
            SetupDataBinding();
        }

        private void InitializeCustomComponent()
        {
            this.Text = "TechMart Product Manager";
            this.Size = new Size(1100, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Menu & Status Strip ---
            menuStrip = new MenuStrip();
            menuFile = new ToolStripMenuItem("File");
            menuExport = new ToolStripMenuItem("Export CSV (Ctrl+E)") { ShortcutKeys = Keys.Control | Keys.E };
            menuExit = new ToolStripMenuItem("Exit (Ctrl+X)") { ShortcutKeys = Keys.Control | Keys.X };
            menuExport.Click += MenuExport_Click;
            menuExit.Click += (s, e) => this.Close();
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExport, menuExit });
            menuStrip.Items.Add(menuFile);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            statusStrip = new StatusStrip();
            lblStatusCount = new ToolStripStatusLabel("Tổng số sản phẩm: 0");
            statusStrip.Items.Add(lblStatusCount);
            this.Controls.Add(statusStrip);

            // --- Main Layout ---
            tlpMain = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1
            };
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            this.Controls.Add(tlpMain);
            tlpMain.BringToFront();

            // --- Left Panel (Khung nhập liệu) ---
            pnlLeft = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };
            tlpMain.Controls.Add(pnlLeft, 0, 0);

            int y = 20; int spacing = 35;
            pnlLeft.Controls.Add(new Label { Text = "Mã SP:", Left = 20, Top = y, Width = 80 });
            txtProductId = new TextBox { Left = 120, Top = y, Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlLeft.Controls.Add(txtProductId); y += spacing;

            pnlLeft.Controls.Add(new Label { Text = "Tên SP:", Left = 20, Top = y, Width = 80 });
            txtProductName = new TextBox { Left = 120, Top = y, Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlLeft.Controls.Add(txtProductName); y += spacing;

            pnlLeft.Controls.Add(new Label { Text = "Danh mục:", Left = 20, Top = y, Width = 80 });
            cboCategory = new ComboBox { Left = 120, Top = y, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlLeft.Controls.Add(cboCategory); y += spacing;

            pnlLeft.Controls.Add(new Label { Text = "Đơn giá:", Left = 20, Top = y, Width = 80 });
            txtUnitPrice = new TextBox { Left = 120, Top = y, Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlLeft.Controls.Add(txtUnitPrice); y += spacing;

            pnlLeft.Controls.Add(new Label { Text = "Số lượng:", Left = 20, Top = y, Width = 80 });
            txtQuantity = new TextBox { Left = 120, Top = y, Width = 200, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            pnlLeft.Controls.Add(txtQuantity); y += spacing;

            pnlLeft.Controls.Add(new Label { Text = "Ảnh SP:", Left = 20, Top = y, Width = 80 });
            picAvatar = new PictureBox { Left = 120, Top = y, Width = 120, Height = 120, BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom };
            pnlLeft.Controls.Add(picAvatar);

            btnChooseImage = new Button { Text = "Chọn Ảnh", Left = 250, Top = y, Width = 80 };
            btnChooseImage.Click += BtnChooseImage_Click;
            pnlLeft.Controls.Add(btnChooseImage); y += 140;

            btnAdd = new Button { Text = "Thêm mới", Left = 20, Top = y, Width = 90, BackColor = Color.LightGreen };
            btnUpdate = new Button { Text = "Cập nhật", Left = 125, Top = y, Width = 90, BackColor = Color.LightYellow };
            btnDelete = new Button { Text = "Xóa", Left = 230, Top = y, Width = 90, BackColor = Color.LightCoral };

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;

            pnlLeft.Controls.Add(btnAdd);
            pnlLeft.Controls.Add(btnUpdate);
            pnlLeft.Controls.Add(btnDelete);

            // --- Right Panel (Data Grid) ---
            pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(15) };
            tlpMain.Controls.Add(pnlRight, 1, 0);

            pnlRight.Controls.Add(new Label { Text = "Tìm kiếm tên SP:", Left = 15, Top = 20, Width = 120 });
            txtSearch = new TextBox { Left = 140, Top = 18, Width = 300 };
            txtSearch.TextChanged += TxtSearch_TextChanged;
            pnlRight.Controls.Add(txtSearch);

            dgvProducts = new DataGridView
            {
                Top = 60,
                Left = 15,
                Width = pnlRight.Width - 30,
                Height = pnlRight.Height - 80,
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            pnlRight.Controls.Add(dgvProducts);

            errorProvider = new ErrorProvider(this);
            errorProvider.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
        }

        private void SetupDataBinding()
        {
            // Thiết lập danh mục
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Điện thoại" },
                new Category { Id = 2, Name = "Laptop" },
                new Category { Id = 3, Name = "Phụ kiện" }
            };
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            // Thiết lập DataGridView Columns
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP" });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên SP" });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoryName", HeaderText = "Danh Mục" });

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn Giá" };
            colPrice.DefaultCellStyle.Format = "N0"; // Format TC03
            dgvProducts.Columns.Add(colPrice);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số Lượng" });

            // Binding dữ liệu
            productsList = new BindingList<Product>();
            bindingSource = new BindingSource { DataSource = productsList };
            dgvProducts.DataSource = bindingSource;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            errorProvider.Clear();

            // Validate Tên SP
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider.SetError(txtProductName, "Tên SP không được để trống!");
                isValid = false;
            }

            // Validate Đơn giá
            if (!decimal.TryParse(txtUnitPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider.SetError(txtUnitPrice, "Đơn giá phải là số lớn hơn 0!");
                isValid = false;
            }

            // Validate Số lượng
            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                errorProvider.SetError(txtQuantity, "Số lượng phải là số nguyên >= 0!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                var newProduct = new Product
                {
                    ProductId = txtProductId.Text,
                    ProductName = txtProductName.Text,
                    CategoryId = (int)cboCategory.SelectedValue,
                    CategoryName = cboCategory.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    ImagePath = currentImagePath
                };
                productsList.Add(newProduct);
                UpdateStatus();
                ClearInputs();
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && ValidateInput())
            {
                var product = (Product)dgvProducts.CurrentRow.DataBoundItem;
                product.ProductId = txtProductId.Text;
                product.ProductName = txtProductName.Text;
                product.CategoryId = (int)cboCategory.SelectedValue;
                product.CategoryName = cboCategory.Text;
                product.UnitPrice = decimal.Parse(txtUnitPrice.Text);
                product.Quantity = int.Parse(txtQuantity.Text);
                if (!string.IsNullOrEmpty(currentImagePath)) product.ImagePath = currentImagePath;

                bindingSource.ResetBindings(false); // Cập nhật lại Grid
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var product = (Product)dgvProducts.CurrentRow.DataBoundItem;
                    productsList.Remove(product);
                    UpdateStatus();
                    ClearInputs();
                }
            }
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentImagePath = ofd.FileName;
                    picAvatar.Image = Image.FromFile(currentImagePath);
                }
            }
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null)
            {
                var product = (Product)dgvProducts.CurrentRow.DataBoundItem;
                txtProductId.Text = product.ProductId;
                txtProductName.Text = product.ProductName;
                cboCategory.SelectedValue = product.CategoryId;
                txtUnitPrice.Text = product.UnitPrice.ToString("G0");
                txtQuantity.Text = product.Quantity.ToString();

                try
                {
                    if (!string.IsNullOrEmpty(product.ImagePath) && File.Exists(product.ImagePath))
                        picAvatar.Image = Image.FromFile(product.ImagePath);
                    else
                        picAvatar.Image = null;
                }
                catch { picAvatar.Image = null; }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                bindingSource.DataSource = productsList;
            }
            else
            {
                var filtered = productsList.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList();
                bindingSource.DataSource = new BindingList<Product>(filtered);
            }
        }

        private void MenuExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV Files|*.csv", Title = "Export Products" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine("Mã SP,Tên SP,Danh Mục,Đơn Giá,Số Lượng");
                        foreach (var item in productsList)
                        {
                            sw.WriteLine($"{item.ProductId},{item.ProductName},{item.CategoryName},{item.UnitPrice},{item.Quantity}");
                        }
                    }
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void UpdateStatus()
        {
            lblStatusCount.Text = $"Tổng số sản phẩm: {productsList.Count}";
        }

        private void ClearInputs()
        {
            txtProductId.Clear(); txtProductName.Clear(); txtUnitPrice.Clear(); txtQuantity.Clear();
            picAvatar.Image = null; currentImagePath = "";
            txtProductId.Focus();
        }
    }

    // Các class Model phụ trợ
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}