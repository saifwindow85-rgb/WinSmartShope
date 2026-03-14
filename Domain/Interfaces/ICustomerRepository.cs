using Domain.Entities;
using DTOs.CustomersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public List<CustomerDTO> LoadCustomers(int pageNumber, int pageSize);
        public List<CustomerDTO> FilterCustomers(int pageNumber, string value, Expression<Func<Customer, bool>>? filterExpr, out int filterCount, int PageSize);
        public int GetTotalRecords();
    }
}
