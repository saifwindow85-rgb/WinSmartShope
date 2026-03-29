using Domain.DTOs.Account_Statments;
using Domain.Entities;
using Domain.Helpper_Models;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servs
{
    public class AccountStatementServices
    {
        private IAccountStatement _repository;
        public int PageSize { get; private set; } = 10;

        public AccountStatementServices(IAccountStatement repository, int? pageSize = null)
        {
            _repository = repository;
            if (pageSize.HasValue)
                PageSize = pageSize.Value;
        }

        public enum FilterType
        {
            None,
            Id,
            Description,
            IsPaid,
            IsClosed
        }

        public PagedResult<AccountStatmentsDTO>GetAccountStatements(int customerId,int pageNumber,bool? booleanValue,string? stringValue,FilterType? filter)
        {
            Expression<Func<AccountStatement, bool>>? filterExpr = null;
            if(booleanValue.HasValue)
            {
                filterExpr = filter switch
                {
                    FilterType.IsPaid => a => a.IsPaid == booleanValue,
                    FilterType.IsClosed => a => a.IsClosed == booleanValue,
                    _ => null
                };

            }

            if(stringValue != null)
            {
                filterExpr = filter switch
                {
                    FilterType.Id => a => a.AccountStatementId.ToString() == stringValue,
                    FilterType.Description => a => a.Description.Contains(stringValue, StringComparison.OrdinalIgnoreCase),
                    _ => null
                };
            }
            return _repository.LoadAccountStatements(customerId, PageSize, pageNumber, filterExpr);
        }
    }
}
