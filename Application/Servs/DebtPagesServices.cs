using Domain.DTOs.DebtPage;
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
    public class DebtPagesServices
    {
        private readonly IDebtPage _repository;
        public int PageSize { get; private set; } = 10;

        public DebtPagesServices(IDebtPage repository, int ?pageSize =null)
        {
            _repository = repository;
           if(pageSize.HasValue)
                PageSize = pageSize.Value;
        }

        public List<DebtPageDTO>GetPages(int accountStatementID,int pageNumber)
        {
            return _repository.LoadPages(accountStatementID, pageNumber, PageSize);
        }

        public int GetTotalRecords(int pageId)
        {
            return _repository.TotalRecords(pageId);
        }

        public List<DebtPageDTO>FilterPages(int accountStatementId,int pageNumber
            ,bool ?value,FilterType filter,int pageSize,out int filtredResult)
        {
            Expression<Func<DebtPage, bool>> ?filterExpr = filter switch
            {
                FilterType.IsPaid => p => p.IsPaid == value,
                FilterType.IsClosed => p => p.IsClosed == value,
                _ => null
            };
            return _repository.FilterPages(accountStatementId, pageNumber, value, filterExpr, pageSize, out filtredResult);
        }
         
        public enum FilterType
        {
            None,
            IsPaid,
            IsClosed
        }
    }
}
