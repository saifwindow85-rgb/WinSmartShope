using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShope.Entities
{
    public class AccountStatement
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public DateTime CreatedAt {  get; set; }
        public string ?Description { get; set; }
        public bool IsClosed { get; set; }
        public bool IsPaid { get; set; } 

        public ICollection<DebtPage> DebtPages { get; set; } = new List<DebtPage>();
        public decimal TotalAmount => DebtPages.Where(x => !x.IsPaid).Sum(x => x.TotalAmount); 
    }
}
