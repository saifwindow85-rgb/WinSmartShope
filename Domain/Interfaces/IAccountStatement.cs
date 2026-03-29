using Domain.DTOs.Account_Statments;
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
    public interface IAccountStatement
    {
        public PagedResult<AccountStatmentsDTO> LoadAccountStatements(int customerId, int pageSize, int pageNumber, Expression<Func<AccountStatement, bool>>? filterExpr = null);
    }
}
