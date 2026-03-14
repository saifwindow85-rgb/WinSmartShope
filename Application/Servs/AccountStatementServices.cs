using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servs
{
    public class AccountStatementServices
    {
        private IAccountStatement _repository;
        public int PageSize { get; private set; } = 10;

        public AccountStatementServices(IAccountStatement repository, int ?pageSize)
        {
            _repository = repository;
             if(pageSize.HasValue)
                PageSize = pageSize.Value;
        }

        public enum FilterType 
        {
            None,
            TotalPages,
            TotalAmount,
            Description,
            IsPaid,
            IsClosed
        }
    }
}
