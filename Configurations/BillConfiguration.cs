using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.CreateDate).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.Status).HasColumnType("nvarchar(1000)").IsRequired();
            builder.HasOne(x => x.User).WithMany(x => x.Bills).HasForeignKey(x => x.UserID);
        }
    }
}
