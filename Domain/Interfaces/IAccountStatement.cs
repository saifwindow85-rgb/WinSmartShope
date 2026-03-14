using Domain.DTOs.Account_Statments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAccountStatement
    {
        public List<AccountStatmentsDTO> LoadAccountStatements(int customerId,int pageNumber, int pageSize);
    }
}
