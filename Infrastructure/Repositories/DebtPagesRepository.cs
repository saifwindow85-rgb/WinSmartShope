using Domain.DTOs.DebtPage;
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
    public class DebtPagesRepository : IDebtPage
    {
        private AppDbContext _context;
        public DebtPagesRepository(AppDbContext context)
        {
            _context = context;
        }

        private Expression<Func<DebtPage, DebtPageDTO>> DebtPageToDTO = p => new DebtPageDTO
        {
            Id = p.Id,
            Description = p.Description,
            CreatedAt = p.CreatedAt,
            IsPaid = p.IsPaid,
            IsClosed = p.IsClosed,
            TotalItems = p.StatementItems.Count(),
            TotalAmount = p.StatementItems.Sum(p => p.Total)
        };
        public List<DebtPageDTO> LoadPages(int accountStatementId, int pageNumber, int pageSize)
        {
            IQueryable<DebtPage> query = _context.DebtPages.AsNoTracking().
                Where(p => p.AccountStatementID == accountStatementId).OrderBy
                (p => p.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return query.Select(DebtPageToDTO).ToList();
        }

        public int TotalRecords(int accountStatementId)
        {
            return _context.DebtPages.Where(p=>p.Id == accountStatementId).Count();
        }
        public List<DebtPageDTO> FilterPages(int accountStatmentId, int pageNumber, bool ?value
           , Expression<Func<DebtPage, bool>> filterExpr, int pageSize, out int filteredResult)
        {
            IQueryable<DebtPage> query = _context.DebtPages.Where(p => p.AccountStatementID == accountStatmentId)
            .OrderBy(p => p.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            if(filterExpr != null)
            {
                query = query.Where(filterExpr);
            }
             filteredResult = query.Count();
            return query.Select(DebtPageToDTO).ToList();
        }
    }
}
