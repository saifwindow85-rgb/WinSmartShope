using Domain.DTOs.DebtPage;
using Domain.Entities;
using Domain.Helpper_Models;
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
        public PagedResult<DebtPageDTO> LoadPages(int accountStatementId, int pageNumber, int pageSize
            , bool? value, Expression<Func<DebtPage, bool>>? filterExpr = null);



    }
}
