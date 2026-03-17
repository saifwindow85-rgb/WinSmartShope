using Domain.Entities;
using DTOs.CustomersDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static  class CustomerExtensions
    {
        public static CustomerDTO ToDTO(this Customer c)
        {
            return new CustomerDTO
            {
                Id = c.CustomerId,
                FullName = c.FullName,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address
            };
        }
        public static IEnumerable<CustomerDTO> ToDTO(this IEnumerable<Customer> customers)
        {
            return customers.Select(c => c.ToDTO());
        }
    }
}
