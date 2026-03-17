using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpper_Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; set; } = new();
        public int TotalRecords { get; set; }
    }
}
