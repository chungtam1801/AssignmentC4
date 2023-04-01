using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
    public class ClothesTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<ClothesType> builder)
        {
            builder.ToTable("ClothesType");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.HasOne(x => x.DadType).WithMany().HasForeignKey(x => x.DadTypeID);
        }
    }
}
