using Application;
using DTOs.CustomersDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSmartShope.Views
{

    public partial class ListCustomers : Form
    {
        public ListCustomers()
        {
            InitializeComponent();
        }
 
        private List<CustomerDTO> _customers;
        int TotalPages;
        int PageNumber;
        BindingSource _bs = new BindingSource();

        private void ListCustomers_Load(object sender, EventArgs e)
        {
            TotalPages = CustomerServices.TotalPages();
            PageNumber = 1;
            _customers = CustomerServices.GetCustomers();
            _bs.DataSource = _customers;
            dgvCustomers.DataSource = _bs;
            lbResults.Text = $"#{_customers.Count()}Records";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilters.Text == "None")
                txtFilter.Visible = false;
            else
                txtFilter.Visible = true;
        }



        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (PageNumber == 1)
                return;
                PageNumber--;
            _customers = CustomerServices.GetCustomers(PageNumber);
            _bs.DataSource = _customers;
            _bs.ResetBindings(false);
            return;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (PageNumber == TotalPages)
                return;

                PageNumber++;
            _bs.DataSource = CustomerServices.GetCustomers(PageNumber);
            _bs.ResetBindings(false);
             return;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string selectedFilter = cbFilters.Text.Trim();

            if (selectedFilter == "None")
            {
                _bs.DataSource = _customers;
                _bs.ResetBindings(false);
                lbResults.Text = $"#{dgvCustomers.Rows.Count}Records";
                return;
            }

            if (selectedFilter == "Id")
            {
                if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
                    return;
               _bs.DataSource = CustomerServices.FilterCustomers(txtFilter.Text.Trim(), selectedFilter);
                _bs.ResetBindings(false);
                lbResults.Text = $"#{dgvCustomers.Rows.Count}Records";
                return;
            }
            else
            {
                _bs.DataSource = CustomerServices.FilterCustomers(txtFilter.Text.Trim(), selectedFilter);
                _bs.ResetBindings(false);
                lbResults.Text = $"#{dgvCustomers.Rows.Count}Records";
                return;
            }
        }


        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((cbFilters.Text == "Id" || cbFilters.Text == "Phone Number")
                && !char.IsDigit(e.KeyChar)&&!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
