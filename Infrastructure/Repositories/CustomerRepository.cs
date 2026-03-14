using Domain.Entities;
using Domain.Interfaces;
using DTOs.CustomersDTO;
using Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private Expression<Func<Customer, CustomerDTO>> CustomerToDTO = c => new CustomerDTO
        {
            Id = c.Id,
            FullName = (c.FirstName ?? "") + " " + (c.SecondName ?? "") + " " + (c.ThirdName ?? "") + " " + (c.LastName ?? ""),
            Phone = c.Phone ?? "",
            Email = c.Email ?? "",
        };

        

        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<CustomerDTO> FilterCustomers(int pageNumber, string value, Expression<Func<Customer,bool>> ?filterExpr ,out int filterCount, int PageSize)
        {
            IQueryable<Customer> query = _context.Customers.AsNoTracking();

            if(filterExpr!=null)
            {
                query = query.Where(filterExpr);
            }
            filterCount = query.Count();
            return query.OrderBy(c=>c.Id).Skip((pageNumber-1)*PageSize).Take(PageSize).Select(CustomerToDTO).ToList();

        }

        public int GetTotalRecords()
        {
            return _context.Customers.Count();
        }

        public List<CustomerDTO>LoadCustomers(int pageNumber,int pageSize)
        {
            return _context.Customers.AsNoTracking().OrderBy(c => c.Id).Skip((pageNumber - 1)
                * pageSize).Take(pageSize).Select(CustomerToDTO).ToList(); // اليس الافضل هنا وضع ال Skip&Take قبل ال Order
        }

    }
}
