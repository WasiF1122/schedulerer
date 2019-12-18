using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schedulerer.Domain;

namespace Schedulerer.Infrastructure
{
    internal class ChildConfiguration : IEntityTypeConfiguration<Child>
    {
        public void Configure(EntityTypeBuilder<Child> builder)
        {
            builder.OwnsOne(
                o => o.Name,
                n =>
                {
                    n.Property(p => p.FirstName).IsRequired().HasColumnName("FirstName");
                    n.Property(p => p.MiddleName).IsRequired().HasColumnName("MiddleName");
                    n.Property(p => p.LastName).IsRequired().HasColumnName("LastName");
                });
        }
    }
}
