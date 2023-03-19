using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.UserID);
            builder.Property(x => x.UserName).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(100)").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired();
            builder.HasOne(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleID);
    }
    }
}
