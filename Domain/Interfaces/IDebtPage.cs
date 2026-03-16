using Domain.DTOs.DebtPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDebtPage
    {
        public List<DebtPageDTO> LoadPages(int accountStatementId, int pageNumber, int pageSize);
    }
}
