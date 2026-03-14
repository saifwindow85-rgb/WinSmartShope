using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class StatementItemConfiguration : IEntityTypeConfiguration<StatementItem>
    {
        public void Configure(EntityTypeBuilder<StatementItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.DebtPageId);

            builder.Property(x => x.ItemName).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();

            builder.Property(x => x.Price)
       .HasPrecision(18, 2);
            builder.ToTable("StatementItems");

            builder.Property(x => x.Total).HasComputedColumnSql("[Quantity] * [Price]");

            builder.Property(x => x.Unit).HasConversion<string>();
            builder.HasData(
    // DebtPage 1 - Vegetables
    new StatementItem { Id = 1, DebtPageId = 1, ItemName = "Potatoes", Unit = Units.Kg, Price = 2, Quantity = 5 },
    new StatementItem { Id = 2, DebtPageId = 1, ItemName = "Carrots", Unit = Units.Kg, Price = 1.5m, Quantity = 3 },
    new StatementItem { Id = 3, DebtPageId = 1, ItemName = "Tomatoes", Unit = Units.Kg, Price = 2.2m, Quantity = 4 },

    // DebtPage 2 - Beverages
    new StatementItem { Id = 4, DebtPageId = 2, ItemName = "Mineral Water", Unit = Units.Bottle, Price = 0.5m, Quantity = 12 },
    new StatementItem { Id = 5, DebtPageId = 2, ItemName = "Orange Juice", Unit = Units.Bottle, Price = 1.2m, Quantity = 6 },

    // DebtPage 3 - Snacks
    new StatementItem { Id = 6, DebtPageId = 3, ItemName = "Chips", Unit = Units.Box, Price = 2, Quantity = 3 },
    new StatementItem { Id = 7, DebtPageId = 3, ItemName = "Cookies", Unit = Units.Box, Price = 3, Quantity = 2 },

    // DebtPage 4 - Dairy
    new StatementItem { Id = 8, DebtPageId = 4, ItemName = "Milk", Unit = Units.Kg, Price = 1.5m, Quantity = 6 },
    new StatementItem { Id = 9, DebtPageId = 4, ItemName = "Cheese", Unit = Units.Kg, Price = 5, Quantity = 1 },

    // DebtPage 5 - Household Items
    new StatementItem { Id = 10, DebtPageId = 5, ItemName = "Pan", Unit = Units.Piece, Price = 20, Quantity = 1 },
    new StatementItem { Id = 11, DebtPageId = 5, ItemName = "Pressure Cooker", Unit = Units.Piece, Price = 35, Quantity = 1 },

    // DebtPage 6 - Cleaning Supplies
    new StatementItem { Id = 12, DebtPageId = 6, ItemName = "Soap", Unit = Units.Piece, Price = 1.2m, Quantity = 5 },
    new StatementItem { Id = 13, DebtPageId = 6, ItemName = "Detergent", Unit = Units.Box, Price = 6, Quantity = 2 },

    // DebtPage 7 - Fruits
    new StatementItem { Id = 14, DebtPageId = 7, ItemName = "Apple", Unit = Units.Kg, Price = 2, Quantity = 6 },
    new StatementItem { Id = 15, DebtPageId = 7, ItemName = "Banana", Unit = Units.Kg, Price = 1.8m, Quantity = 5 },

    // DebtPage 8 - Vegetables
    new StatementItem { Id = 16, DebtPageId = 8, ItemName = "Cucumber", Unit = Units.Kg, Price = 1.5m, Quantity = 4 },
    new StatementItem { Id = 17, DebtPageId = 8, ItemName = "Lettuce", Unit = Units.Kg, Price = 1.2m, Quantity = 3 },

    // DebtPage 9 - Snacks
    new StatementItem { Id = 18, DebtPageId = 9, ItemName = "Chocolate", Unit = Units.Piece, Price = 1.5m, Quantity = 5 },
    new StatementItem { Id = 19, DebtPageId = 9, ItemName = "Candy", Unit = Units.Box, Price = 2.5m, Quantity = 3 },

    // DebtPage 10 - Beverages
    new StatementItem { Id = 20, DebtPageId = 10, ItemName = "Cola", Unit = Units.Bottle, Price = 1, Quantity = 12 },
    new StatementItem { Id = 21, DebtPageId = 10, ItemName = "Orange Soda", Unit = Units.Bottle, Price = 1.2m, Quantity = 8 },

    // DebtPage 11 - Dairy
    new StatementItem { Id = 22, DebtPageId = 11, ItemName = "Yogurt", Unit = Units.Piece, Price = 0.8m, Quantity = 10 },
    new StatementItem { Id = 23, DebtPageId = 11, ItemName = "Butter", Unit = Units.Kg, Price = 4, Quantity = 1 },

    // DebtPage 12 - Fruits
    new StatementItem { Id = 24, DebtPageId = 12, ItemName = "Mango", Unit = Units.Kg, Price = 3, Quantity = 3 },
    new StatementItem { Id = 25, DebtPageId = 12, ItemName = "Pineapple", Unit = Units.Piece, Price = 2.5m, Quantity = 2 },

      new StatementItem { Id = 26, DebtPageId = 12, ItemName = "Mango", Unit = Units.Kg, Price = 3, Quantity = 3 },
    new StatementItem { Id = 27, DebtPageId = 12, ItemName = "Pineapple", Unit = Units.Piece, Price = 2.5m, Quantity = 2 }
);
        }
    }
}
