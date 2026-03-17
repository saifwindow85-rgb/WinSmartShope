using Domain.DTOs.Account_Statments;
using Domain.Entities;
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

        public AccountStatementServices(IAccountStatement repository,int?pageSize = null)
        {
            _repository = repository;
            if(pageSize.HasValue)
                PageSize = pageSize.Value;
        }

        public enum FilterType 
        {
            None,
            Id,
            TotalPages,
            TotalAmount,
            Description,
            IsPaid,
            IsClosed
        }

        public List<AccountStatmentsDTO>GetAccountStatments(int customerId,int pageNumber)
        {
            return _repository.LoadAccountStatements(customerId, pageNumber, PageSize);
        }

        public List<AccountStatmentsDTO>FilterAccountStatementsPaidAndClosed(int customerId,int pageNumber,bool value,FilterType filter, out int filtredResult)
        {
            Expression<Func<AccountStatement, bool>>? filterExpr = filter switch
            {
                FilterType.IsPaid => a => a.IsPaid == value,
                FilterType.IsClosed => a => a.IsClosed == value,
                _ => null
            };
            return _repository.FilteringAccountStatementsPaidAndClosed(customerId, pageNumber, value, filterExpr!, PageSize,out filtredResult);
        }

        public List<AccountStatmentsDTO>FilterAccountStatements(int customerId,int pageNumber,string value,FilterType filter, out int filtredResult)
        {
            Expression<Func<AccountStatement, bool>>? filterExpr = filter switch
            {
                FilterType.Description => a => (a.Description ?? "").Contains(value),
                FilterType.Id => a => a.AccountStatementId.ToString() == value,
                _ => null
            };
            return _repository.FilterAccountStatements(customerId, pageNumber, value, filterExpr!, PageSize,out filtredResult);
        }
        public int GetTotalRecords(int customerId) => _repository.GetTotalRecords(customerId);
    }
}
