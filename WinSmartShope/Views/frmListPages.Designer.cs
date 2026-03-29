namespace WinSmartShope.Views
{
    partial class frmListPages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListPages));
            btnPrevPage = new Button();
            btnNextPage = new Button();
            btnClose = new Button();
            lbRecordsResult = new Label();
            lbRecords = new Label();
            btnFilter = new Button();
            cbFilters = new ComboBox();
            lbFilter = new Label();
            dgvDebtPages = new DataGridView();
            pbAccountSatment = new PictureBox();
            lbTitle = new Label();
            gbChoices = new GroupBox();
            rbTrue = new RadioButton();
            rbNo = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvDebtPages).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAccountSatment).BeginInit();
            gbChoices.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrevPage
            // 
            btnPrevPage.FlatStyle = FlatStyle.Flat;
            btnPrevPage.Font = new Font("Segoe UI", 12.8F, FontStyle.Bold | FontStyle.Italic);
            btnPrevPage.ForeColor = SystemColors.ActiveCaption;
            btnPrevPage.ImageAlign = ContentAlignment.MiddleRight;
            btnPrevPage.Location = new Point(449, 700);
            btnPrevPage.Name = "btnPrevPage";
            btnPrevPage.Size = new Size(131, 37);
            btnPrevPage.TabIndex = 36;
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
            btnNextPage.Location = new Point(600, 700);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(131, 37);
            btnNextPage.TabIndex = 35;
            btnNextPage.Text = "--->";
            btnNextPage.TextAlign = ContentAlignment.BottomCenter;
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnClose
            // 
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnClose.Image = Properties.Resources.Close_32;
            btnClose.ImageAlign = ContentAlignment.MiddleRight;
            btnClose.Location = new Point(904, 700);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(131, 37);
            btnClose.TabIndex = 32;
            btnClose.Text = "Close";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lbRecordsResult
            // 
            lbRecordsResult.AutoSize = true;
            lbRecordsResult.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lbRecordsResult.Location = new Point(121, 709);
            lbRecordsResult.Name = "lbRecordsResult";
            lbRecordsResult.Size = new Size(39, 28);
            lbRecordsResult.TabIndex = 31;
            lbRecordsResult.Text = "???";
            // 
            // lbRecords
            // 
            lbRecords.AutoSize = true;
            lbRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            lbRecords.Location = new Point(28, 709);
            lbRecords.Name = "lbRecords";
            lbRecords.Size = new Size(96, 28);
            lbRecords.TabIndex = 30;
            lbRecords.Text = "Records :";
            // 
            // btnFilter
            // 
            btnFilter.FlatStyle = FlatStyle.Flat;
            btnFilter.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnFilter.Image = (Image)resources.GetObject("btnFilter.Image");
            btnFilter.ImageAlign = ContentAlignment.MiddleRight;
            btnFilter.Location = new Point(28, 205);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(131, 37);
            btnFilter.TabIndex = 29;
            btnFilter.Text = "Filter";
            btnFilter.TextAlign = ContentAlignment.TopCenter;
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // cbFilters
            // 
            cbFilters.FormattingEnabled = true;
            cbFilters.Items.AddRange(new object[] { "None", "Paid", "Closed" });
            cbFilters.Location = new Point(122, 271);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new Size(176, 33);
            cbFilters.TabIndex = 27;
            cbFilters.SelectedIndexChanged += cbFilters_SelectedIndexChanged;
            // 
            // lbFilter
            // 
            lbFilter.AutoSize = true;
            lbFilter.Location = new Point(28, 279);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(88, 25);
            lbFilter.TabIndex = 26;
            lbFilter.Text = "Filter By :";
            // 
            // dgvDebtPages
            // 
            dgvDebtPages.AllowUserToAddRows = false;
            dgvDebtPages.AllowUserToDeleteRows = false;
            dgvDebtPages.AllowUserToOrderColumns = true;
            dgvDebtPages.BackgroundColor = SystemColors.ButtonHighlight;
            dgvDebtPages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDebtPages.Location = new Point(12, 310);
            dgvDebtPages.Name = "dgvDebtPages";
            dgvDebtPages.ReadOnly = true;
            dgvDebtPages.RowHeadersWidth = 51;
            dgvDebtPages.Size = new Size(1061, 377);
            dgvDebtPages.TabIndex = 25;
            // 
            // pbAccountSatment
            // 
            pbAccountSatment.BackColor = SystemColors.ButtonFace;
            pbAccountSatment.BorderStyle = BorderStyle.FixedSingle;
            pbAccountSatment.Image = (Image)resources.GetObject("pbAccountSatment.Image");
            pbAccountSatment.Location = new Point(441, 11);
            pbAccountSatment.Name = "pbAccountSatment";
            pbAccountSatment.Size = new Size(215, 180);
            pbAccountSatment.SizeMode = PictureBoxSizeMode.Zoom;
            pbAccountSatment.TabIndex = 24;
            pbAccountSatment.TabStop = false;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 24F);
            lbTitle.ForeColor = Color.OrangeRed;
            lbTitle.Location = new Point(432, 202);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(224, 54);
            lbTitle.TabIndex = 23;
            lbTitle.Text = "Debt Pages";
            // 
            // gbChoices
            // 
            gbChoices.Controls.Add(rbTrue);
            gbChoices.Controls.Add(rbNo);
            gbChoices.Location = new Point(304, 247);
            gbChoices.Name = "gbChoices";
            gbChoices.Size = new Size(250, 57);
            gbChoices.TabIndex = 37;
            gbChoices.TabStop = false;
            gbChoices.Visible = false;
            // 
            // rbTrue
            // 
            rbTrue.AutoSize = true;
            rbTrue.Location = new Point(52, 22);
            rbTrue.Name = "rbTrue";
            rbTrue.Size = new Size(60, 29);
            rbTrue.TabIndex = 38;
            rbTrue.TabStop = true;
            rbTrue.Text = "Yes";
            rbTrue.UseVisualStyleBackColor = true;
            rbTrue.CheckedChanged += rbTrue_CheckedChanged;
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Location = new Point(136, 22);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(58, 29);
            rbNo.TabIndex = 39;
            rbNo.TabStop = true;
            rbNo.Text = "No";
            rbNo.UseVisualStyleBackColor = true;
            rbNo.CheckedChanged += rbNo_CheckedChanged;
            // 
            // frmListPages
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1085, 749);
            Controls.Add(gbChoices);
            Controls.Add(btnPrevPage);
            Controls.Add(btnNextPage);
            Controls.Add(btnClose);
            Controls.Add(lbRecordsResult);
            Controls.Add(lbRecords);
            Controls.Add(btnFilter);
            Controls.Add(cbFilters);
            Controls.Add(lbFilter);
            Controls.Add(dgvDebtPages);
            Controls.Add(pbAccountSatment);
            Controls.Add(lbTitle);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "frmListPages";
            Text = "frmListPages";
            WindowState = FormWindowState.Maximized;
            Load += frmListPages_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDebtPages).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAccountSatment).EndInit();
            gbChoices.ResumeLayout(false);
            gbChoices.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrevPage;
        private Button btnNextPage;
        private Button btnClose;
        private Label lbRecordsResult;
        private Label lbRecords;
        private Button btnFilter;
        private ComboBox cbFilters;
        private Label lbFilter;
        private DataGridView dgvDebtPages;
        private PictureBox pbAccountSatment;
        private Label lbTitle;
        private GroupBox gbChoices;
        private RadioButton rbTrue;
        private RadioButton rbNo;
    }
}