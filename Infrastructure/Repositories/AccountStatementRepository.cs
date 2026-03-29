using Domain.DTOs.Account_Statments;
using Domain.Entities;
using Domain.Helpper_Models;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountStatementRepository : IAccountStatement
    {
        private AppDbContext _context;

        public AccountStatementRepository(AppDbContext context)
        {
            _context = context;
        }

        public Expression<Func<AccountStatement, AccountStatmentsDTO>> AccountStatementToDTO = a => new AccountStatmentsDTO
        {
            Id = a.AccountStatementId,
            IsPaid = a.IsPaid,
            IsClosed = a.IsClosed,
            CreatedAt = a.CreatedAt,
            Description = a.Description?? "",
            TotalPages = a.DebtPages.Count(),
            TotalAmount = a.DebtPages.SelectMany(a=>a.StatementItems).Sum(a=>a.Total)

        };

        public PagedResult<AccountStatmentsDTO> LoadAccountStatements(int customerId, int pageSize, int pageNumber, Expression<Func<AccountStatement, bool>>? filterExpr = null)
        {
            var query = _context.AccountStatements.AsNoTracking().Where(a => a.CustomerId == customerId);
            if(filterExpr != null)
                query = query.Where(filterExpr);

            int totalRecords = query.Count();
            var data = query.OrderBy(a => a.AccountStatementId).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(AccountStatementToDTO).ToList();
            return new PagedResult<AccountStatmentsDTO>
            { Data = data,
              TotalRecords = totalRecords
            };

        }
    }
}
