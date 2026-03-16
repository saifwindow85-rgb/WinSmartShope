using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.DebtPage
{
    public class DebtPageDTO
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool IsPaid { get; set; }
        public bool IsClosed { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalItems { get; set; }
        public decimal TotalAmount {  get; set; }
    }
}
