using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShope.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.FirstName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
            builder.Property(x => x.SecondName).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.ThirdName).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Address).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Phone).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();
            builder.HasMany(x => x.AccountStatements).WithOne(x => x.Customer).HasForeignKey(x=>x.CustomerId).IsRequired();
            builder.ToTable("Customers");
                     builder.HasData(
             new Customer { Id = 1, FirstName = "John", LastName = "Smith",SecondName = "Ali",ThirdName = "Ahmed", Phone = "770100111", Email = "john@example.com", Address = "New York"},
             new Customer { Id = 2, FirstName = "Alice", LastName = "Johnson", SecondName = "Ali", ThirdName = "Ahmed", Phone = "770100222", Email = "alice@example.com", Address = "Los Angeles" },
             new Customer { Id = 3, FirstName = "Michael", LastName = "Brown", SecondName = "Ali", ThirdName = "Ahmed", Phone = "770100333", Email = "michael@example.com", Address = "Chicago" },
             new Customer { Id = 4, FirstName = "Emma", LastName = "Davis", SecondName = "Ali", ThirdName = "Ahmed", Phone = "770100444", Email = "emma@example.com", Address = "Houston" },
             new Customer { Id = 5, FirstName = "David", LastName = "Wilson", SecondName = "Ali", ThirdName = "Ahmed", Phone = "770100555", Email = "david@example.com", Address = "Philadelphia" }
         );
        }
    }
}
