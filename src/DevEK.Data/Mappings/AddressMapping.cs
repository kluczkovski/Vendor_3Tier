using DevEK.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEK.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
  
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasColumnType("varchar(70)");

            builder.Property(a => a.Number)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            builder.Property(a => a.PostCode)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            builder.Property(a => a.Complement)
                   .HasColumnType("varchar(50)");

            builder.Property(a => a.Region)
                   .IsRequired()
                   .HasColumnType("varchar(30)");

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasColumnType("varchar(30)");

            builder.Property(a => a.State)
                   .IsRequired()
                   .HasColumnType("varchar(30)");


            builder.ToTable("Address");

        }
    }
}
