using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using Task08.Models;

namespace Task08.Configurations
{
    public class PrescriptionMedicamentConfig : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(e => new
            {
                e.IdMedicament,
                e.IdPrescription
            }).HasName("PrescriptionMedicamend_PK");

            builder.ToTable("Prescription_Medicament");

            builder.Property(e => e.Dose);
            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

            builder.HasOne(e => e.IdMedicamentNav)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdMedicament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Medicament_Prescription_FK");

            builder.HasOne(e => e.IdPrescriptionNav)
                .WithMany(e => e.PrescriptionMedicaments)
                .HasForeignKey(e => e.IdPrescription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Prescription_Medicament_FK");

            

            var list = new List<PrescriptionMedicament>();

            list.Add(new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 11,
                Details = "presc desc"
            });

            list.Add(new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 12,
                Details = "presc desc"
            });

            

            builder.HasData(list);
        }
    }
}
