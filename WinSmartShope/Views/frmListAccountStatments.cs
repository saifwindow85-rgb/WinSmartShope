using Domain.DTOs.Account_Statments;
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
        private List<AccountStatmentsDTO> _accountStatements;
        private int _customerId = -1;
        public frmListAccountStatments(AccountStatementServices services, int customerId)
        {
            InitializeComponent();
            _services = services;
            _customerId = customerId;
        }

        private int _pageNumber = 1;
        private int _TotalRecords = 0;
        private int _filtredResult = 0;
        private int _totalPages = 0;

        private bool _value = false;

        private BindingSource _bs = new BindingSource();

        private AccountStatementServices.FilterType _filter = AccountStatementServices.FilterType.None;

        private void LoadAccountStatements()
        {
            if (_filter == AccountStatementServices.FilterType.None)
            {
                _accountStatements = _services.GetAccountStatments(_customerId, _pageNumber);
                _TotalRecords = _services.GetTotalRecords(_customerId);
            }
            else if (_filter == AccountStatementServices.FilterType.IsPaid || _filter == AccountStatementServices.FilterType.IsClosed)
            {
                ChangeBooleanValue();
                _accountStatements = _services.FilterAccountStatementsPaidAndClosed(_customerId, _pageNumber
                    , _value, _filter, out _filtredResult);
            }
            else
            {
                _accountStatements = _services.FilterAccountStatements(_customerId, _pageNumber, txtFilter.Text.Trim(), _filter, out _filtredResult);
            }
                _bs.DataSource = _accountStatements;
            dgvAccountStatments.DataSource = _bs;
            _bs.ResetBindings(false);
            _totalPages = (int)Math.Ceiling((double)_TotalRecords / _services.PageSize);
            lbRecordsResult.Text = $"{_accountStatements.Count}";
            lbfilterdResult.Text = _filtredResult.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListAccountStatments_Load(object sender, EventArgs e)
        {
            LoadAccountStatements();
        }

        private void ChangeBooleanValue()
        {
            if(_filter == AccountStatementServices.FilterType.IsPaid)
            {
                if (txtFilter.Text.Trim().ToLower() == "paid")
                    _value = true;
                else
                    _value = false;
                
            }
            if(_filter == AccountStatementServices.FilterType.IsClosed)
            {
                if(txtFilter.Text.Trim().ToLower() == "closed")
                    _value = true;
                else
                    _value= false;
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            _pageNumber = 1;
            if (_filter == AccountStatementServices.FilterType.Id && string.IsNullOrEmpty(txtFilter.Text.Trim()))
                return;

            LoadAccountStatements();
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
                LoadAccountStatements();
                return;
            }

            _pageNumber++;
            LoadAccountStatements();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_pageNumber == 1)
            {
                _pageNumber = _totalPages;
                LoadAccountStatements();
                return;
            }
            _pageNumber--;
            LoadAccountStatements();
        }
    }
}
