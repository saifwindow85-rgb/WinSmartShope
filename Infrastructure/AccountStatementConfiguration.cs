using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartShope.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShope.Data.Config
{
    public class AccountStatementConfiguration : IEntityTypeConfiguration<AccountStatement>
    {
        public void Configure(EntityTypeBuilder<AccountStatement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Description).HasColumnType("NVARCHAR").HasMaxLength(700);

            builder.ToTable("AccountStatements");

            builder.HasMany(x => x.DebtPages).WithOne(x => x.AccountStatement).HasForeignKey(x=>x.AccountStatementID).IsRequired();
            builder.HasData(
 new AccountStatement { Id = 1, CustomerId = 1, CreatedAt = DateTime.Now.AddDays(-15), Description = "January Purchases", IsClosed = false, IsPaid = false },
 new AccountStatement { Id = 2, CustomerId = 1, CreatedAt = DateTime.Now.AddDays(-10), Description = "February Purchases", IsClosed = false, IsPaid = false },
 new AccountStatement { Id = 3, CustomerId = 2, CreatedAt = DateTime.Now.AddDays(-12), Description = "January Purchases", IsClosed = true, IsPaid = true },
 new AccountStatement { Id = 4, CustomerId = 3, CreatedAt = DateTime.Now.AddDays(-8), Description = "February Purchases", IsClosed = false, IsPaid = false },
 new AccountStatement { Id = 5, CustomerId = 4, CreatedAt = DateTime.Now.AddDays(-7), Description = "March Purchases", IsClosed = false, IsPaid = false },
 new AccountStatement { Id = 6, CustomerId = 5, CreatedAt = DateTime.Now.AddDays(-5), Description = "March Purchases", IsClosed = false, IsPaid = false },
 new AccountStatement { Id = 7, CustomerId = 5, CreatedAt = DateTime.Now.AddDays(-5), Description = "March Purchases", IsClosed = true, IsPaid = true }
);
        }
    }
}
