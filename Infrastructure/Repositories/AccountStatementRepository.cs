using Domain.DTOs.Account_Statments;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountStatementRepository : IAccountStatement
    {
        public List<AccountStatmentsDTO> LoadAccountStatments(int customerId,int pageNumber, int pageSize)
        {
            return new List<AccountStatmentsDTO>();//No Imlemntion Yet
        }
    }
}
