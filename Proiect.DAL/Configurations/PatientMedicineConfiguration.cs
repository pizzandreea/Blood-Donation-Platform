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
    public class PatientMedicineConfiguration : IEntityTypeConfiguration<PatientMedicine>
    {
        public void Configure(EntityTypeBuilder<PatientMedicine> builder)
        {
            builder.HasOne(p => p.Patient)
                .WithMany(p => p.PatientMedicines)
                .HasForeignKey(p => p.PatientId);

            builder.HasOne(p => p.Medicine)
                .WithMany(p => p.PatientMedicines)
                .HasForeignKey(p => p.MedicineId);
        }
    }
}
