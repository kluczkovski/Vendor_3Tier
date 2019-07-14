using DevEK.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevEK.Data.Mappings
{
    public class VendorMapping : IEntityTypeConfiguration<Vendor>
    {

        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnType("varchar(70)");

            builder.Property(p => p.IdentifiyDocument)
                   .IsRequired()
                   .HasColumnType("varchar(14)");

            // 1 : 1 => Vendor : Address , it is not necessary, but is good to know
            builder.HasOne(v => v.Address)
                .WithOne(a => a.Vendor);

            // 1 : N => Vendor : Product
            builder.HasMany(v => v.Products)
                .WithOne(p => p.Vendor)
                .HasForeignKey(p => p.VendorId);

            builder.ToTable("Vendor");

        }
    }
}
