using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetil");
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.ClothesDetail).WithMany(x => x.CartDetails).HasForeignKey(x => x.ClothesDetailID);
            builder.HasOne(x => x.Cart).WithMany(x => x.CartDetails).HasForeignKey(x => x.UserID);
        }
    }
}
