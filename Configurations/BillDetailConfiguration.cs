using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
    public class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.ToTable("BillDetail");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Price).HasColumnType("int");
            builder.Property(c => c.Quantity).HasColumnType("int");
            builder.HasOne(x => x.ClothesDetail).WithMany(x => x.BillDetails).HasForeignKey(x => x.ClothesDetailID);
            builder.HasOne(x => x.Bill).WithMany(x => x.BillDetails).HasForeignKey(x => x.BillID);
        }
    }
}
