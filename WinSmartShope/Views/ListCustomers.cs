using DTOs.CustomersDTO;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Servs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSmartShope.Views
{

    public partial class ListCustomers : Form
    {
        private CustomerServices _services;
        private IServiceProvider _serviceProvider;
        public ListCustomers(IServiceProvider servicesProvider,CustomerServices services)
        {
            InitializeComponent();
            _services = services;
            _serviceProvider = servicesProvider;
        } 
        private int _TotalPages = 0;
        private int _PageNumber = 1;
        private int _FiltredRecords = 0;
        private CustomerServices.FilterType _filter = CustomerServices.FilterType.None;

        private List<CustomerDTO> _customers;
        BindingSource _bs = new BindingSource();


        private void ListCustomers_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }
        private void LoadCustomers()
        {
            if (_filter == CustomerServices.FilterType.None)
            {
                _customers = _services.GetAllCustomers(_PageNumber);
                _FiltredRecords = _services.GetTotalRecords();
            }
            else
            {
                _customers = _services.FilterCustomers(_PageNumber, txtFilter.Text.Trim()
                    , _filter, out _FiltredRecords, _services._pageSize);
            }
            _bs.DataSource = _customers;
            dgvCustomers.DataSource = _bs;
            _bs.ResetBindings(false);
            _TotalPages = (int)Math.Ceiling((double)_FiltredRecords / _services._pageSize);
            lbResults.Text = $"{_customers.Count}";
            lbFiltredRecords.Text = _FiltredRecords.ToString();

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
            _filter = cbFilters.Text switch
            {
                "Id" => CustomerServices.FilterType.Id,
                "None" => CustomerServices.FilterType.None,
                "FullName" => CustomerServices.FilterType.FullName,
                "Phone Number" => CustomerServices.FilterType.Phone,
                "Email" => CustomerServices.FilterType.Email,
                _ => CustomerServices.FilterType.None
            };
        }



        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_PageNumber == 1)
            {
                _PageNumber = _TotalPages;
                LoadCustomers();
                return;
            }

            _PageNumber--;
            LoadCustomers();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_PageNumber == _TotalPages)
            {
                _PageNumber = 1;
                LoadCustomers();
            }

            _PageNumber++;
            LoadCustomers();
        }


        private void btnFilter_Click(object sender, EventArgs e)
        {
            _PageNumber = 1;
            LoadCustomers();
        }


        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((cbFilters.Text == "Id" || cbFilters.Text == "Phone Number")
                && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void showAccounStatementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int customerId = (int)dgvCustomers.CurrentRow.Cells[0].Value;
            frmListAccountStatments frm = ActivatorUtilities.CreateInstance<frmListAccountStatments>(_serviceProvider, customerId);
            frm.ShowDialog();
        }
    }
}
