using Domain.DTOs.Account_Statments;
using Domain.Entities;
using Domain.Interfaces;
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
            Id = a.Id,
            IsPaid = a.IsPaid,
            IsClosed = a.IsClosed,
            CreatedAt = a.CreatedAt,
            Description = a.Description,
            TotalPages = a.DebtPages.Count(),
            TotalAmount = a.DebtPages.SelectMany(a=>a.StatementItems).Sum(a=>a.Total)

        };
        public List<AccountStatmentsDTO> LoadAccountStatements(int customerId,int pageNumber, int pageSize)
        {
            IQueryable<AccountStatement> accountStatements = _context.AccountStatements.
                Where(a => a.CustomerId == customerId).OrderBy(a=>a.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return accountStatements.Select(AccountStatementToDTO).ToList();
        }

        public List<AccountStatmentsDTO>FilterAccountStatements(int pageNumber,string value,Expression<Func<AccountStatement,bool>>filterExpr,int pageSize)
        {
            IQueryable<AccountStatement> filtredAccountStatements = _context.AccountStatements.
                Where(filterExpr).OrderBy(a => a.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return filtredAccountStatements.Select(AccountStatementToDTO).ToList();
        }

    }
}
