using Azure;
using Domain.Entities;
using Domain.Interfaces;
using DTOs.CustomersDTO;
using Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Servs
{
    public class CustomerServices
    {
        private   readonly ICustomerRepository _repository;
        public int _pageSize { get; private set; } = 10;

        public CustomerServices(ICustomerRepository repository,int?pageSize =null)
        {
            _repository = repository;
            if (pageSize.HasValue)
                _pageSize = pageSize.Value; //why it works with customers And not with Accounts
        }
        public List<CustomerDTO>GetAllCustomers(int pageNumber)
        {
            return _repository.LoadCustomers(pageNumber, _pageSize);
        }

        public List<CustomerDTO>FilterCustomers(int pageNumber,string value,FilterType filter,out int filterCount,int pageSize)
        {
            Expression<Func<Customer, bool>>? filterExpr = filter switch
            {
                FilterType.Id => c => c.Id.ToString() == value,
                     FilterType.FullName => c => ((c.FirstName ?? "") + " " +
                     (c.SecondName ?? "") + " " + (c.ThirdName ?? "") + " " + (c.LastName ?? "")).Contains(value),

                FilterType.Phone => c => (c.Phone ?? "").Contains(value),
                FilterType.Email => c => (c.Email ?? "").Contains(value),
                _ => null
            };
            return _repository.FilterCustomers(pageNumber, value, filterExpr, out filterCount, _pageSize);
        }


        public int GetTotalRecords() => _repository.GetTotalRecords();
        public enum FilterType
        {
            None,
            Id,
            FullName,
            Phone,
            Email
        }

    }
}
