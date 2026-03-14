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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListAccountStatments));
            lbTitle = new Label();
            pbAccountSatment = new PictureBox();
            dgvAccountStatments = new DataGridView();
            btnFilter = new Button();
            txtFilter = new TextBox();
            cbFilters = new ComboBox();
            lbFilter = new Label();
            ((System.ComponentModel.ISupportInitialize)pbAccountSatment).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccountStatments).BeginInit();
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
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(304, 277);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(218, 32);
            txtFilter.TabIndex = 14;
            txtFilter.Visible = false;
            // 
            // cbFilters
            // 
            cbFilters.FormattingEnabled = true;
            cbFilters.Items.AddRange(new object[] { "None", "Id", "CreateDate", "Description", "IsClosed", "IsPaid" });
            cbFilters.Location = new Point(122, 277);
            cbFilters.Name = "cbFilters";
            cbFilters.Size = new Size(176, 33);
            cbFilters.TabIndex = 13;
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
            // frmListAccountStatments
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1085, 749);
            Controls.Add(btnFilter);
            Controls.Add(txtFilter);
            Controls.Add(cbFilters);
            Controls.Add(lbFilter);
            Controls.Add(dgvAccountStatments);
            Controls.Add(pbAccountSatment);
            Controls.Add(lbTitle);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmListAccountStatments";
            Text = "frmListAccountStatments";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pbAccountSatment).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAccountStatments).EndInit();
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
    }
}