using WinSmartShope.Views;

namespace WinSmartShope
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void showCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCustomers frm = new ListCustomers();
            frm.ShowDialog();
        }
    }
}
