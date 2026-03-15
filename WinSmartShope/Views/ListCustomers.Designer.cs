namespace WinSmartShope.Views
{
    partial class ListCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCustomers));
            dgvCustomers = new DataGridView();
            pbCustomers = new PictureBox();
            lbTitle = new Label();
            btnClose = new Button();
            lbFilter = new Label();
            cbFilters = new ComboBox();
            txtFilter = new TextBox();
            lbRecords = new Label();
            lbResults = new Label();
            btnNextPage = new Button();
            btnPrevPage = new Button();
            btnFilter = new Button();
            ctxtCustomers = new ContextMenuStrip(components);
            showAccounStatementsToolStripMenuItem = new ToolStripMenuItem();
            lbResultAftreFiltreing = new Label();
            lbFiltredRecords = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCustomers).BeginInit();
            ctxtCustomers.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.AllowUserToDeleteRows = false;
            dgvCustomers.AllowUserToOrderColumns = true;
            dgvCustomers.BackgroundColor = SystemColors.ButtonHighlight;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.ContextMenuStrip = ctxtCustomers;
            dgvCustomers.Location = new Point(27, 274);
            dgvCustomers.Margin = new Padding(4);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.ReadOnly = true;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(1279, 339);
            dgvCustomers.TabIndex = 0;
            // 
            // pbCustomers
            // 
            pbCustomers.BackColor = SystemColors.ButtonFace;
            pbCustomers.BorderStyle = BorderStyle.FixedSingle;
            pbCustomers.Image = Properties.Resources.People_400;
            pbCustomers.Location = new Point(606, 12);
            pbCustomers.Name = "pbCustomers";
            pbCustomers.Size = new Size(190, 158);
            pbCustomers.SizeMode = PictureBoxSizeMode.Zoom;
            pbCustomers.TabIndex = 1;
            pbCustomers.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 20F);
            lbTitle.ForeColor = Color.OrangeRed;
            lbTitle.Location = new Point(560, 186);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(298, 46);
            lbTitle.TabIndex = 2;
            lbTitle.Text = "Customers Details ";
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleRight;
            btnClose.Location = new Point(1119, 638);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(131, 37);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Location = new Point(27, 235);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(88, 25);
            lbFilter.TabIndex = 4;
            lbFilter.Text = "Filter By :";
            // 
            // cbFilters
            // 
            cbFilters.FormattingEnabled = true;
            cbFilters.Items.AddRange(new object[] { "None", "Id", "FullName", "Phone Number", "Email" });
            cbFilters.Location = new Point(121, 227);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new Size(176, 33);
            cbFilters.TabIndex = 5;
            cbFilters.SelectedIndexChanged += cbFilters_SelectedIndexChanged;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(303, 227);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(218, 32);
            txtFilter.TabIndex = 6;
            txtFilter.Visible = false;
            txtFilter.KeyPress += txtFilter_KeyPress;
            // 
            // lbRecords
            // 
            lbRecords.AutoSize = true;
            lbRecords.Font = new Font("Segoe UI", 12F);
            lbRecords.Location = new Point(27, 627);
            lbRecords.Name = "lbRecords";
            lbRecords.Size = new Size(90, 28);
            lbRecords.TabIndex = 7;
            lbRecords.Text = "Records :";
            // 
            // lbResults
            // 
            lbResults.AutoSize = true;
            lbResults.Font = new Font("Segoe UI", 12F);
            lbResults.Location = new Point(120, 628);
            lbResults.Name = "lbResults";
            lbResults.Size = new Size(39, 28);
            lbResults.TabIndex = 8;
            lbResults.Text = "???";
            // 
            // btnNextPage
            // 
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI", 12.8F, FontStyle.Bold | FontStyle.Italic);
            btnNextPage.ForeColor = SystemColors.ActiveCaption;
            btnNextPage.ImageAlign = ContentAlignment.MiddleRight;
            btnNextPage.Location = new Point(667, 627);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(131, 37);
            btnNextPage.TabIndex = 9;
            btnNextPage.Text = "--->";
            btnNextPage.TextAlign = ContentAlignment.BottomCenter;
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPrevPage
            // 
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI", 12.8F, FontStyle.Bold | FontStyle.Italic);
            btnPrevPage.ForeColor = SystemColors.ActiveCaption;
            btnPrevPage.ImageAlign = ContentAlignment.MiddleRight;
            btnPrevPage.Location = new Point(516, 627);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(131, 37);
            btnPrevPage.TabIndex = 10;
            btnPrevPage.Text = "<---";
            btnPrevPage.TextAlign = ContentAlignment.BottomCenter;
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnFilter
            // 
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.ImageAlign = ContentAlignment.MiddleRight;
            btnFilter.Location = new Point(27, 161);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(131, 37);
            btnFilter.TabIndex = 11;
            btnFilter.Text = "Filter";
            btnFilter.TextAlign = ContentAlignment.TopCenter;
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // ctxtCustomers
            // 
            ctxtCustomers.ImageScalingSize = new Size(20, 20);
            ctxtCustomers.Items.AddRange(new ToolStripItem[] { showAccounStatementsToolStripMenuItem });
            ctxtCustomers.Name = "ctxtCustomers";
            ctxtCustomers.Size = new Size(258, 70);
            // 
            // showAccounStatementsToolStripMenuItem
            // 
            showAccounStatementsToolStripMenuItem.Image = Properties.Resources.List_32;
            showAccounStatementsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showAccounStatementsToolStripMenuItem.Name = "showAccounStatementsToolStripMenuItem";
            showAccounStatementsToolStripMenuItem.Size = new Size(257, 38);
            showAccounStatementsToolStripMenuItem.Text = "Show AccounStatements";
            showAccounStatementsToolStripMenuItem.Click += showAccounStatementsToolStripMenuItem_Click;
            // 
            // lbResultAftreFiltreing
            // 
            lbResultAftreFiltreing.AutoSize = true;
            lbResultAftreFiltreing.Font = new Font("Segoe UI", 12F);
            lbResultAftreFiltreing.Location = new Point(200, 630);
            lbResultAftreFiltreing.Name = "lbResultAftreFiltreing";
            lbResultAftreFiltreing.Size = new Size(146, 28);
            lbResultAftreFiltreing.TabIndex = 13;
            lbResultAftreFiltreing.Text = "FiltredRecords :";
            // 
            // lbFiltredRecords
            // 
            lbFiltredRecords.AutoSize = true;
            lbFiltredRecords.Font = new Font("Segoe UI", 12F);
            lbFiltredRecords.Location = new Point(352, 630);
            lbFiltredRecords.Name = "lbFiltredRecords";
            lbFiltredRecords.Size = new Size(39, 28);
            lbFiltredRecords.TabIndex = 12;
            lbFiltredRecords.Text = "???";
            // 
            // ListCustomers
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1319, 680);
            Controls.Add(lbResultAftreFiltreing);
            Controls.Add(lbFiltredRecords);
            Controls.Add(btnFilter);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(lbResults);
            Controls.Add(lbRecords);
            Controls.Add(txtFilter);
            Controls.Add(cbFilters);
            Controls.Add(lbFilter);
            Controls.Add(btnClose);
            Controls.Add(lbTitle);
            Controls.Add(pbCustomers);
            Controls.Add(dgvCustomers);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "ListCustomers";
            Text = "ListCustomers";
            WindowState = FormWindowState.Maximized;
            Load += ListCustomers_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCustomers).EndInit();
            ctxtCustomers.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCustomers;
        private PictureBox pbCustomers;
        private Label lbTitle;
        private Button btnClose;
        private Label lbFilter;
        private ComboBox cbFilters;
        private TextBox txtFilter;
        private Label lbRecords;
        private Label lbResults;
        private Button btnNextPage;
        private Button btnPrevPage;
        private Button btnFilter;
        private ContextMenuStrip ctxtCustomers;
        private ToolStripMenuItem showAccounStatementsToolStripMenuItem;
        private Label lbResultAftreFiltreing;
        private Label lbFiltredRecords;
    }
}