using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assignment.Configurations
{
	public class ColorConfiguration
	{
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Color");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Value).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
