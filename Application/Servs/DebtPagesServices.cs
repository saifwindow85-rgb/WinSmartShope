using Domain.DTOs.DebtPage;
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

         public PagedResult<DebtPageDTO>GetPages(int accountStatementId,int pageNumber,bool ?value,FilterType ?filter)
        {
            Expression<Func<DebtPage, bool>>? filterExpr = filter switch
            {
                FilterType.IsPaid => p => p.IsPaid == value,
                FilterType.IsClosed => p => p.IsClosed == value,
                _ => null
            };
            return _repository.LoadPages(accountStatementId, pageNumber, PageSize,value , filterExpr);
        }
         
        public enum FilterType
        {
            None,
            IsPaid,
            IsClosed
        }
    }
}
