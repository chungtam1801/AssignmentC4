using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
	public class SizeConfiguration
	{
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Size");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Value).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
