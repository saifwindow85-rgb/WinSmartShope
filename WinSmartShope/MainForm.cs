using Microsoft.Extensions.DependencyInjection;
using WinSmartShope.Views;

namespace WinSmartShope
{
    public partial class MainForm : Form
    {
        IServiceProvider _serviceProvider;
        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
             _serviceProvider= serviceProvider;
        }

        private void showCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCustomers frm = _serviceProvider.GetRequiredService<ListCustomers>();
            frm.ShowDialog();
        }
    }
}
