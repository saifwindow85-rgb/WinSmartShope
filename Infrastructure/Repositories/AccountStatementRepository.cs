using Domain.DTOs.Account_Statments;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            Description = a.Description?? "",
            TotalPages = a.DebtPages.Count(),
            TotalAmount = a.DebtPages.SelectMany(a=>a.StatementItems).Sum(a=>a.Total)

        };
        public List<AccountStatmentsDTO> LoadAccountStatements(int customerId,int pageNumber, int pageSize)
        {
            IQueryable<AccountStatement> query = _context.AccountStatements.AsNoTracking().
                Where(a => a.CustomerId == customerId).OrderBy(a=>a.Id).ThenBy(a=>a.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return query.Select(AccountStatementToDTO).ToList();
        }

        public List<AccountStatmentsDTO>FilterAccountStatements(int customerId,int pageNumber,string value,Expression<Func<AccountStatement,bool>>?
            filterExpr,int pageSize,out int filtredResult)
        {
            IQueryable<AccountStatement> query = _context.AccountStatements.AsNoTracking(). Where(a=>a.Id == customerId).
               OrderBy(a => a.Id).ThenBy(a=>a.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            if(filterExpr != null)
            {
                query = query.Where(filterExpr);
            }
            filtredResult = query.Count();
            return query.Select(AccountStatementToDTO).ToList();
        }

        public List<AccountStatmentsDTO>FilteringAccountStatementsPaidAndClosed(int customerId,int pageNumber,bool value,
            Expression<Func<AccountStatement,bool>>?filterExpr,int pageSize,out int filtredResult)
        {
            IQueryable<AccountStatement> query = _context.AccountStatements.AsNoTracking().Where(a=>a.Id ==customerId).OrderBy(a => a.Id).ThenBy(a=>a.CreatedAt);
            if(filterExpr !=null)
            {
                query = query.Where(filterExpr);
            }
            filtredResult = query.Count();
            return query.Select(AccountStatementToDTO).ToList();
        }

        public int GetTotalRecords(int customerId)
        {
            return _context.AccountStatements.AsNoTracking().Where(a => a.Id == customerId).Count();
        }
    }
}
