using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class DebtPageConfiguration : IEntityTypeConfiguration<DebtPage>
    {
        public void Configure(EntityTypeBuilder<DebtPage> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.AccountStatementID);

            builder.Property(x => x.Description).HasColumnType("NVARCHAR").HasMaxLength(700);
            builder.ToTable("DebtPages");

            builder.HasMany(x => x.StatementItems).WithOne(x => x.DebtPage).HasForeignKey(x=>x.DebtPageId).IsRequired();
            builder.HasData(
    // Customer 1, Statement 1
    new DebtPage { Id = 1, AccountStatementID = 1, Description = "Page 1 - Vegetables", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-15) },
    new DebtPage { Id = 2, AccountStatementID = 1, Description = "Page 2 - Beverages", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-15) },

    // Customer 1, Statement 2
    new DebtPage { Id = 3, AccountStatementID = 2, Description = "Page 1 - Snacks", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-10) },
    new DebtPage { Id = 4, AccountStatementID = 2, Description = "Page 2 - Dairy", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-10) },

    // Customer 2, Statement 3
    new DebtPage { Id = 5, AccountStatementID = 3, Description = "Page 1 - Household Items", IsPaid = true, IsClosed = true, CreatedAt = DateTime.Now.AddDays(-12) },
    new DebtPage { Id = 6, AccountStatementID = 3, Description = "Page 2 - Cleaning Supplies", IsPaid = true, IsClosed = true, CreatedAt = DateTime.Now.AddDays(-12) },

    // Customer 3, Statement 4
    new DebtPage { Id = 7, AccountStatementID = 4, Description = "Page 1 - Fruits", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-8) },
    new DebtPage { Id = 8, AccountStatementID = 4, Description = "Page 2 - Vegetables", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-8) },

    // Customer 4, Statement 5
    new DebtPage { Id = 9, AccountStatementID = 5, Description = "Page 1 - Snacks", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-7) },
    new DebtPage { Id = 10, AccountStatementID = 5, Description = "Page 2 - Beverages", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-7) },

    // Customer 5, Statement 6
    new DebtPage { Id = 11, AccountStatementID = 6, Description = "Page 1 - Dairy", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-5) },
    new DebtPage { Id = 12, AccountStatementID = 6, Description = "Page 2 - Fruits", IsPaid = false, IsClosed = false, CreatedAt = DateTime.Now.AddDays(-5) },

        new DebtPage { Id = 13, AccountStatementID = 7, Description = "Page 1 - Dairy", IsPaid = true, IsClosed = true, CreatedAt = DateTime.Now.AddDays(-5) },
    new DebtPage { Id = 14, AccountStatementID = 7, Description = "Page 2 - Fruits", IsPaid = true, IsClosed = true, CreatedAt = DateTime.Now.AddDays(-5) }
);
        }
    }
}
