using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShope.Entities
{
    public class DebtPage
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int AccountStatementID { get; set; }
        public AccountStatement AccountStatement { get; set; } = null!;
        public bool IsPaid { get; set; }
        public bool IsClosed { get; set; }
        public DateTime CreatedAt {  get; set; }
        public ICollection<StatementItem> StatementItems { get; set; } = new List<StatementItem>();
        public decimal TotalAmount => StatementItems.Sum(x => x.Total);

    }
}
