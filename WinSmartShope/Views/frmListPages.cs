using Domain.DTOs.DebtPage;
using Domain.Helpper_Models;
using Servs;
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
    public partial class frmListPages : Form
    {
        private DebtPagesServices _services;
        private int _accountStatementId = -1;
        public frmListPages(DebtPagesServices services, int accountStatmentId)
        {
            InitializeComponent();
            _services = services;
            _accountStatementId = accountStatmentId;
        }
        private DebtPagesServices.FilterType _filter = DebtPagesServices.FilterType.None;
        private PagedResult<DebtPageDTO> _debtPages;
        private int _pageNumber = 1;
        private int _totalPages = 0;
        private int _totalRecords = 0;
        private bool? _filterValue = null;
        private BindingSource _bs = new BindingSource();

        private void LoadData()
        {
            LoadPages();
            SetBindings();
            SetPagesDetails();
        }
        private void SetPagesDetails()
        {
            _totalRecords = _debtPages.TotalRecords;
            _totalPages = (int)Math.Ceiling((double)_totalRecords / _services.PageSize);
            lbRecordsResult.Text = _totalRecords.ToString();
        }

        private void SetBindings()
        {
            _bs.DataSource = _debtPages.Data;
            dgvDebtPages.DataSource = _bs;
            _bs.ResetBindings(false);
        }

        private void LoadPages()
        {
            _debtPages = _services.GetPages(_accountStatementId, _pageNumber, _filterValue, _filter);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListPages_Load(object sender, EventArgs e)
        {
            LoadData();
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

        private void cbFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            gbChoices.Visible = cbFilters.Text.Trim() != "None";
            _filter = cbFilters.Text switch
            {
                "Paid" => DebtPagesServices.FilterType.IsPaid,
                "Closed" => DebtPagesServices.FilterType.IsClosed,
                "None" => DebtPagesServices.FilterType.None,
                _ => DebtPagesServices.FilterType.None,
            };
        }


        private void ChangeFilterValue()
        {
            if (rbTrue.Checked)
                _filterValue = true;
            else
                rbTrue.Checked = false;
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

        private void rbNo_Click(object sender, EventArgs e)
        {
            ChangeFilterValue();
        }

        private void rbTrue_Click(object sender, EventArgs e)
        {
            ChangeFilterValue();
        }
    }
}
