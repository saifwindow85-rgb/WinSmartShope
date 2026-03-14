using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Account_Statments
{
    public class AccountStatmentsDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Description { get; set; }
        public bool IsClosed { get; set; }
        public bool IsPaid { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
