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
    public class DoctorLabConfiguration : IEntityTypeConfiguration<DoctorLab>
    {
        public void Configure(EntityTypeBuilder<DoctorLab> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.Doctor)
                .WithMany(p => p.DoctorLabs)
                .HasForeignKey(p => p.DoctorId);

            builder.HasOne(p => p.Lab)
                .WithMany(p => p.DoctorLabs)
                .HasForeignKey(p => p.LabId);
        }
    }
}
