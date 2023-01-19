using System.Collections.Generic;
using System;
using Task08.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task08.Configurations
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(e => e.IdPatient).HasName("IdPatient_PK");
            builder.Property(e => e.IdPatient).UseIdentityColumn();

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.BirthDate).IsRequired();

            

            var patients = new List<Patient>();

            patients.Add(new Patient
            {
                IdPatient = 1,
                FirstName = "Angela",
                LastName = "Martin",
                BirthDate = DateTime.Now.AddYears(-25)
            });

            patients.Add(new Patient
            {
                IdPatient = 2,
                FirstName = "Pam",
                LastName = "Halpert",
                BirthDate = DateTime.Now.AddYears(-21)
            });

            
            builder.HasData(patients);
        }
    }
}
