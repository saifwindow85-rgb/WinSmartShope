using Domain.DTOs.Account_Statments;
using Domain.Helpper_Models;
using Microsoft.Extensions.DependencyInjection;
using Servs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinSmartShope.Views
{
    public partial class frmListAccountStatments : Form
    {
        private AccountStatementServices _services;
        private PagedResult<AccountStatmentsDTO> _accountStatements;
        private IServiceProvider _serviceProvider;
        private int _customerId = -1;
        public frmListAccountStatments(IServiceProvider serviceProvider, AccountStatementServices services, int customerId)
        {
            InitializeComponent();
            _services = services;
            _customerId = customerId;
            _serviceProvider = serviceProvider;
        }

        private int _pageNumber = 1;
        private int _totalRecords = 0;
        private int _totalPages = 0;

        private string? _stringValue = null;

        private bool? _booleanValue = null;

        private BindingSource _bs = new BindingSource();

        private AccountStatementServices.FilterType _filter = AccountStatementServices.FilterType.None;

        private void LoadData()
        {
            LoadAccountStatements();
            SetBindings();
            SetAccountStatementsDetails();
        }
        private void LoadAccountStatements()
        {
            _accountStatements = _services.GetAccountStatements(_customerId, _pageNumber, _booleanValue, _stringValue, _filter);
        }

        private void SetBindings()
        {
            _bs.DataSource = _accountStatements;
            dgvAccountStatments.DataSource = _bs;
            _bs.ResetBindings(false);
        }
        
        private void SetAccountStatementsDetails()
        {
            _totalRecords = _accountStatements.TotalRecords;
            _totalPages = (int)Math.Ceiling((double)_totalRecords / _services.PageSize);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListAccountStatments_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ChangeBooleanValue()
        {
            if (_filter == AccountStatementServices.FilterType.IsPaid)
            {
                if (txtFilter.Text.Trim().ToLower() == "paid")
                    _booleanValue = true;
                else
                    _booleanValue = false;

            }
            if (_filter == AccountStatementServices.FilterType.IsClosed)
            {
                if (txtFilter.Text.Trim().ToLower() == "closed")
                    _booleanValue = true;
                else
                    _booleanValue = false;
            }
        }

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = cbFilters.Text != "None";
            _filter = cbFilters.Text switch
            {
                "Id" => AccountStatementServices.FilterType.Id,
                "None" => AccountStatementServices.FilterType.None,
                "IsPaid" => AccountStatementServices.FilterType.IsPaid,
                "IsClosed" => AccountStatementServices.FilterType.IsClosed,
                "Description" => AccountStatementServices.FilterType.Description,
                _ => AccountStatementServices.FilterType.None
            };
        }
        private void ChangeStringValue()
        {

            if (_filter == AccountStatementServices.FilterType.IsClosed
                || _filter == AccountStatementServices.FilterType.IsPaid)
            {
                _stringValue = null;
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            ChangeStringValue();
            ChangeBooleanValue();
            _pageNumber = 1;
            if (_filter == AccountStatementServices.FilterType.Id && string.IsNullOrEmpty(txtFilter.Text.Trim()))
                return;

            LoadData();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_filter == AccountStatementServices.FilterType.Id && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_pageNumber == _totalPages)
            {
                _pageNumber = 1;
                LoadData();
                return;
            }

            _pageNumber++;
            LoadData();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_pageNumber == 1)
            {
                _pageNumber = _totalPages;
                LoadData();
                return;
            }
            _pageNumber--;
            LoadData();
        }

        private void showPageDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int pageId = (int)dgvAccountStatments.CurrentRow.Cells[0].Value;
            frmListPages frm = ActivatorUtilities.CreateInstance<frmListPages>(_serviceProvider, pageId);
            frm.ShowDialog();
        }
    }
}
