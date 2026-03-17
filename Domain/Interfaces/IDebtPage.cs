using Domain.DTOs.DebtPage;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDebtPage
    {
        public List<DebtPageDTO> LoadPages(int accountStatementId, int pageNumber, int pageSize);
        public int TotalRecords(int accountStatementId);
        public List<DebtPageDTO> FilterPages(int accountStatmentId, int pageNumber, bool ?value
            , Expression<Func<DebtPage, bool>> filterExpr, int pageSize, out int filteredResult);
    }
}
