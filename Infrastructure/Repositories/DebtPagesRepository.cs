using Domain.DTOs.DebtPage;
using Domain.Entities;
using Domain.Helpper_Models;
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
            Id = p.DebtPageId,
            Description = p.Description,
            CreatedAt = p.CreatedAt,
            IsPaid = p.IsPaid,
            IsClosed = p.IsClosed,
            TotalItems = p.StatementItems.Count(),
            TotalAmount = p.StatementItems.Sum(p => p.Total)
        };
        public PagedResult<DebtPageDTO> LoadPages(int accountStatementId, int pageNumber, int pageSize,Expression<Func<DebtPage, bool>>? filterExpr = null)
        {
            IQueryable<DebtPage> query = _context.DebtPages.AsNoTracking().Where(p => p.AccountStatementID == accountStatementId);
            if(filterExpr!=null)
                query = query.Where(filterExpr);

            int totalCount = query.Count();

            var data = query.OrderBy(p => p.DebtPageId).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(DebtPageToDTO).ToList();
            return new PagedResult<DebtPageDTO>
            {
                Data = data,
                TotalRecords = totalCount
            };
        }
    }
}
