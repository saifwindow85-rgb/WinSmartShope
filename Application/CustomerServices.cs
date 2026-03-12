using Domain;
using DTOs.CustomersDTO;
using Microsoft.EntityFrameworkCore;
using SmartShope.Data;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Application
{
    public class CustomerServices
    {
        public static Expression<Func<Customer, CustomerDTO>> CustomerToDTO = c => new CustomerDTO
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Phone = c.Phone,
            Address =c.Address
            
        };
        public static List<CustomerDTO>GetCustomers(int PageNumber = 1, int PageSize = 10)
        {
            
            List<CustomerDTO> customers;
            using(var context = new AppDbContext())
            {
                var query = context.Customers.AsNoTracking();


                customers = query.Skip((PageNumber - 1) * PageSize).Take(PageSize).Select(CustomerToDTO).ToList();
                return customers;
            }
        }

        public static List<CustomerDTO> FilterCustomers(string Value,string SelectedFilter)
        {
            List<CustomerDTO> result;
            
            using (var context = new AppDbContext())
            {
                switch (SelectedFilter)
                {
                    case "None":
                        {
                            result = context.Customers.Select(CustomerToDTO).ToList();
                            return result;
                        }

                    case "Id":
                        {
                          if(!int.TryParse(Value,out int Id))
                            {
                                return new List<CustomerDTO>();
                            }
                          else
                            {
                                result = context.Customers.Where(c=>c.Id == Id).Select(CustomerToDTO).ToList();
                                return result;
                            }
                         
                        }

                    case "FullName":
                        {
                            result = context.Customers.Where(x => EF.Functions.Like(
                                       x.FirstName + " " + x.SecondName + " " + x.ThirdName + " " + x.LastName,
                                        $"%{Value}%")).Select(CustomerToDTO).ToList();
                            return result;
                        }

                    case "Phone Number":
                        {
                            result = context.Customers.Where(x => x.Phone != null && EF.Functions.Like(x.Phone, $"%{Value}%")).Select(CustomerToDTO).ToList();
                            return result;
                        }
                    case "Email":
                        {
                            result = context.Customers.Where(x => x.Email != null && EF.Functions.Like(x.Email, $"%{Value}%")).Select(CustomerToDTO).ToList();
                            return result;
                        }
                    default:
                        {
                            return new List<CustomerDTO>();
                        }
                }

            }
        }
        public static int TotalPages(int PageSize = 10)
        {
            int totalPages = 0;
            using (var context = new AppDbContext())
            {
                totalPages = (int)Math.Ceiling((double)context.Customers.Count() / PageSize);
            }
            return totalPages;
        }

    }
}
