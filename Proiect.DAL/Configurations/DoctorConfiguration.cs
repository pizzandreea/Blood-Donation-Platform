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
    public class DoctorConfiguration
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {

            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            

            /*builder.HasOne(x => x.Address)
                .WithOne(x => x.Donor)
                .HasForeignKey<Donor>(x => x.AddressId);*/

        }
    }
}
