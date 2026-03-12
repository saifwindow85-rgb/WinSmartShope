using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShope.Entities
{
    public partial class StatementItem
    {
        public int Id { get; set; }
        public int DebtPageId { get; set; }
        public DebtPage DebtPage { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public Units Unit { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; } // just Temporary To Reduce The Complexty Now
        public decimal Total {  get; set; }
    }
}
