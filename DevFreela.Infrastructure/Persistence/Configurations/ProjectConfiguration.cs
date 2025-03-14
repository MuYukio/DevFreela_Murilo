﻿using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder
            .HasKey(p => p.Id);

            builder
            .Property(p => p.TotalCost)
            .HasPrecision(18, 2);

            builder
                .HasOne(p => p.Freelancer)
                .WithMany(p => p.FreelanceProjects)
                .HasForeignKey(p => p.IdFreelancer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(p => p.Client)
               .WithMany(p => p.OwnedProjects)
               .HasForeignKey(p => p.IdClient)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
