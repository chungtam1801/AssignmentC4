using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
	public class ClothesDetailConfiguration
	{
        public void Configure(EntityTypeBuilder<ClothesDetail> builder)
        {
            builder.ToTable("ClothesDetil");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Quantity).HasColumnType("int").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Clothes).WithMany(x => x.ClothesDetails).HasForeignKey(x => x.ClothesID);
            builder.HasOne(x => x.Color).WithMany(x => x.ClothesDetails).HasForeignKey(x => x.ColorID);
            builder.HasOne(x => x.Size).WithMany(x => x.ClothesDetails).HasForeignKey(x => x.SizeID);
    }
    }
}
