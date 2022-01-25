using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proiect.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.DAL.Configurations
{
    //fluent api
    //IEntity - Interface Entity
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Phone)
                .HasColumnType("nvarchar(11)")
                .HasMaxLength(11);

            builder.Property(x => x.City)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.Street)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

        }
    }
}
