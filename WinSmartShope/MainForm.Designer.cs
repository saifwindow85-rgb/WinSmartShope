namespace WinSmartShope
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            msApplications = new MenuStrip();
            showCustomersToolStripMenuItem = new ToolStripMenuItem();
            msApplications.SuspendLayout();
            SuspendLayout();
            // 
            // msApplications
            // 
            msApplications.BackColor = SystemColors.Info;
            msApplications.Font = new Font("Segoe UI", 11F);
            msApplications.ImageScalingSize = new Size(20, 20);
            msApplications.Items.AddRange(new ToolStripItem[] { showCustomersToolStripMenuItem });
            msApplications.Location = new Point(0, 0);
            msApplications.Name = "msApplications";
            msApplications.Size = new Size(1000, 72);
            msApplications.TabIndex = 0;
            msApplications.Text = "menuStrip1";
            // 
            // showCustomersToolStripMenuItem
            // 
            showCustomersToolStripMenuItem.Image = Properties.Resources.Drivers_64;
            showCustomersToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            showCustomersToolStripMenuItem.Name = "showCustomersToolStripMenuItem";
            showCustomersToolStripMenuItem.Size = new Size(230, 68);
            showCustomersToolStripMenuItem.Text = "Show Customers";
            showCustomersToolStripMenuItem.Click += showCustomersToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 562);
            Controls.Add(msApplications);
            Font = new Font("Segoe UI", 11F);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            IsMdiContainer = true;
            MainMenuStrip = msApplications;
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "Main Form";
            WindowState = FormWindowState.Maximized;
            msApplications.ResumeLayout(false);
            msApplications.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msApplications;
        private ToolStripMenuItem showCustomersToolStripMenuItem;
    }
}
