using Domain.DTOs.DebtPage;
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
        private List<DebtPageDTO> _debtPages;
        private int _pageNumber = 1;
        private int _totalPages = 0;
        private int _totalRecords = 0;
        private int _filtredRecords = 0;
        private bool? _filterValue = null;
        private BindingSource _bs = new BindingSource();

        private void LoadData()
        {
            if (_filter == DebtPagesServices.FilterType.None)
            {
                _debtPages = _services.GetPages(_accountStatementId, _pageNumber);
                _totalRecords = _services.GetTotalRecords(_accountStatementId);
            }
            else
            {
                _debtPages = _services.FilterPages(_accountStatementId, _pageNumber, _filterValue,
                    _filter, _services.PageSize, out _filtredRecords);

            }
            _bs.DataSource = _debtPages;
            _totalPages = (int)Math.Ceiling((double)_totalRecords / _services.PageSize);
            dgvDebtPages.DataSource = _bs;
            _bs.ResetBindings(false);
            lbRecordsResult.Text = _totalRecords.ToString();
            lbfilterdResult.Text = _filtredRecords.ToString();
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
                "IsPaid" => DebtPagesServices.FilterType.IsPaid,
                "IsClosed" => DebtPagesServices.FilterType.IsClosed,
                "None" => DebtPagesServices.FilterType.None,
                _ => DebtPagesServices.FilterType.None,
            };
        }

        private void rbTrue_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFilterValue();
        }
        private void ChangeFilterValue()
        {
            if (rbTrue.Checked)
                _filterValue = true;
            else
                rbTrue.Checked = false;
            LoadData();
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFilterValue();
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if(_pageNumber == 1)
            {
                _pageNumber = _totalPages;
                LoadData();
                return;
            }
            _pageNumber--;
            LoadData();
        }
    }
}
