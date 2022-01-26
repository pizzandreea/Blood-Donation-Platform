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
    class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.BloodType)
                .HasColumnType("nvarchar(5)")
                .HasMaxLength(5);

            builder.Property(x => x.Gender)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10);

            builder.HasOne(p => p.Doctor)
               .WithMany(p => p.Patients)
               .HasForeignKey(p => p.DoctorId);
        }
    }
}
