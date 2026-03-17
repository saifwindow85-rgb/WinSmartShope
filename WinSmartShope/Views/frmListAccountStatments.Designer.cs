namespace WinSmartShope.Views
{
    partial class frmListAccountStatments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListAccountStatments));
            lbTitle = new Label();
            pbAccountSatment = new PictureBox();
            dgvAccountStatments = new DataGridView();
            btnFilter = new Button();
            txtFilter = new TextBox();
            cbFilters = new ComboBox();
            lbFilter = new Label();
            lbRecords = new Label();
            lbRecordsResult = new Label();
            btnClose = new Button();
            lbfilterdResult = new Label();
            lbFiltredRecords = new Label();
            btnPrevPage = new Button();
            btnNextPage = new Button();
            ctAccountStatements = new ContextMenuStrip(components);
            showPageDetailsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbAccountSatment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccountStatments).BeginInit();
            ctAccountStatements.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 24F);
            lbTitle.ForeColor = Color.OrangeRed;
            lbTitle.Location = new Point(380, 213);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(367, 54);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Account  Statments";
            // 
            // pbAccountSatment
            // 
            pbAccountSatment.BackColor = SystemColors.ButtonFace;
            pbAccountSatment.BorderStyle = BorderStyle.FixedSingle;
            pbAccountSatment.Image = (Image)resources.GetObject("pbAccountSatment.Image");
            pbAccountSatment.Location = new Point(441, 17);
            pbAccountSatment.Name = "pbAccountSatment";
            pbAccountSatment.Size = new Size(215, 180);
            pbAccountSatment.SizeMode = PictureBoxSizeMode.Zoom;
            pbAccountSatment.TabIndex = 2;
            pbAccountSatment.TabStop = false;
            // 
            // dgvAccountStatments
            // 
            dgvAccountStatments.AllowUserToAddRows = false;
            dgvAccountStatments.AllowUserToDeleteRows = false;
            dgvAccountStatments.AllowUserToOrderColumns = true;
            dgvAccountStatments.BackgroundColor = SystemColors.ButtonHighlight;
            dgvAccountStatments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccountStatments.Location = new Point(12, 316);
            dgvAccountStatments.Name = "dgvAccountStatments";
            dgvAccountStatments.ReadOnly = true;
            dgvAccountStatments.RowHeadersWidth = 51;
            dgvAccountStatments.Size = new Size(1061, 377);
            dgvAccountStatments.TabIndex = 3;
            // 
            // btnFilter
            // 
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.ImageAlign = ContentAlignment.MiddleRight;
            btnFilter.Location = new Point(28, 211);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(131, 37);
            btnFilter.TabIndex = 15;
            btnFilter.Text = "Filter";
            btnFilter.TextAlign = ContentAlignment.TopCenter;
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(304, 277);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(218, 32);
            txtFilter.TabIndex = 14;
            txtFilter.Visible = false;
            txtFilter.KeyPress += txtFilter_KeyPress;
            // 
            // cbFilters
            // 
            cbFilters.FormattingEnabled = true;
            cbFilters.Items.AddRange(new object[] { "None", "Id", "CreateDate", "Description", "IsClosed", "IsPaid" });
            cbFilters.Location = new Point(122, 277);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new Size(176, 33);
            cbFilters.TabIndex = 13;
            cbFilters.SelectedIndexChanged += cbFilters_SelectedIndexChanged;
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Location = new Point(28, 285);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(88, 25);
            lbFilter.TabIndex = 12;
            lbFilter.Text = "Filter By :";
            // 
            // lbRecords
            // 
            lbRecords.AutoSize = true;
            lbRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lbRecords.Location = new Point(28, 715);
            lbRecords.Name = "lbRecords";
            lbRecords.Size = new Size(96, 28);
            lbRecords.TabIndex = 16;
            lbRecords.Text = "Records :";
            // 
            // lbRecordsResult
            // 
            lbRecordsResult.AutoSize = true;
            lbRecordsResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lbRecordsResult.Location = new Point(121, 715);
            lbRecordsResult.Name = "lbRecordsResult";
            lbRecordsResult.Size = new Size(39, 28);
            lbRecordsResult.TabIndex = 17;
            lbRecordsResult.Text = "???";
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleRight;
            btnClose.Location = new Point(904, 706);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(131, 37);
            btnClose.TabIndex = 18;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lbfilterdResult
            // 
            lbfilterdResult.AutoSize = true;
            lbfilterdResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lbfilterdResult.Location = new Point(337, 715);
            lbfilterdResult.Name = "lbfilterdResult";
            lbfilterdResult.Size = new Size(39, 28);
            lbfilterdResult.TabIndex = 20;
            lbfilterdResult.Text = "???";
            // 
            // lbFiltredRecords
            // 
            lbFiltredRecords.AutoSize = true;
            lbFiltredRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lbFiltredRecords.Location = new Point(244, 715);
            lbFiltredRecords.Name = "lbFiltredRecords";
            lbFiltredRecords.Size = new Size(96, 28);
            lbFiltredRecords.TabIndex = 19;
            lbFiltredRecords.Text = "Records :";
            // 
            // btnPrevPage
            // 
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI", 12.8F, FontStyle.Bold | FontStyle.Italic);
            btnPrevPage.ForeColor = SystemColors.ActiveCaption;
            btnPrevPage.ImageAlign = ContentAlignment.MiddleRight;
            btnPrevPage.Location = new Point(449, 706);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(131, 37);
            btnPrevPage.TabIndex = 22;
            btnPrevPage.Text = "<---";
            btnPrevPage.TextAlign = ContentAlignment.BottomCenter;
            btnPrevPage.UseVisualStyleBackColor = true;
            btnPrevPage.Click += btnPrevPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.FlatStyle = FlatStyle.Flat;
            btnNextPage.Font = new Font("Segoe UI", 12.8F, FontStyle.Bold | FontStyle.Italic);
            btnNextPage.ForeColor = SystemColors.ActiveCaption;
            btnNextPage.ImageAlign = ContentAlignment.MiddleRight;
            btnNextPage.Location = new Point(600, 706);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(131, 37);
            btnNextPage.TabIndex = 21;
            btnNextPage.Text = "--->";
            btnNextPage.TextAlign = ContentAlignment.BottomCenter;
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // ctAccountStatements
            // 
            ctAccountStatements.ImageScalingSize = new Size(20, 20);
            ctAccountStatements.Items.AddRange(new ToolStripItem[] { showPageDetailsToolStripMenuItem });
            ctAccountStatements.Name = "ctAccountStatements";
            ctAccountStatements.Size = new Size(217, 42);
            // 
            // showPageDetailsToolStripMenuItem
            // 
            showPageDetailsToolStripMenuItem.Font = new Font("Segoe UI", 9F);
            showPageDetailsToolStripMenuItem.Image = Properties.Resources.List_32;
            showPageDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showPageDetailsToolStripMenuItem.Name = "showPageDetailsToolStripMenuItem";
            showPageDetailsToolStripMenuItem.Size = new Size(216, 38);
            showPageDetailsToolStripMenuItem.Text = "Show Page Details";
            showPageDetailsToolStripMenuItem.Click += showPageDetailsToolStripMenuItem_Click;
            // 
            // frmListAccountStatments
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1085, 749);
            ContextMenuStrip = ctAccountStatements;
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(lbfilterdResult);
            Controls.Add(lbFiltredRecords);
            Controls.Add(btnClose);
            Controls.Add(lbRecordsResult);
            Controls.Add(lbRecords);
            Controls.Add(btnFilter);
            Controls.Add(txtFilter);
            Controls.Add(cbFilters);
            Controls.Add(lbFilter);
            Controls.Add(dgvAccountStatments);
            Controls.Add(pbAccountSatment);
            Controls.Add(lbTitle);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmListAccountStatments";
            Text = "frmListAccountStatments";
            WindowState = FormWindowState.Maximized;
            Load += frmListAccountStatments_Load;
            ((System.ComponentModel.ISupportInitialize)pbAccountSatment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccountStatments).EndInit();
            ctAccountStatements.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private PictureBox pbAccountSatment;
        private DataGridView dgvAccountStatments;
        private Button btnFilter;
        private TextBox txtFilter;
        private ComboBox cbFilters;
        private Label lbFilter;
        private Label lbRecords;
        private Label lbRecordsResult;
        private Button btnClose;
        private Label lbfilterdResult;
        private Label lbFiltredRecords;
        private Button btnPrevPage;
        private Button btnNextPage;
        private ContextMenuStrip ctAccountStatements;
        private ToolStripMenuItem showPageDetailsToolStripMenuItem;
    }
}