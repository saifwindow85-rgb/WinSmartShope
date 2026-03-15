using Domain.DTOs.Account_Statments;
using Domain.Entities;
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
        public List<AccountStatmentsDTO> LoadAccountStatements(int customerId,int pageNumber, int pageSize);
        public List<AccountStatmentsDTO> FilterAccountStatements(int customerId,int pageNumber, string value, Expression<Func<AccountStatement,
            bool>> filterExpr, int pageSize, out int filtredResult);
        public List<AccountStatmentsDTO> FilteringAccountStatementsPaidAndClosed(int customerId,int pageNumber, bool value,
          Expression<Func<AccountStatement, bool>> filterExpr, int pageSize,out int filtredResult);

        public int GetTotalRecords(int customerId);
    }
}
